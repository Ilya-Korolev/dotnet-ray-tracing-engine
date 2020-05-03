using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RayTracingEngine.ImageProcessing
{
   public class ImageSharpDrawing : IDrawing
   {
      private Image<Rgba32> _image;

      public ImageSharpDrawing(int width, int height)
      {
         _image = new Image<Rgba32>(width, height);
      }

      public void SetPixel(int x, int y, Color color)
      {
         _image[x, y] = new Rgba32((float)color.R, (float)color.G, (float)color.B, (float)color.A);
      }

      public void Save(string filePath)
      {
         var directory = Path.GetDirectoryName(filePath);
         Directory.CreateDirectory(directory);

         _image.Save(filePath);
      }

      public void Dispose()
      {
         _image?.Dispose();
      }
   }
}