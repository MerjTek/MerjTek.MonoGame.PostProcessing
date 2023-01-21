using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Film Grain Post Process.
    /// </summary>
    public class PostProcessFilmGrain : PostProcessBase
    {
        #region Private Variables

        private float amount;
        private float time;

        #endregion
        #region Public Properties

        /// <summary>
        /// The amount of film grain. Defaults to 0.15f.
        /// </summary>
        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// The time value.
        /// </summary>
        public float Time
        {
            get { return time; }
            set { time = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessFilmGrain class.
        /// </summary>
        public PostProcessFilmGrain(GraphicsDevice device,
                                    float a = 0.15f) : 
            base(device)
        {
            effect = new Effects.PostProcessingFilmGrainEffect(device);
            amount = a;
            time = 0;
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["Amount"].SetValue(amount);
            effect.Parameters["Time"] .SetValue(time);
            base.SetEffectParameters();
        }

        #endregion
    }
}
