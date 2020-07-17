using System.Runtime.CompilerServices;
using RayTracingEngine.MathExtra;
using RayTracingEngine.Models;

[assembly: InternalsVisibleTo("UnitTests")]

namespace RayTracingEngine.Helpers
{
   internal class CameraConverter
   {
      private readonly ScreenParameters _screenParameters;
      private readonly ViewportParameters _viewportParameters;

      private readonly double _halfScreenWidth;
      private readonly double _halfScreenHeight;
      private readonly double _viewportToScreenRatioX;
      private readonly double _viewportToScreenRatioY;

      internal CameraConverter(ScreenParameters screenParameters, ViewportParameters viewportParameters)
      {
         _viewportParameters = viewportParameters;
         _screenParameters = screenParameters;

         _halfScreenWidth = _screenParameters.Width / 2d;
         _halfScreenHeight = _screenParameters.Height / 2d;

         _viewportToScreenRatioX = _viewportParameters.Width / _screenParameters.Width;
         _viewportToScreenRatioY = _viewportParameters.Height / _screenParameters.Height;
      }

      internal Vector3d ScreenToViewport(int x, int y)
      {
         var vX = (-_halfScreenWidth + x) * _viewportToScreenRatioX;
         var vY = (_halfScreenHeight - y) * _viewportToScreenRatioY;

         return new Vector3d(vX, vY, _viewportParameters.ProjectionPlaneDistance);
      }
   }
}