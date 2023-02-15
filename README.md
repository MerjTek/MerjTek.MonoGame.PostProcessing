
# MerjTek.MonoGame.PostProcessing

MerjTek.MonoGame.PostProcessing is a screen post processing library that works on Windows with DirectX and OpenGL.


## Nuget Packages
-[ MerjTek.MonoGame.PostProcessing.DirectX ](https://www.nuget.org/packages/MerjTek.MonoGame.PostProcessing.DirectX) v1.0.1
-[ MerjTek.MonoGame.PostProcessing.OpenGL ](https://www.nuget.org/packages/MerjTek.MonoGame.PostProcessing.OpenGL) v1.0.1


## Currently Implemented

|   | Post Pocessors |   |
| :----: | :----:  | :----:  |
| Circle Lens  | Contrast | Cross Stiching |
| Crosshatching | Double Vision | Edge Detection |
| Film Grain | Frosted Glass | Frosted Glass (Noise) |
| Gaussian Blur | Grayscale | Invert |
| Monochrome Edge Detection | Night Vision | Pixelate |
| Scanline |  Sepia | Tint |


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

        // Add post processors in any order
        _postProcesses.Add(new PostProcessGrayscale(device));
        _postProcesses.Add(new PostProcessInvert(device));
        _postProcesses.Add(new PostProcessCircleLens(device, new Vector2(0.45f, 0.38f));
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


## Future Ideas (Not in any order)

|   | Post Processors |   |
| :----: | :----:  | :----:  |
| Fog | Depth of Field | Poisson Disc Blur |
| Motion Blur | Lens Flare | Color Correction |
| Tone Mapping | Ambient Occlusion | Bloom |
| Crepuscular (God) Rays | Heat Haze | FXAA |
| Gamma Correction | MLAA (Morphological Anti-Aliasing) |  Color Grading |
|   | SMAA (Subpixel Morphological Anti-Aliasing) |   | 

* Feel free to suggest others


## License

The MerjTek.MonoGame.PostProcessing project is under the [MIT License](https://github.com/MerjTek/MerjTek.MonoGame.PostProcessing/blob/main/LICENSE).
