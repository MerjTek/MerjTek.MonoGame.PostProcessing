using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Tint Post Process.
    /// </summary>
    public class PostProcessTint : PostProcessBase
    {
        #region Private Variables

        private Vector3 tintColorAsVector3;

        #endregion
        #region Public Properties

        /// <summary>
        /// The tint color.
        /// </summary>
        public Color TintColor
        {
            get { return new Color(tintColorAsVector3); }
            set { tintColorAsVector3 = value.ToVector3(); }
        }

        /// <summary>
        /// The tint color as a Vector3.
        /// </summary>
        public Vector3 TintColorAsVector3
        {
            get { return tintColorAsVector3; }
            set { tintColorAsVector3 = value; }
        }

        /// <summary>
        /// The tint color as a Vector4.
        /// </summary>
        public Vector4 TintColorAsVector4
        {
            get { return new Vector4(tintColorAsVector3, 1); }
            set { tintColorAsVector3 = new Vector3(value.X, value.Y, value.Z); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessTint class.
        /// </summary>
        public PostProcessTint(GraphicsDevice device,
                              Color color) : 
            base(device)
        {
            effect = new Effects.PostProcessingTintEffect(device);
            TintColor = color;
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["TintColor"].SetValue(tintColorAsVector3);
            base.SetEffectParameters();
        }

        #endregion
    }
}
