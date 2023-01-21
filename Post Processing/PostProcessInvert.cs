using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs an Invert Post Process.
    /// </summary>
    public class PostProcessInvert: PostProcessBase
    {
        /// <summary>
        /// Initializes an instance of the PostProcessInvert class.
        /// </summary>
        public PostProcessInvert(GraphicsDevice device) : 
            base(device)
        {
            // NOTE: Everything is done in the base class
            effect = new Effects.PostProcessingInvertEffect(device);
        }
    }
}
