using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Pixelate Post Process.
    /// </summary>
    public class PostProcessPixelate : PostProcessBase
    {
        #region Private Variables

        private Vector2 pixelateSize;
        private Vector2 texelSize;

        #endregion
        #region Public Properties

        /// <summary>
        /// THe pixelation size.
        /// </summary>
        public Vector2 PixelateSize
        {
            get { return pixelateSize; }
            set { pixelateSize = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessPixelate class.
        /// </summary>
        public PostProcessPixelate(GraphicsDevice device,
                                   Vector2 size) : 
            base(device)
        {
            effect = new Effects.PostProcessingPixelateEffect(device);
            pixelateSize = size;

            int width = graphicsDevice.PresentationParameters.BackBufferWidth;
            int height = graphicsDevice.PresentationParameters.BackBufferHeight;
            texelSize = new Vector2(1.0f / width, 1.0f / height);
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["PixelateSize"].SetValue(pixelateSize);
            effect.Parameters["TexelSize"].SetValue(texelSize);
            base.SetEffectParameters();
        }

        #endregion
    }
}
