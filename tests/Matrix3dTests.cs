using System;
using System.Collections.Generic;
using RayTracingEngine.MathExtra;
using Xunit;

namespace UnitTests
{
   public class Matrix3dTests
   {
      [Fact]
      public void Create_IdentityMatrix_ReturnsIdentityMatrix()
      {
         var identityMatrix = Matrix3d.Identity();
         var expected = new Matrix3d(1d, 0d, 0d, 0d, 1d, 0d, 0d, 0d, 1d);

         Assert.Equal(expected, identityMatrix);
      }

      public static IEnumerable<object[]> RotationXMatrixData =>
         new List<object[]>
         {
            new object[] { 0d,   new Matrix3d(1d, 0d, 0d, 0d, Math.Cos(0d),             -Math.Sin(0d),             0d, Math.Sin(0d),             Math.Cos(0d)) },
            new object[] { 90d,  new Matrix3d(1d, 0d, 0d, 0d, Math.Cos(Math.PI / 2d),   -Math.Sin(Math.PI / 2d),   0d, Math.Sin(Math.PI / 2d),   Math.Cos(Math.PI / 2d)) },
            new object[] { 180d, new Matrix3d(1d, 0d, 0d, 0d, Math.Cos(Math.PI),        -Math.Sin(Math.PI),        0d, Math.Sin(Math.PI),        Math.Cos(Math.PI)) },
            new object[] { 270d, new Matrix3d(1d, 0d, 0d, 0d, Math.Cos(Math.PI * 1.5d), -Math.Sin(Math.PI * 1.5d), 0d, Math.Sin(Math.PI * 1.5d), Math.Cos(Math.PI * 1.5d)) },
            new object[] { 360d, new Matrix3d(1d, 0d, 0d, 0d, Math.Cos(2d * Math.PI),   -Math.Sin(2d * Math.PI),   0d, Math.Sin(2d * Math.PI),   Math.Cos(2d * Math.PI))  },
         };

