using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs an Edge Detection Post Process.
    /// </summary>
    public class PostProcessEdgeDetection : PostProcessBase
    {
        #region Private Variables

        private Vector4 edgeColorAsVector4;
        private float edgeThreshold;
        private Vector2 texelSize;

        #endregion
        #region Public Properties

        /// <summary>
        /// The edge color.
        /// </summary>
        public Color EdgeColor
        {
            get { return new Color(edgeColorAsVector4); }
            set { edgeColorAsVector4 = value.ToVector4(); }
        }

        /// <summary>
        /// The edge color as a Vector3.
        /// </summary>
        public Vector3 EdgeColorAsVector3
        {
            get
            {
                return new Vector3(edgeColorAsVector4.X,
                                   edgeColorAsVector4.Y,
                                   edgeColorAsVector4.Z);
            }

            set { edgeColorAsVector4 = new Vector4(value, 1); }
        }

        /// <summary>
        /// The edge color as a Vector4.
        /// </summary>
        public Vector4 EdgeColorAsVector4
        {
            get { return edgeColorAsVector4; }
            set { edgeColorAsVector4 = value; }
        }

        /// <summary>
        /// THe edge threshold.
        /// </summary>
        public float EdgeThreshold
        {
            get { return edgeThreshold; }
            set { edgeThreshold = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessEdgeDetection class.
        /// </summary>
        public PostProcessEdgeDetection(GraphicsDevice device,
                                        Color color,
                                        float threshold) : base(device)
        {
            effect = new Effects.PostProcessingEdgeDetectionEffect(device);
            EdgeColor = color;
            EdgeThreshold = threshold;

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
            effect.Parameters["EdgeColor"].SetValue(edgeColorAsVector4);
            effect.Parameters["EdgeThreshold"].SetValue(edgeThreshold);
            effect.Parameters["TexelSize"].SetValue(texelSize);
            base.SetEffectParameters();
        }

        #endregion
    }
}
