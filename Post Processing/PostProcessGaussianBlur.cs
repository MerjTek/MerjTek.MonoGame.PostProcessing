using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Gaussian Blur Post Process.
    /// </summary>
    public class PostProcessGaussianBlur : PostProcessBase
    {
        #region Constants

        const int cMaxBlurRadius = 64;

        #endregion
        #region Private Variables

        private float blurMean;
        private float blurStrength;
        private int blurRadius;
        private float[] gaussianFilter;
        private Vector2 texelSize;

        #endregion
        #region Public Properties

        /// <summary>
        /// The blur mean value.
        /// </summary>
        public float BlurMean
        {
            get { return blurMean; }
            set 
            { 
                blurMean = Math.Max(0.1f, Math.Min(2, value));
                UpdateGaussianDistribution();
            }
        }

        /// <summary>
        /// The blur radius.
        /// </summary>
        public int BlurRadius
        {
            get { return blurRadius; }
            set
            {
                blurRadius = Math.Max(3, Math.Min(51, value));
                UpdateGaussianDistribution();
            }
        }

        /// <summary>
        /// The blur strength.
        /// </summary>
        public float BlurStrength
        {
            get { return blurStrength; }
            set
            {
                blurStrength = Math.Max(0.1f, Math.Min(50, value));
                UpdateGaussianDistribution();
            }
        }

        #endregion

        #region Construtor

        /// <summary>
        /// Initializes an instance of the PostProcessGaussianBlur class.
        /// </summary>
        public PostProcessGaussianBlur(GraphicsDevice device,
                                       float mean, 
                                       int radius, 
                                       float strength) : 
            base(device)
        {
            effect = new Effects.PostProcessingGaussianBlurEffect(device);
            gaussianFilter = new float[cMaxBlurRadius];

            BlurMean = mean;
            BlurRadius = radius;
            BlurStrength = strength;

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
            effect.Parameters["BlurRadius"].SetValue(blurRadius);
            effect.Parameters["GaussianFilter"].SetValue(gaussianFilter);
            effect.Parameters["TexelSize"].SetValue(texelSize);            
            base.SetEffectParameters();
        }

        #endregion

        #region UpdateGaussianDistribution

        private void UpdateGaussianDistribution()
        {
            for (int i = 0; i < cMaxBlurRadius; i++)
                gaussianFilter[i] = 0.0f;

            for (int i = 0; i < blurRadius; i++)
            {
                float r = (blurRadius / 2) - i;
                gaussianFilter[i] = blurMean * (float)Math.Exp(-(r * r) / (2 * blurStrength * blurStrength));
            }
        }

        #endregion
    }
}
