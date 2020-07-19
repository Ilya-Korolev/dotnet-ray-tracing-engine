using System;
using System.Collections.Generic;
using RayTracingEngine.MathExtra;
using Xunit;

namespace UnitTests
{
   public class Vector3dTests
   {
      public static IEnumerable<object[]> VectorLengthData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), 0d },
            new object[] { new Vector3d(0d, 0d, 12d), 12d },
            new object[] { new Vector3d(-2d, 4d, 4d), 6d },
            new object[] { new Vector3d(3d, -3d, 10d), Math.Sqrt(118d) },
            new object[] { new Vector3d(10d, -100d, 1000d), Math.Sqrt(1010100d) },
        };

      [Theory]
      [MemberData(nameof(VectorLengthData))]
      public void Get_VectorLength_ReturnsVectorLength(Vector3d self, double expected)
      {
         var result = self.Length;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> VectorAddVectorData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d) },
            new object[] { new Vector3d(3d, 2d, -1d), new Vector3d(0d, 0d, 0d), new Vector3d(3d, 2d, -1d) },
            new object[] { new Vector3d(0d, 0d, 0d), new Vector3d(6d, -7d, 2d), new Vector3d(6d, -7d, 2d) },
            new object[] { new Vector3d(3d, -3d, 10d), new Vector3d(-4d, 34d, -3d), new Vector3d(-1d, 31d, 7d) },
            new object[] { new Vector3d(double.MinValue, double.MinValue, double.MinValue), new Vector3d(double.MaxValue, double.MaxValue, double.MaxValue), new Vector3d(0d, 0d, 0d) },
        };

      [Theory]
      [MemberData(nameof(VectorAddVectorData))]
      public void Add_TwoVectors_ReturnsSumOfVectors(Vector3d left, Vector3d right, Vector3d expected)
      {
         var result = left + right;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> VectorSubtractVectorData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d) },
            new object[] { new Vector3d(3d, 2d, -1d), new Vector3d(0d, 0d, 0d), new Vector3d(3d, 2d, -1d) },
            new object[] { new Vector3d(0d, 0d, 0d), new Vector3d(6d, -7d, 2d), new Vector3d(-6d, 7d, -2d) },
            new object[] { new Vector3d(3d, -3d, 10d), new Vector3d(-4d, 34d, -3d), new Vector3d(7d, -37d, 13d) },
            new object[] { new Vector3d(double.MaxValue, double.MaxValue, double.MaxValue), new Vector3d(double.MaxValue, double.MaxValue, double.MaxValue), new Vector3d(0d, 0d, 0d) },
        };

      [Theory]
      [MemberData(nameof(VectorSubtractVectorData))]
      public void Subtract_TwoVectors_ReturnsDifferenceOfVectors(Vector3d left, Vector3d right, Vector3d expected)
      {
         var result = left - right;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> VectorDotVectorData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d), 0d },
            new object[] { new Vector3d(3d, 2d, 1d), new Vector3d(-1d, 2d, 3d), 4d },
            new object[] { new Vector3d(6d, -1d, 3d), new Vector3d(4d, 7d, -8d), -7d },
            new object[] { new Vector3d(0d, 0d, 0d), new Vector3d(3d, -3d, 3d), 0d },
            new object[] { new Vector3d(-3d, -5d, -3d), new Vector3d(-7d, -4d, -1d), 44d },
        };

      [Theory]
      [MemberData(nameof(VectorDotVectorData))]
      public void DotProduct_TwoVectors_ReturnsDotProductionOfVectors(Vector3d left, Vector3d right, double expected)
      {
         var result = left * right;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> VectorAddDoubleData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), 0d, new Vector3d(0d, 0d, 0d) },
            new object[] { new Vector3d(3d, 2d, -1d), 0d, new Vector3d(3d, 2d, -1d) },
            new object[] { new Vector3d(0d, 0d, 0d), -3d, new Vector3d(-3d, -3d, -3d) },
            new object[] { new Vector3d(3d, -3d, 10d), 7d, new Vector3d(10d, 4d, 17d) },
            new object[] { new Vector3d(double.MinValue, double.MinValue, double.MinValue), double.MaxValue, new Vector3d(0d, 0d, 0d) },
        };

      [Theory]
      [MemberData(nameof(VectorAddDoubleData))]
      public void Add_VectorAndDouble_ReturnsSumOfVectorAndDouble(Vector3d left, double right, Vector3d expected)
      {
         var result = left + right;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> DoubleAddVectorData =>
        new List<object[]>
        {
            new object[] { 0d, new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d) },
            new object[] { 0d, new Vector3d(3d, 2d, -1d), new Vector3d(3d, 2d, -1d) },
            new object[] { -3d, new Vector3d(0d, 0d, 0d), new Vector3d(-3d, -3d, -3d) },
            new object[] { 7d, new Vector3d(3d, -3d, 10d), new Vector3d(10d, 4d, 17d) },
            new object[] { double.MaxValue, new Vector3d(double.MinValue, double.MinValue, double.MinValue), new Vector3d(0d, 0d, 0d) },
        };

      [Theory]
      [MemberData(nameof(DoubleAddVectorData))]
      public void Add_DoubleAndVector_ReturnsSumOfDoubleAndVector(double left, Vector3d right, Vector3d expected)
      {
         var result = left + right;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> VectorSubtractDoubleData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), 0d, new Vector3d(0d, 0d, 0d) },
            new object[] { new Vector3d(3d, 2d, -1d), 0d, new Vector3d(3d, 2d, -1d) },
            new object[] { new Vector3d(0d, 0d, 0d), -3d, new Vector3d(3d, 3d, 3d) },
            new object[] { new Vector3d(3d, -3d, 10d), 7d, new Vector3d(-4d, -10d, 3d) },
            new object[] { new Vector3d(double.MaxValue, double.MaxValue, double.MaxValue), double.MaxValue, new Vector3d(0d, 0d, 0d) },
        };

      [Theory]
      [MemberData(nameof(VectorSubtractDoubleData))]
      public void Subtract_VectorAndDouble_ReturnsDifferenceOfVectorAndDouble(Vector3d left, double right, Vector3d expected)
      {
         var result = left - right;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> VectorMultiplyDoubleData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), 0d, new Vector3d(0d, 0d, 0d) },
            new object[] { new Vector3d(3d, 2d, -1d), 0d, new Vector3d(0d, 0d, 0d) },
            new object[] { new Vector3d(4d, -3d, 0d), -3d, new Vector3d(-12d, 9d, 0d) },
            new object[] { new Vector3d(3d, -3d, 10d), 7d, new Vector3d(21d, -21d, 70d) },
            new object[] { new Vector3d(double.MaxValue, double.MaxValue, double.MaxValue), 0d, new Vector3d(0d, 0d, 0d) },
        };

      [Theory]
      [MemberData(nameof(VectorMultiplyDoubleData))]
      public void Multiply_VectorAndDouble_ReturnsVectorScalarMultiplication(Vector3d left, double right, Vector3d expected)
      {
         var result = left * right;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> DoubleMultiplyVectorData =>
        new List<object[]>
        {
            new object[] { 0d, new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d) },
            new object[] { 0d, new Vector3d(3d, 2d, -1d), new Vector3d(0d, 0d, 0d) },
            new object[] { -3d, new Vector3d(4d, -3d, 0d), new Vector3d(-12d, 9d, 0d) },
            new object[] { 7d, new Vector3d(3d, -3d, 10d), new Vector3d(21d, -21d, 70d) },
            new object[] { 0d, new Vector3d(double.MaxValue, double.MaxValue, double.MaxValue), new Vector3d(0d, 0d, 0d) },
        };

      [Theory]
      [MemberData(nameof(DoubleMultiplyVectorData))]
      public void Multiply_DoubleAndVector_ReturnsVectorScalarMultiplication(double left, Vector3d right, Vector3d expected)
      {
         var result = left * right;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> VectorDivideDoubleData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), 17d, new Vector3d(0d, 0d, 0d) },
            new object[] { new Vector3d(3d, 2d, -1d), 1d, new Vector3d(3d, 2d, -1d) },
            new object[] { new Vector3d(6d, -30d, 0d), -3d, new Vector3d(-2d, 10d, 0d) },
            new object[] { new Vector3d(3d, -3d, 10d), 0.1d, new Vector3d(30d, -30d, 100d) },
            new object[] { new Vector3d(double.MaxValue, double.MaxValue, double.MaxValue), 1d, new Vector3d(double.MaxValue, double.MaxValue, double.MaxValue) },
        };

      [Theory]
      [MemberData(nameof(VectorDivideDoubleData))]
      public void Divide_DoubleAndVector_ReturnsVectorScalarDivision(Vector3d left, double right, Vector3d expected)
      {
         var result = left / right;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> NegateVectorData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d) },
            new object[] { new Vector3d(1d, 1d, 1d), new Vector3d(-1d, -1d, -1d) },
            new object[] { new Vector3d(6d, -30d, 0d), new Vector3d(-6d, 30d, 0d) },
            new object[] { new Vector3d(3d, -3d, 10d), new Vector3d(-3d, 3d, -10d) },
            new object[] { new Vector3d(double.MaxValue, double.MaxValue, double.MaxValue), new Vector3d(-double.MaxValue, -double.MaxValue, -double.MaxValue) },
        };

      [Theory]
      [MemberData(nameof(NegateVectorData))]
      public void Negate_Vector_ReturnsOppositeVector(Vector3d self, Vector3d expected)
      {
         var result = -self;

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> NormalizeVectorData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 1d), 1d },
            new object[] { new Vector3d(1d, 1d, 1d), 1d },
            new object[] { new Vector3d(-2d, 4d, 4d), 1d },
            new object[] { new Vector3d(3d, -3d, 10d), 1d },
            new object[] { new Vector3d(10d, -100d, 1000d), 1d },
        };

      [Theory]
      [MemberData(nameof(NormalizeVectorData))]
      public void Normalize_Vector_ReturnsUnitVector(Vector3d self, double expected)
      {
         var result = self.Normalized();

         Assert.Equal(expected, result.Length);
      }

      public static IEnumerable<object[]> ReflectVectorData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d) },
            new object[] { new Vector3d(1d, 1d, 1d), new Vector3d(0d, 0d, 0d), new Vector3d(-1d, -1d, -1d) },
            new object[] { new Vector3d(1d, 1d, 1d), new Vector3d(1d, 1d, 1d), new Vector3d(5d, 5d, 5d) },
            new object[] { new Vector3d(3d, 7d, 10d), new Vector3d(2d, -3d, -1d), new Vector3d(-103d, 143d, 40d) },
            new object[] { new Vector3d(double.MaxValue, double.MaxValue, double.MaxValue), new Vector3d(0d, 0d, 0d), new Vector3d(-double.MaxValue, -double.MaxValue, -double.MaxValue) },
        };

      [Theory]
      [MemberData(nameof(ReflectVectorData))]
      public void Reflect_VectorAcrossNormal_ReturnsReflectedVector(Vector3d self, Vector3d normal, Vector3d expected)
      {
         var result = self.Reflect(normal);

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> ConvertVector3dToVector2dData =>
        new List<object[]>
        {
            new object[] { new Vector3d(0d, 0d, 0d), new Vector2d(0d, 0d) },
            new object[] { new Vector3d(3d, 2d, -1d), new Vector2d(3d, 2d) },
            new object[] { new Vector3d(6d, -7d, 2d), new Vector2d(6d, -7d) },
            new object[] { new Vector3d(3d, -3d, 10d), new Vector2d(3d, -3d) },
            new object[] { new Vector3d(double.MinValue, double.MinValue, double.MinValue), new Vector2d(double.MinValue, double.MinValue) },
        };

      [Theory]
      [MemberData(nameof(ConvertVector3dToVector2dData))]
      public void Convert_Vector3dToVector2d_ReturnsVector2d(Vector3d self, Vector2d expected)
      {
         var result = (Vector2d)self;

         Assert.Equal(expected, result);
      }
   }
}