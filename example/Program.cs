using System.Collections.Generic;
using RayTracingEngine.Core;
using RayTracingEngine.Helpers;
using RayTracingEngine.ImageProcessing;
using RayTracingEngine.MathExtra;
using RayTracingEngine.Models;

namespace Example
{
   class Program
   {
      private static Engine _engine = new Engine(
         new ScreenParameters
         {
            Width = 1920,
            Height = 1080
         },
         new ViewportParameters
         {
            Width = 2d,
            Height = 1d,
            ProjectionPlaneDistance = 1d
         },
         new RenderParameters
         {
            ReflectionDepth = 7
         }
      );

      private static Scene _scene = new Scene
      {
         Objects = new List<SceneObject>
            {
               new Sphere
               {
                  Center = new Vector3d(-1d, -1.5d, 6d),
                  Radius = 0.3d,
                  Material = new Material
                  {
                     Color = new Color(0x543864FF),
                     SpecularExponent = 70d,
                     ReflectiveCoefficient = 0.3d,
                  }
               },
               new Sphere
               {
                  Center = new Vector3d(-1.5d, -1.5d, 4.5d),
                  Radius = 0.5d,
                  Material = new Material
                  {
                     Color = new Color(0xFF6363FF),
                     SpecularExponent = 10d,
                     ReflectiveCoefficient = 0.1d,
                  }
               },
               new Sphere
               {
                  Center = new Vector3d(1.7d, -1.3d, 4.2d),
                  Radius = 0.7d,
                  Material = new Material
                  {
                     Color = new Color(0x941E42FF),
                     SpecularExponent = 10d,
                     ReflectiveCoefficient = 0.2d,
                  }
               },
               new Sphere
               {
                  Center = new Vector3d(0.5d, -1d, 7d),
                  Radius = 0.8d,
                  Material = new Material
                  {
                     Color = new Color(0x0E31C7FF),
                     SpecularExponent = 200d,
                     ReflectiveCoefficient = 0.7d,
                  }
               },
               new Sphere
               {
                  Center = new Vector3d(-3d, 1d, 11d),
                  Radius = 3d,
                  Material = new Material
                  {
                     Color = new Color(0x90A9CDFF),
                     SpecularExponent = 1000d,
                     ReflectiveCoefficient = 0.5d,
                  }
               },
               new Sphere
               {
                  Center = new Vector3d(3d, 0d, 10d),
                  Radius = 2d,
                  Material = new Material
                  {
                     Color = new Color(0xE2E611FF),
                     SpecularExponent = 50d,
                     ReflectiveCoefficient = 0.2d,
                  }
               },
               new Sphere
               {
                  Center = new Vector3d(0d, -5002d, 0d),
                  Radius = 5000d,
                  Material = new Material
                  {
                     Color = new Color(0x1F4068FF),
                     SpecularExponent = -1d,
                     ReflectiveCoefficient = 0d
                  }
               },
            },
         Lights = new List<ILight>
            {
               new AmbientLight
               {
                  Intensity = 0.1d
               },
               new PointLight
               {
                  Intensity = 0.5d,
                  Position = new Vector3d(0d, 2d, 0d)
               },
               new DirectionalLight
               {
                  Intensity = 0.3d,
                  Direction = new Vector3d(-4d, -4d, -3d),
               }
            }
      };

      static void Main(string[] args)
      {
         var drawing = _engine.Render(_scene);

         var filePath = OutputPath.Build("render", @"renders\", ImageFormat.Png, true);

         drawing.Save(filePath);
      }
   }
}
