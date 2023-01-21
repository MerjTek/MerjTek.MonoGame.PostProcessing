using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a CrossStiching Post Process.
    /// </summary>
    public class PostProcessCossStiching : PostProcessBase
    {
        #region Private Variables

        private bool invert;
        private Vector2 screenSize;
        private float stitchingSize;

        #endregion
        #region Public Properties

        /// <summary>
        /// Whether to invert the cross stitching.
        /// </summary>
        public bool Invert
        {
            get { return invert; }
            set { invert = value; }
        }

        /// <summary>
        /// The cross stitching size. Defaults to 6.0f.
        /// </summary>
        public float StitchingSize
        {
            get { return stitchingSize; }
            set { stitchingSize = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessCrossStiching class.
        /// </summary>
        public PostProcessCossStiching(GraphicsDevice device,
                                      float size = 6.0f) : 
            base(device)
        {
            effect = new Effects.PostProcessingCrossStichingEffect(device);

            screenSize = new Vector2(
                graphicsDevice.PresentationParameters.BackBufferWidth,
                graphicsDevice.PresentationParameters.BackBufferHeight);

            stitchingSize = size;
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["Invert"].SetValue(invert);
            effect.Parameters["StitchingSize"].SetValue(stitchingSize);
            effect.Parameters["ScreenSize"].SetValue(screenSize);
            base.SetEffectParameters();
        }

        #endregion
    }
}
