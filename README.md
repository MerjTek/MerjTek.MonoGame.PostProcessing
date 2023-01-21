# MerjTek.MonoGame.PostProcessing

MerjTek.MonoGame.PostProcessing is a screen post processing library that works on Windows with DirectX and OpenGL.


## Usage Sample

        ...
        // Add a reference to the namespace
        using MerjTek.MonoGame.PostProcessing;
        ...

        ... // In Initialize or LoadContent
        // Create a post processing manager
        _postProcessingManager = new PostProcessingManager(device);

        // Create a HashSet for different post processors 
        // You can create more than 1 if desired
        _postProcesses = new HashSet<PostProcessBase>();
        ...

        ... // In Draw
        _postProcessingManager.CaptureScreen();

        // Add drawing code here...

        _postProcessingManager.UncaptureAndExecute(_postProcesses);
        ...


## Caveats

* You must use the HiDef profile. The shaders won't work with the Reach profile

        _graphics = new GraphicsDeviceManager(this);
        _graphics.GraphicsProfile = GraphicsProfile.HiDef;


## Building

* The Solution uses Visual Studio 2022
* The nuget for DirectX after building contains a dependency on Monogame.Framework.DesktopGL. I have to use the .nupkg editing tool to correct the dependency to Monogame.Framework.DirectX.


## Future Post Processor Ideas (Not in any order)

* Fog (3D)
* Depth of Field (3D)
* Poisson Disc Blur
* Motion Blur
* Lens Flare
* Color Correction and Clamping
* Tone Mapping
* Ambient Occlusion	
* Bloom
* Crepuscular (God) Rays
* Heat Haze
* FXAA
* MLAA (Morphological Anti-Aliasing)
* SMAA (Subpixel Morphological Anti-Aliasing)
* Gamma Correction
* Color Grading (multiple shaders?)
* Feel free to suggest others


## License

The MerjTek.MonoGame.PostProcessing project is under the [MIT License](https://github.com/MerjTek/MerjTek.MonoGame.PostProcessing/blob/main/LICENSE).
