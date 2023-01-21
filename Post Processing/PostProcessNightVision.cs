using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a NightVision Post Process.
    /// </summary>
    public class PostProcessNightVision : PostProcessBase
    {
        #region Private Variables

        private float colorAmplification;
        private float luminanceThreshold;
        private Texture2D screenMask;

        #endregion
        #region Public Properties

        /// <summary>
        /// The color amplication.
        /// </summary>
        public float ColorAmplification
        {
            get { return colorAmplification; }
            set { colorAmplification = value; }
        }

        /// <summary>
        /// The luminance threshold.
        /// </summary>
        public float LuminanceThreshold
        {
            get { return luminanceThreshold; }
            set { luminanceThreshold = value; }
        }

        /// <summary>
        /// The screen mask.
        /// </summary>
        public Texture2D ScreenMask
        {
            get { return screenMask; }
            set { screenMask = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessNightVision class.
        /// </summary>
        public PostProcessNightVision(GraphicsDevice device,
                                      float amp, 
                                      float threshold, 
                                      Texture2D mask) : 
            base(device)
        {
            colorAmplification = amp;
            effect = new Effects.PostProcessingNightVisionEffect(device);
            luminanceThreshold = threshold;
            screenMask = mask;
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["ColorAmplification"].SetValue(colorAmplification);
            effect.Parameters["LuminanceThreshold"].SetValue(luminanceThreshold);
            effect.Parameters["ScreenMaskTextureMap"].SetValue(screenMask);
            base.SetEffectParameters();
        }

        #endregion
    }
}
