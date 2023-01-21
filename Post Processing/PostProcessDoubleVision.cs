using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Double Vision Post Process.
    /// </summary>
    public class PostProcessDoubleVision : PostProcessBase
    {
        #region Private Variables

        private float doubleVisionRange;

        #endregion
        #region Public Properties

        /// <summary>
        /// The Double Vision Range.
        /// </summary>
        public float DoubleVisionRange
        {
            get { return doubleVisionRange; }
            set { doubleVisionRange = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessDoubleVision.
        /// </summary>
        public PostProcessDoubleVision(GraphicsDevice device, 
                                       float range) : 
            base(device)
        {
            effect = new Effects.PostProcessingDoubleVisionEffect(device);
            DoubleVisionRange = range;
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["DoubleVisionRange"].SetValue(doubleVisionRange);
            base.SetEffectParameters();
        }

        #endregion
    }
}
