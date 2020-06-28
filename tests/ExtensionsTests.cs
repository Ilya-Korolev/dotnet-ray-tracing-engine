using System.Collections.Generic;
using System.IO;
using RayTracingEngine.Helpers;
using Xunit;

namespace UnitTests
{
   public class ExtensionsTests
   {
      public static IEnumerable<object[]> ReplaceInvalidFileNameCharsData =>
         new List<object[]>
         {
            new object[] { string.Empty, 'a', string.Empty },
            new object[] { "/", 'a', "a" },
            new object[] { "/////", 'q', "qqqqq" },
            new object[] { "s/t/r/i/n/g", '1', "s1t1r1i1n1g" },
            new object[] { string.Join("", Path.GetInvalidFileNameChars()), '_', new string('_', Path.GetInvalidFileNameChars().Length) },
         };

      [Theory]
      [MemberData(nameof(ReplaceInvalidFileNameCharsData))]
      public void Replace_InvalidFileNameChars_ReturnsStringWithReplacedChars(string original, char newChar, string expected)
      {
         var result = original.ReplaceInvalidFileNameChars(newChar);

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> NumberIsBetweenData =>
         new List<object[]>
         {
            new object[] { 0d, 0d, 0d, true },
            new object[] { 0d, -1d, 1d, true },
            new object[] { 0d, 1d, -1d, false },
            new object[] { 7.1d, 8.3d, 10.5d, false },
            new object[] { double.MaxValue, double.MinValue, double.MaxValue, true },
         };

      [Theory]
      [MemberData(nameof(NumberIsBetweenData))]
      public void Check_NumberIsBetweenTwoNumbers_ReturnsTrueIfIsBetween(double number, double lower, double upper, bool expected)
      {
         var isBetween = number.IsBetween(lower, upper);

         Assert.Equal(expected, isBetween);
      }
   }
}