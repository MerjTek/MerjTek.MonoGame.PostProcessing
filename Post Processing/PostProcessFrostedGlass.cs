using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Frosted Glass Post Process.
    /// </summary>
    public class PostProcessFrostedGlass : PostProcessBase
    {
        #region Private Variables

        float randomFactor;
        float randomScale;
        Vector2 v1;
        Vector2 v2;

        #endregion
        #region Public Properties

        /// <summary>
        /// The random factor. Defaults to 0.05f.
        /// </summary>
        public float RandomFactor
        {
            get { return randomFactor; }
            set { randomFactor = value; }
        }

        /// <summary>
        /// The random scale. Defaults to 5.1f.
        /// </summary>
        public float RandomScale
        {
            get { return randomScale; }
            set { randomScale = value; }
        }

        /// <summary>
        /// Vector 1.
        /// </summary>
        public Vector2 V1
        {
            get { return v1; }
            set { v1 = value; }
        }

        /// <summary>
        /// Vector 2.
        /// </summary>
        public Vector2 V2
        {
            get { return v2; }
            set { v2 = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of the PostProcessFrostedGlass class.
        /// </summary>
        public PostProcessFrostedGlass(GraphicsDevice device,
                                      Vector2 one, 
                                      Vector2 two, 
                                      float factor = 0.05f, 
                                      float scale = 5.1f) : 
            base(device)
        {
            effect = new Effects.PostProcessingFrostedGlassEffect(device);
            randomFactor = factor;
            randomScale = scale;
            v1 = one; // Default new Vector2 (92, 80);
            v2 = two; // Default new Vector2 (41, 62);
        }

        #endregion

        #region SetEffectParameters (Overridable)

        /// <summary>
        /// Sets the effect parameters for the post processor.
        /// </summary>
        public override void SetEffectParameters()
        {
            effect.Parameters["RandomFactor"].SetValue(randomFactor);
            effect.Parameters["RandomScale"].SetValue(randomScale);
            effect.Parameters["V1"].SetValue(v1);
            effect.Parameters["V2"].SetValue(v2);
            base.SetEffectParameters();
        }

        #endregion
    }
}
