using System;
using System.Diagnostics;
using RayTracingEngine.Helpers;
using RayTracingEngine.ImageProcessing;
using RayTracingEngine.Models;

namespace RayTracingEngine.Core
{
   public class Engine
   {
      private readonly OutputParameters _outputParameters;
      private readonly ScreenParameters _screenParameters;
      private readonly ViewportParameters _viewportParameters;
      private readonly RenderParameters _renderParameters;

      private readonly CameraConverter _cameraConverter;
      private readonly IDrawing _drawing;

      public Engine(OutputParameters outputParameters, ScreenParameters screenParameters, ViewportParameters viewportParameters, RenderParameters renderParameters)
      {
         _screenParameters = screenParameters;
         _outputParameters = outputParameters;
         _viewportParameters = viewportParameters;
         _renderParameters = renderParameters;

         _cameraConverter = new CameraConverter(_screenParameters, _viewportParameters);
         _drawing = new ImageSharpDrawing(_screenParameters.Width, _screenParameters.Height);
      }

      public void Render(Scene scene)
      {
         var stopwatch = Stopwatch.StartNew();

         RayTracer rayTracer = new RayTracer(scene, _renderParameters);

         for (var y = 0; y < _screenParameters.Height; ++y)
         {
            for (var x = 0; x < _screenParameters.Width; ++x)
            {
               var direction = _cameraConverter.ScreenToViewport(x, y);
               var ray = new Ray(_viewportParameters.Origin, direction);
               var pixelColor = rayTracer.Trace(ray);

               _drawing.SetPixel(x, y, pixelColor);
            }
         }

         _drawing.Save(_outputParameters.FilePath);

         Console.WriteLine($"elapsed {stopwatch.ElapsedMilliseconds / 1000d} sec");
      }
   }
}