using System.Collections.Generic;
using RayTracingEngine.MathExtra;
using Xunit;

namespace UnitTests
{
   public class Vector2dTests
   {
      public static IEnumerable<object[]> ConvertVector2dToVector3dData =>
         new List<object[]>
         {
            new object[] { new Vector2d(0d, 0d), new Vector3d(0d, 0d, 0d) },
            new object[] { new Vector2d(3d, 2d), new Vector3d(3d, 2d, 0d) },
            new object[] { new Vector2d(6d, -7d), new Vector3d(6d, -7d, 0d) },
            new object[] { new Vector2d(3d, -3d), new Vector3d(3d, -3d, 0d) },
            new object[] { new Vector2d(double.MinValue, double.MinValue), new Vector3d(double.MinValue, double.MinValue, 0d) },
         };

      [Theory]
      [MemberData(nameof(ConvertVector2dToVector3dData))]
      public void Convert_Vector2dToVector3d_ReturnsVector3d(Vector2d self, Vector3d expected)
      {
         var result = (Vector3d)self;

         Assert.Equal(expected, result);
      }
   }
}