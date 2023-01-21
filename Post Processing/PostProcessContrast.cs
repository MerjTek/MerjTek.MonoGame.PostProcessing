using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Constrast Post Process.
    /// </summary>
    public class PostProcessContrast : PostProcessBase
    {
        #region Private Variables

        private float contrastAmount;

        #endregion
        #region Public Properties

        /// <summary>
        /// The amount of contrast.
        /// </summary>
        public float ContrastAmount
        {
            get { return contrastAmount; }
            set { contrastAmount = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessContrast class.
        /// </summary>
        public PostProcessContrast(GraphicsDevice device, 
                                   float amount) : 
            base(device)
        {
            effect = new Effects.PostProcessingContrastEffect(device);
            ContrastAmount = amount;
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["ContrastAmount"].SetValue(contrastAmount);
            base.SetEffectParameters();
        }

        #endregion
    }
}
