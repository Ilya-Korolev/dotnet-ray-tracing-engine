using System;
using System.Collections.Generic;
using RayTracingEngine.ImageProcessing;
using Xunit;

namespace UnitTests
{
   public class ColorTests
   {
      public static IEnumerable<object[]> ColorFromDoubleValuesData =>
         new List<object[]>
         {
            new object[] { 0d, 0d, 0d, 0d, new Color(0d, 0d, 0d, 0d) },
            new object[] { 1d, 1d, 1d, 1d, new Color(1d, 1d, 1d, 1d) },
            new object[] { 0.2d, 0.7d, -0.3d, 1.3d, new Color(0.2d, 0.7d, 0d, 1d) },
            new object[] { double.MinValue, double.MinValue, double.MinValue, double.MinValue, new Color(0d, 0d, 0d, 0d) },
            new object[] { double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, new Color(1d, 1d, 1d, 1d) },

         };

      [Theory]
      [MemberData(nameof(ColorFromDoubleValuesData))]
      public void Create_ColorFromDoubleValues_ReturnsColor(double r, double g, double b, double a, Color expected)
      {
         var result = new Color(r, g, b, a);

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> ColorFromHexData =>
         new List<object[]>
         {
            new object[] { 0u, new Color(0d, 0d, 0d, 0d) },
            new object[] { 0x00000000, new Color(0d, 0d, 0d, 0d) },
            new object[] { 0xFFFFFFFF, new Color(1d, 1d, 1d, 1d) },
            new object[] { 0xE43F5ADA, new Color(0.8941176470588236d, 0.24705882352941178d, 0.35294117647058826d, 0.8549019607843137d) },
            new object[] { 0xFF, new Color(0d, 0d, 0d, 1d) },
         };

      [Theory]
      [MemberData(nameof(ColorFromHexData))]
      public void Create_ColorFromHex_ReturnsColor(UInt32 hex, Color expected)
      {
         var result = new Color(hex);

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> ColorWithIntensityData =>
         new List<object[]>
         {
            new object[] { new Color(0d, 0d, 0d, 0d), 1d, new Color(0d, 0d, 0d, 0d) },
            new object[] { new Color(1d, 1d, 1d, 1d), 0d, new Color(0d, 0d, 0d, 1d)  },
            new object[] { new Color(1d, 1d, 1d, 1d), 1d, new Color(1d, 1d, 1d, 1d) },
            new object[] { new Color(0.3d, 1d, 0.4d, 1d), 0.6d, new Color(0.18d, 0.6d, 0.24d, 1d) },
            new object[] { new Color(1d, 1d, 1d, 1d), double.MaxValue, new Color(1d, 1d, 1d, 1d) },
            new object[] { new Color(1d, 1d, 1d, 1d), double.MinValue, new Color(0d, 0d, 0d, 1d)},
         };

      [Theory]
      [MemberData(nameof(ColorWithIntensityData))]
      public void Add_IntensityToColor_ReturnsColorWithIntensity(Color color, double intensity, Color expected)
      {
         var result = color.WithIntensity(intensity);

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> ColorAddColorData =>
         new List<object[]>
         {
            new object[] { new Color(0d, 0d, 0d, 0d), new Color(1d, 1d, 1d, 1d), new Color(1d, 1d, 1d, 1d) },
            new object[] { new Color(0d, 0d, 0d, 0d), new Color(0d, 0d, 0d, 0d), new Color(0d, 0d, 0d, 0d)  },
            new object[] { new Color(1d, 1d, 0d, 0d), new Color(1d, 0d, 1d, 0d), new Color(1d, 1d, 1d, 0d) },
            new object[] { new Color(0.3d, 1d, 0.4d, 0.4d), new Color(0.2d, 0.3d, 0.3d, 0.5d), new Color(0.5d, 1d, 0.7d, 0.9d) },
            new object[] { new Color(double.MaxValue, double.MaxValue, double.MinValue, double.MaxValue), new Color(double.MinValue, 0d, 0d, double.MaxValue), new Color(1d, 1d, 0d, 1d)},
         };

      [Theory]
      [MemberData(nameof(ColorAddColorData))]
      public void Add_TwoColors_ReturnsSumOfColors(Color left, Color right, Color expected)
      {
         var result = left + right;

         Assert.Equal(expected, result);
      }
   }
}