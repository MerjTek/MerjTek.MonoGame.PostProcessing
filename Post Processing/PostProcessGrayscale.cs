using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Grayscale Post Process.
    /// </summary>
    public class PostProcessGrayscale: PostProcessBase
    {
        /// <summary>
        /// Initializes an instance of the PostProcessGrayscale class.
        /// </summary>
        public PostProcessGrayscale(GraphicsDevice device) : 
            base(device)
        {
            // NOTE: Everything is done in the base class
            effect = new Effects.PostProcessingGrayscaleEffect(device);
        }
    }
}
