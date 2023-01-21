using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Circle Lens Post Process.
    /// </summary>
    public class PostProcessCircleLens : PostProcessBase
    {
        #region Private Variables

        private Vector2 lensRadius;

        #endregion
        #region Public Properties

        /// <summary>
        /// The Lens Radius. Values are clamped between 0.0f and 1.0f.
        /// </summary>
        public Vector2 LensRadius
        {
            get { return lensRadius; }
            set { lensRadius = Vector2.Max(Vector2.Zero, Vector2.Min(Vector2.One, value)); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessCircleLens class.
        /// </summary>
        public PostProcessCircleLens(GraphicsDevice device,
                                     Vector2 radius) :
            base(device)
        {
            effect = new Effects.PostProcessingCircleLensEffect(device);
            LensRadius = radius;
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["LensRadius"].SetValue(lensRadius);
            base.SetEffectParameters();
        }

        #endregion
    }
}
