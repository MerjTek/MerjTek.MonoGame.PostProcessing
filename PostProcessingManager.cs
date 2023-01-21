using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A manager to handle all post processors.
    /// </summary>
    public class PostProcessingManager
    {
        #region Private Variables

        private readonly GraphicsDevice graphicsDevice;
        private RenderTarget2D first;
        private RenderTarget2D second;
        private readonly SpriteBatch finalRect;
        private bool isCaptured;

        #endregion
        #region Public Properties

        /// <summary>
        /// The depth map texture.
        /// </summary>
        public RenderTarget2D DepthMapTexture { get; set; }

        /// <summary>
        /// Is the manager enabled?
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion

        #region Construcor

        /// <summary>
        /// Initializes an instance of the PostProcessingManager.
        /// </summary>
        /// <param name="device">The graphics device object.</param>
#pragma warning disable CS8618 // Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.
        public PostProcessingManager(GraphicsDevice device)
#pragma warning restore CS8618 // Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.
        {
            #region Disable null warnings
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

            DepthMapTexture = null;

#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            #endregion

            graphicsDevice = device;
            IsEnabled = true;

            // Create the RenderTargets
            PresentationParameters pres = device.PresentationParameters;
            first = new RenderTarget2D(device,
                                       pres.BackBufferWidth,
                                       pres.BackBufferHeight,
                                       false,
                                       pres.BackBufferFormat,
                                       pres.DepthStencilFormat);
            second = new RenderTarget2D(device,
                                        pres.BackBufferWidth,
                                        pres.BackBufferHeight,
                                        false,
                                        pres.BackBufferFormat,
                                        pres.DepthStencilFormat);

            // Create a SpriteBatch to draw the final screen
            finalRect = new SpriteBatch(device);
        }

        #endregion
        #region Deconstructor

        /// <summary>
        /// Deconstructor
        /// </summary>
        ~PostProcessingManager()
        {
            first?.Dispose();
            second?.Dispose();
            finalRect?.Dispose();
        }

        #endregion

        #region CaptureScreen

        /// <summary>
        /// Captures the screen that the post processing acts on.
        /// </summary>
        public void CaptureScreen()
        {
            if (IsEnabled)
            {
                graphicsDevice.SetRenderTarget(first);
                isCaptured = true;
            }
        }

        #endregion
        #region UncaptureAndExecute

        /// <summary>
        /// Uncaptures the screen and executes all post processors in order.
        /// </summary>
        public void UncaptureAndExecute(HashSet<PostProcessBase> postProcesses)
        {
            if (isCaptured)
            {
                graphicsDevice.SetRenderTarget(null);
                RenderTarget2D final = first;

                #region Execute all post processors

                if (postProcesses.Count > 0)
                {
                    bool toggle = false;

                    foreach (PostProcessBase pp in postProcesses)
                    {
                        #region Set the Depth Map

                        pp.DepthMapTexture = DepthMapTexture;

                        #endregion
                        #region Set up the render targets (Before)

                        if (toggle)
                        {
                            pp.PreProcessTexture = second;
                            pp.PostProcessTexture = first;
                        }
                        else
                        {
                            pp.PreProcessTexture = first;
                            pp.PostProcessTexture = second;
                        }

                        #endregion

                        pp.Execute();
                        toggle = !toggle;

                        #region Set up the render targets (After)

                        if (toggle)
                        {
                            second = pp.PostProcessTexture;
                            first = pp.PreProcessTexture;
                        }
                        else
                        {
                            first = pp.PostProcessTexture;
                            second = pp.PreProcessTexture;
                        }

                        #endregion
                    }

                    #region Determine which RenderTarget was the last used

                    if ((postProcesses.Count & 1) == 1)
                        final = second;
                    else
                        final = first;

                    #endregion
                }

                #endregion
                #region Draw the "final" screen

                finalRect.Begin();
                finalRect.Draw(final, Vector2.Zero, Color.White);
                finalRect.End();

                #endregion

                isCaptured = false;
            }
        }

        #endregion
    }
}
