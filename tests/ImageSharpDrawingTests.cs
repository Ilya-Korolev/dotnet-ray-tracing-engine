using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using RayTracingEngine.ImageProcessing;
using Xunit;

namespace UnitTests
{
   public class ImageSharpDrawingTests
   {
      [Fact]
      public void Get_NewDrawingPixelColor_ReturnsDefaultColor()
      {
         using var drawing = new ImageSharpDrawing(1, 1);
         var color = drawing.GetPixel(0, 0);
         var expected = default(Color);

         Assert.Equal(expected, color);
      }

      public static IEnumerable<object[]> GetSetColorData =>
         new List<object[]>
         {
            new object[] { 10, 10, 0, 0, new Color(0x00000000) },
            new object[] { 10, 10, 9, 9, new Color(0xFFFFFFFF) },
            new object[] { 10, 10, 3, 4, new Color(0x38A3B1FF) },
            new object[] { 10, 10, 8, 0, new Color(0xFEDD2631) },
            new object[] { 10, 10, 2, 7, new Color(0xC2FE1100) },
         };

      [Theory]
      [MemberData(nameof(GetSetColorData))]
      public void SetGet_PixelColor_ReturnsOriginalColor(int drawingHeight, int drawingWidth, int x, int y, Color expected)
      {
         using var drawing = new ImageSharpDrawing(drawingHeight, drawingWidth);

         drawing.SetPixel(x, y, expected);
         var color = drawing.GetPixel(x, y);

         Assert.Equal(expected, color);
      }

      public static IEnumerable<object[]> DrawingPathData =>
         new List<object[]>
         {
            new object[] { "drawing.png" },
            new object[] { @"output\file.jpeg" },
            new object[] { @"C:\file.bmp" },
            new object[] { @"C:\demo\image.gif" },
            new object[] { @"D:\repos\rt\renders\render_01.png" },
         };

      [Theory]
      [MemberData(nameof(DrawingPathData))]
      public void Save_Drawing_DrawingSaved(string path)
      {
         var fileSystem = new MockFileSystem();
         using var drawing = new ImageSharpDrawing(10, 10, fileSystem);

         drawing.Save(path);

         Assert.True(fileSystem.FileExists(path));
      }

      [Fact]
      public void Save_DisposedDrawing_ThrowsExcpetion()
      {
         var fileSystem = new MockFileSystem();
         using var drawing = new ImageSharpDrawing(10, 10, fileSystem);

         drawing.Dispose();

         var path = "image.png";

         Assert.Throws<ObjectDisposedException>(() => drawing.Save(path));
      }
   }
}