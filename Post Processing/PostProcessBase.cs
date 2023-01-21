using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// The base class for all post processors.
    /// </summary>
    public class PostProcessBase
    {
        #region Constants

        const int cNumberOfTriangles = 2;

        #endregion
        #region Private Variables

        private VertexBuffer vertexBuffer;

        #endregion
        #region Protected Variables

        /// <summary>
        /// The graphics device.
        /// </summary>
        protected GraphicsDevice graphicsDevice;

        /// <summary>
        /// The effect to be used.
        /// </summary>
        protected Effect effect;

        /// <summary>
        /// The projection matrix.
        /// </summary>
        protected Matrix orthoMatrix;

        /// <summary>
        /// The view matrix.
        /// </summary>
        protected Matrix viewMatrix;

        #endregion
        #region Public Properties

        /// <summary>
        /// The curent technique name.
        /// </summary>
        public string CurrentTechnique
        {
            get { return effect.CurrentTechnique.Name; }
            set { effect.CurrentTechnique = effect.Techniques[value]; }
        }

        /// <summary>
        /// The Depth Map texture.
        /// </summary>
        public RenderTarget2D DepthMapTexture { get; set; }

        /// <summary>
        /// The Pre Process (Input) texture.
        /// </summary>
        public RenderTarget2D PreProcessTexture { get; set; }

        /// <summary>
        /// The Post Process (Output) texture.
        /// </summary>
        public RenderTarget2D PostProcessTexture { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes the base class for the post processor.
        /// </summary>
        /// <param name="device">A GraphicsDevice object.</param>
#pragma warning disable CS8618 // Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.
        public PostProcessBase(GraphicsDevice device)
#pragma warning restore CS8618 // Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.
        {
            #region Disable null warnings
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            
            // This will be set in a derived class
            effect = null;

            // These will be set outside of the class
            PreProcessTexture = null;
            PostProcessTexture = null;

#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            #endregion

            graphicsDevice = device;
            vertexBuffer = new VertexBuffer(graphicsDevice,
                                            typeof(VertexPositionTexture),
                                            6,
                                            BufferUsage.None);

            int width = graphicsDevice.PresentationParameters.BackBufferWidth;
            int height = graphicsDevice.PresentationParameters.BackBufferHeight;

            VertexPositionTexture[] vertices = new VertexPositionTexture[6]
            {
                new VertexPositionTexture(new Vector3(0, height, 0), new Vector2(0, 1)),
                new VertexPositionTexture(new Vector3(0, 0, 0), new Vector2(0, 0)),
                new VertexPositionTexture(new Vector3(width, height, 0), new Vector2(1, 1)),
                new VertexPositionTexture(new Vector3(width, height, 0), new Vector2(1, 1)),
                new VertexPositionTexture(new Vector3(0, 0, 0), new Vector2(0, 0)),
                new VertexPositionTexture(new Vector3(width, 0, 0), new Vector2(1, 0))
            };

            vertexBuffer.SetData(vertices);

            Vector2 screenCenter = new (width * 0.5f, height * 0.5f);
            orthoMatrix = Matrix.CreateOrthographic(screenCenter.X * 2, screenCenter.Y * 2, -0.5f, 1);
            viewMatrix = Matrix.CreateLookAt(new Vector3(screenCenter, 0), new Vector3(screenCenter, 1), new Vector3(0, -1, 0));
        }

        #endregion
        #region Deconstructor

        /// <summary>
        /// Destructor.
        /// </summary>
        ~PostProcessBase()
        {
            effect?.Dispose();
            vertexBuffer?.Dispose();
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        virtual public void SetEffectParameters()
        {
            effect.Parameters["PreProcessTextureMap"].SetValue(PreProcessTexture);
            effect.Parameters["Projection"].SetValue(orthoMatrix);
            effect.Parameters["View"].SetValue(viewMatrix);
        }

        #endregion
        #region Execute  (Overridable)

        /// <summary>
        /// Executes the post processor.
        /// </summary>
        virtual public void Execute()
        {
            graphicsDevice.SetRenderTarget(PostProcessTexture);

            SetEffectParameters();
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphicsDevice.SetVertexBuffer(vertexBuffer);
                graphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, cNumberOfTriangles);
            }

            graphicsDevice.SetRenderTarget(null);
        }

        #endregion
    }
}
