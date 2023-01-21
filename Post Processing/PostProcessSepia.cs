using Microsoft.Xna.Framework.Graphics;

namespace MerjTek.MonoGame.PostProcessing
{
    /// <summary>
    /// A class that performs a Sepia Post Process.
    /// </summary>
    public class PostProcessSepia: PostProcessBase
    {
        /// <summary>
        /// Initialize an instance of the PostProcessSepia class.
        /// </summary>
        /// <param name="device"></param>
        public PostProcessSepia(GraphicsDevice device) : 
            base(device)
        {
            // NOTE: Everything is done in the base class
            effect = new Effects.PostProcessingSepiaEffect(device);
        }
    }
}
