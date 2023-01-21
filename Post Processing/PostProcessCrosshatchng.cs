using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//
// NOTE: This only works on DirectX not OpenGL
//

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Crosshatching Post Process.
    /// </summary>
    public class PostProcessCrosshatching : PostProcessBase
    {
        #region Private Variables

        private Vector2 crosshatchOffset = new Vector2(10, 5);
        private Vector4 luminanceThreshold;

        #endregion
        #region Public Properties

        /// <summary>
        /// The Crosshatch offset.
        /// </summary>
        public Vector2 CrosshatchOffset
        {
            get { return crosshatchOffset; }
            set { crosshatchOffset = value; }
        }

        /// <summary>
        /// The luminance threshold.
        /// </summary>
        public Vector4 LuminanceThreshold
        {
            get { return luminanceThreshold; }
            set { luminanceThreshold = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessCrosshatching class.
        /// </summary>
        public PostProcessCrosshatching(GraphicsDevice device,
                                        Vector2 hatchOffset, 
                                        Vector4 threshhold) : 
            base(device)
        {
            effect = new Effects.PostProcessingCrosshatchingEffect(device);
            CrosshatchOffset = hatchOffset;
            LuminanceThreshold = threshhold;
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["CrosshatchOffset"].SetValue(crosshatchOffset);
            effect.Parameters["LuminanceThreshold"].SetValue(luminanceThreshold);
            base.SetEffectParameters();
        }

        #endregion
    }
}
