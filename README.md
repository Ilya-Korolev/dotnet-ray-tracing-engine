# .NET RayTracingEngine

<div align="center">

[![NuGet](https://img.shields.io/nuget/v/RayTracingEngine.svg?style=flat-square)](https://www.nuget.org/packages/RayTracingEngine/)
[![GitHub](https://img.shields.io/github/license/Ilya-Korolev/dotnet-ray-tracing-engine?style=flat-square)](https://github.com/Ilya-Korolev/dotnet-ray-tracing-engine/blob/master/LICENSE.md)

</div>

.NET RayTracingEngine is a simple CPU ray tracing library.

## Installation

Before you can use .Net RayTracingEngine in your application, you need to add the NuGet package:

```console
dotnet add package RayTracingEngine
```

## Usage

```c#
// Create a Scene instance
var scene = new Scene
{
  Objects = new List<SceneObject>
  {
     new Sphere
     {
        Center = new Vector3d(0d, 0d, 3d),
        Radius = 1d,
        Material = new Material
        {
           Color = new Color(0x770000FF),
           SpecularExponent = -1d,
           ReflectiveCoefficient = 0.0d,
        }
     },               
     new Sphere
     {
        Center = new Vector3d(-2.5d, 6d, 6d),
        Radius = 3d,
        Material = new Material
        {
           Color = new Color(0xFFFFFFFF),
           SpecularExponent = 10d,
           ReflectiveCoefficient = 0.6d,
        }
     },
  },
  Lights = new List<ILight>
  {
     new PointLight
     {
        Intensity = 0.7d,
        Position = new Vector3d(0d, 5d, 0d)
     }
  }
};

// Create a Engine instance
 var engine = new Engine(
    new ScreenParameters
    {
       Width = 1920,
       Height = 1080
    },
    new ViewportParameters
    {
       Width = 2d,
       Height = 1d,
       ProjectionPlaneDistance = 1d,
       CameraRotation = Matrix3d.RotationZ(-45d)
    },
    new RenderParameters
    {
       ReflectionDepth = 7
    }
 );

// Render an image
var drawing = engine.Render(scene);

// Save the image
drawing.Save("result.png");
```

### Result

![example_result](https://user-images.githubusercontent.com/39079821/89823932-f7411a80-db5a-11ea-8304-73c0d1485eef.png)

## License
[MIT](https://choosealicense.com/licenses/mit/)