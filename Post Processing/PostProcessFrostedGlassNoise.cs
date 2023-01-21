using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Frosted Glass Post Process using Noise.
    /// </summary>
    public class PostProcessFrostedGlassNoise : PostProcessBase
    {
        #region Private Variables

        float frequency;
        int height;
        Texture2D noiseTexture;
        Vector2 pixelSize;
        Vector2 texelSize;
        int width;

        #endregion
        #region Public Properties

        /// <summary>
        /// The frequency. Defaults to 0.115f.
        /// </summary>
        public float Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        /// <summary>
        /// The noise texture.
        /// </summary>
        public Texture2D NoiseTexture
        {
            get { return noiseTexture; }
            set { noiseTexture = value; }
        }

        /// <summary>
        /// The pixel size. Defaults to new Vector(2.0f).
        /// </summary>
        public Vector2 PixelSize
        {
            get { return pixelSize; }
            set
            {
                pixelSize = value;
                texelSize = new Vector2(pixelSize.X / width, pixelSize.Y / height);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessFrostedGlassNoise class.
        /// </summary>
        public PostProcessFrostedGlassNoise(GraphicsDevice device,
                                            Texture2D noise, 
                                            Vector2 pixelSize, 
                                            float freq = 0.115f) : 
            base(device)
        {
            effect = new Effects.PostProcessingFrostedGlassNoiseEffect(device);
            frequency = freq;
            noiseTexture = noise;

            width = graphicsDevice.PresentationParameters.BackBufferWidth;
            height = graphicsDevice.PresentationParameters.BackBufferHeight;
            PixelSize = pixelSize; // Default new Vector2(2.0f);
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["Frequency"].SetValue(frequency);
            effect.Parameters["NoiseTextureMap"].SetValue(noiseTexture);
            effect.Parameters["TexelSize"].SetValue(texelSize);
            base.SetEffectParameters();
        }

        #endregion
    }
}
