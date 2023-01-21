using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Monochrome Edge Detecton Post Process.
    /// </summary>
    public class PostProcessMonochromeEdgeDetection : PostProcessBase
    {
        #region Private Variables

        private Vector4 backColorAsVector4;
        private Vector4 edgeColorAsVector4;
        private float edgeThreshold;
        private Vector2 texelSize;

        #endregion
        #region Public Properties

        /// <summary>
        /// The background color.
        /// </summary>
        public Color BackgroundColor
        {
            get { return new Color(backColorAsVector4); }
            set { backColorAsVector4 = value.ToVector4(); }
        }

        /// <summary>
        /// The background color as a Vector3.
        /// </summary>
        public Vector3 BackgroundColorAsVector3
        {
            get { return new Vector3(backColorAsVector4.X, backColorAsVector4.Y, backColorAsVector4.Z); }
            set { backColorAsVector4 = new Vector4(value, 1); }
        }

        /// <summary>
        /// The background color as a Vector4.
        /// </summary>
        public Vector4 BackgroundColorAsVector4
        {
            get { return backColorAsVector4; }
            set { backColorAsVector4 = value; }
        }

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
            get { return new Vector3(edgeColorAsVector4.X, edgeColorAsVector4.Y, edgeColorAsVector4.Z); }
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
        /// The edge threshold.
        /// </summary>

        public float EdgeThreshold
        {
            get { return edgeThreshold; }
            set { edgeThreshold = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessMonochromeEdgeDetection class.
        /// </summary>
        public PostProcessMonochromeEdgeDetection(GraphicsDevice device,
                                                  Color backColor,
                                                  Color edgeColor,
                                                  float threshold) :
            base(device)
        {
            effect = new Effects.PostProcessingMonochromeEdgeDetectionEffect(device);
            BackgroundColor = backColor;
            EdgeColor = edgeColor;
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
            effect.Parameters["BackgroundColor"].SetValue(backColorAsVector4);
            effect.Parameters["EdgeColor"].SetValue(edgeColorAsVector4);
            effect.Parameters["EdgeThreshold"].SetValue(edgeThreshold);
            effect.Parameters["TexelSize"].SetValue(texelSize);
            base.SetEffectParameters();
        }

        #endregion
    }
}
