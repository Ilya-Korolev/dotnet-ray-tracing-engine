using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RayTracingEngine.ImageProcessing
{
   public class ImageSharpDrawing : IDrawing, IDisposable
   {
      private Image<Rgba32> _image;

      public ImageSharpDrawing(int height, int width)
      {
          _image = new Image<Rgba32>(height, width);
      }

      public void SetPixel(int x, int y, Color color)
      {
         _image[x, y] = new Rgba32(color.R, color.G, color.B, color.A);
      }

      public void Save(string filePath)
      {
         _image.Save(filePath);
      }

      public void Dispose()
      {
         _image?.Dispose();
      }
   }
}