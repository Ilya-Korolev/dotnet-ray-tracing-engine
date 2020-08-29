using System.Threading.Tasks;
using RayTracingEngine.Helpers;
using RayTracingEngine.ImageProcessing;
using RayTracingEngine.Models;

namespace RayTracingEngine.Core
{
   public class Engine
   {
      private readonly ScreenParameters _screenParameters;
      private readonly ViewportParameters _viewportParameters;
      private readonly RenderParameters _renderParameters;

      private readonly CameraConverter _cameraConverter;

      public Engine(ScreenParameters screenParameters, ViewportParameters viewportParameters, RenderParameters renderParameters)
      {
         _screenParameters = screenParameters;
         _viewportParameters = viewportParameters;
         _renderParameters = renderParameters;

         _cameraConverter = new CameraConverter(_screenParameters, _viewportParameters);
      }

      public IDrawing Render(Scene scene)
      {
         var drawing = new ImageSharpDrawing(_screenParameters.Width, _screenParameters.Height);
         var rayTracer = new RayTracer(scene, _renderParameters);

         Parallel.For(0, _screenParameters.Height, (y) =>
         {
            for (var x = 0; x < _screenParameters.Width; ++x)
            {
               var direction = _viewportParameters.CameraRotation * _cameraConverter.ScreenToViewport(x, y);
               var ray = new Ray(_viewportParameters.CameraPosition, direction);
               var pixelColor = rayTracer.Trace(ray);

               drawing.SetPixel(x, y, pixelColor);
            }
         });

         return drawing;
      }
   }
}