      [Theory]
      [MemberData(nameof(RotationXMatrixData))]
      public void Create_RotationXMatrix_ReturnsRotationXMatrix(double degrees, Matrix3d expected)
      {
         var result = Matrix3d.RotationX(degrees);

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> RotationYMatrixData =>
         new List<object[]>
         {
            new object[] { 0d,   new Matrix3d(Math.Cos(0d),             0d, Math.Sin(0d),             0d, 1d, 0d, -Math.Sin(0d),             0d, Math.Cos(0d)) },
            new object[] { 90d,  new Matrix3d(Math.Cos(Math.PI / 2d),   0d, Math.Sin(Math.PI / 2d),   0d, 1d, 0d, -Math.Sin(Math.PI / 2d),   0d, Math.Cos(Math.PI / 2d)) },
            new object[] { 180d, new Matrix3d(Math.Cos(Math.PI),        0d, Math.Sin(Math.PI),        0d, 1d, 0d, -Math.Sin(Math.PI),        0d, Math.Cos(Math.PI)) },
            new object[] { 270d, new Matrix3d(Math.Cos(Math.PI * 1.5d), 0d, Math.Sin(Math.PI * 1.5d), 0d, 1d, 0d, -Math.Sin(Math.PI * 1.5d), 0d, Math.Cos(Math.PI * 1.5d)) },
            new object[] { 360d, new Matrix3d(Math.Cos(2d * Math.PI),   0d, Math.Sin(2d * Math.PI),   0d, 1d, 0d, -Math.Sin(2d * Math.PI),   0d, Math.Cos(2d * Math.PI))  },
         };

      [Theory]
      [MemberData(nameof(RotationYMatrixData))]
      public void Create_RotationYMatrix_ReturnsRotationXMatrix(double degrees, Matrix3d expected)
      {
         var result = Matrix3d.RotationY(degrees);

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> RotationZMatrixData =>
         new List<object[]>
         {
            new object[] { 0d,   new Matrix3d(Math.Cos(0d),             -Math.Sin(0d),             0d, Math.Sin(0d),             Math.Cos(0d),             0d, 0d, 0d, 1d) },
            new object[] { 90d,  new Matrix3d(Math.Cos(Math.PI / 2d),   -Math.Sin(Math.PI / 2d),   0d, Math.Sin(Math.PI / 2d),   Math.Cos(Math.PI / 2d),   0d, 0d, 0d, 1d) },
            new object[] { 180d, new Matrix3d(Math.Cos(Math.PI),        -Math.Sin(Math.PI),        0d, Math.Sin(Math.PI),        Math.Cos(Math.PI),        0d, 0d, 0d, 1d) },
            new object[] { 270d, new Matrix3d(Math.Cos(Math.PI * 1.5d), -Math.Sin(Math.PI * 1.5d), 0d, Math.Sin(Math.PI * 1.5d), Math.Cos(Math.PI * 1.5d), 0d, 0d, 0d, 1d) },
            new object[] { 360d, new Matrix3d(Math.Cos(2d * Math.PI),   -Math.Sin(2d * Math.PI),   0d, Math.Sin(2d * Math.PI),   Math.Cos(2d * Math.PI),   0d, 0d, 0d, 1d) },
         };

      [Theory]
      [MemberData(nameof(RotationZMatrixData))]
      public void Create_RotationZMatrix_ReturnsRotationZMatrix(double degrees, Matrix3d expected)
      {
         var result = Matrix3d.RotationZ(degrees);

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> MatrixMultiplyVectorData =>
         new List<object[]>
         {
            new object[] { new Matrix3d(0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d), new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d) },
            new object[] { new Matrix3d(1d, 0d, 0d, 0d, 1d, 0d, 0d, 0d, 1d), new Vector3d(3d, -5d, 7d), new Vector3d(3d, -5d, 7d) },
            new object[] { new Matrix3d(1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d), new Vector3d(1d, 2d, 3d), new Vector3d(14d, 32d, 50d) },
            new object[] { new Matrix3d(4d, -6d, 9d, 9d, -3d, 4d, -3d, 1d, -6d), new Vector3d(5d, 0d, -3d), new Vector3d(-7d, 33d, 3d) },
            new object[] { new Matrix3d(2d, 4d, 8d, 16d, 32d, 64d, 128d, 256d, 512d), new Vector3d(1024d, 2048d, 4096d), new Vector3d(43008d, 344064d, 2752512d) },
         };

      [Theory]
      [MemberData(nameof(MatrixMultiplyVectorData))]
      public void Multiply_MatrixAndVector_ReturnsMatrixAndVectorMultiplication(Matrix3d left, Vector3d right, Vector3d expected)
      {
         var result = left * right;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> MatrixMultiplyMatrixData =>
         new List<object[]>
         {
            new object[] { new Matrix3d(0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d), new Matrix3d(0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d), new Matrix3d(0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d, 0d) },
            new object[] { new Matrix3d(1d, 0d, 0d, 0d, 1d, 0d, 0d, 0d, 1d), new Matrix3d(1d, 0d, 0d, 0d, 1d, 0d, 0d, 0d, 1d), new Matrix3d(1d, 0d, 0d, 0d, 1d, 0d, 0d, 0d, 1d) },
            new object[] { new Matrix3d(1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d), new Matrix3d(1d, 2d, 3d, 4d, 5d, 6d, 7d, 8d, 9d), new Matrix3d(30d, 36d, 42d, 66d, 81d, 96d, 102d, 126d, 150d) },
            new object[] { new Matrix3d(4d, -6d, 9d, 9d, -3d, 4d, -3d, 1d, -6d), new Matrix3d(14d, 3d, -5d, -7d, 2d, 2d, 9d, 5d, 7d), new Matrix3d(179d, 45d, 31d, 183d, 41d, -23d, -103d, -37d, -25d) },
            new object[] { new Matrix3d(2d, 4d, 8d, 16d, 32d, 64d, 128d, 256d, 512d), new Matrix3d(2d, 4d, 8d, 16d, 32d, 64d, 128d, 256d, 512d), new Matrix3d(1092d, 2184d, 4368d, 8736d, 17472d, 34944d, 69888d, 139776d, 279552d) },
         };

      [Theory]
      [MemberData(nameof(MatrixMultiplyMatrixData))]
      public void Multiply_MatrixAndMatrix_ReturnsMatrixAndMatrixMultiplication(Matrix3d left, Matrix3d right, Matrix3d expected)
      {
         var result = left * right;

         Assert.Equal(expected, result);
      }
   }
}