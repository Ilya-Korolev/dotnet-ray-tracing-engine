using System.Collections.Generic;
using RayTracingEngine.Helpers;
using RayTracingEngine.MathExtra;
using RayTracingEngine.Models;
using Xunit;

namespace UnitTests
{
   public class CameraConverterTests
   {
      private static readonly ScreenParameters _screenParameters = new ScreenParameters { Height = 1080, Width = 1920 };
      private static readonly ViewportParameters _viewportParameters = new ViewportParameters { Height = 1d, Width = 1d, ProjectionPlaneDistance = 15d };

      public static IEnumerable<object[]> ScreenPointToViewportPointData =>
         new List<object[]>
         {
            new object[] {
               0,
               0,
               new Vector3d
               {
                  X = -_viewportParameters.Width / 2d,
                  Y = _viewportParameters.Height / 2d,
                  Z = _viewportParameters.ProjectionPlaneDistance
               }
            },
            new object[]
            {
               _screenParameters.Width,
               0,
               new Vector3d
               {
                  X = _viewportParameters.Width / 2d,
                  Y = _viewportParameters.Height / 2d,
                  Z = _viewportParameters.ProjectionPlaneDistance
               }
            },
            new object[]
            {
               _screenParameters.Width / 2,
               _screenParameters.Height / 2,
               new Vector3d
               {
                  X = 0d,
                  Y = 0d,
                  Z = _viewportParameters.ProjectionPlaneDistance
               }
            },
            new object[] {
               0,
               _screenParameters.Height,
               new Vector3d
               {
                  X = -_viewportParameters.Width / 2d,
                  Y = -_viewportParameters.Height / 2d,
                  Z = _viewportParameters.ProjectionPlaneDistance
               }
            },
            new object[]
            {
               _screenParameters.Width,
               _screenParameters.Height,
               new Vector3d
               {
                  X = _viewportParameters.Width / 2d,
                  Y = -_viewportParameters.Height / 2d,
                  Z = _viewportParameters.ProjectionPlaneDistance
               }
            },

         };

      [Theory]
      [MemberData(nameof(ScreenPointToViewportPointData))]
      public void Convert_ScreenPointToViewportPoint_ReturnsViewportVector3d(int screenX, int screenY, Vector3d expected)
      {
         var cameraConverter = new CameraConverter(_screenParameters, _viewportParameters);

         var viewportPoint = cameraConverter.ScreenToViewport(screenX, screenY);

         Assert.Equal(expected, viewportPoint);
      }
   }
}