using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a canline Post Process.
    /// </summary>
    public class PostProcessScanline : PostProcessBase
    {
        #region Private Variables

        private Vector4 backgroundColor;
        private int screenHeight;

        #endregion
        #region Public Properties

        /// <summary>
        /// The background color.
        /// </summary>
        public Color BackgroundColor
        {
            get { return new Color(backgroundColor.X, backgroundColor.Y, backgroundColor.Z, backgroundColor.W); }
            set { backgroundColor = value.ToVector4(); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessScanline class.
        /// </summary>
        public PostProcessScanline(GraphicsDevice device,
                                   Color color) : 
            base(device)
        {
            effect = new Effects.PostProcessingScanlineEffect(device);
            backgroundColor = color.ToVector4();
            screenHeight = graphicsDevice.PresentationParameters.BackBufferHeight;
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["BackgroundColor"].SetValue(backgroundColor);
            effect.Parameters["ScreenHeight"].SetValue(screenHeight);
            base.SetEffectParameters();
        }

        #endregion
    }
}
