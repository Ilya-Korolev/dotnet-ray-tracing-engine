using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Advanced;
using System.IO.Abstractions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]

namespace RayTracingEngine.ImageProcessing
{
   public class ImageSharpDrawing : IDrawing
   {
      private readonly IFileSystem _fileSystem;
      private readonly Image<Rgba32> _image;

      public ImageSharpDrawing(int width, int height) : this(width, height, new FileSystem()) { }

      internal ImageSharpDrawing(int width, int height, IFileSystem fileSystem)
      {
         _image = new Image<Rgba32>(width, height);
         _fileSystem = fileSystem;
      }

      public void SetPixel(int x, int y, Color color)
      {
         Rgba32 imageSharpColor = new Rgba32((float)color.R, (float)color.G, (float)color.B, (float)color.A);

         _image[x, y] = imageSharpColor;
      }

      public Color GetPixel(int x, int y)
      {
         Rgba32 imageSharpColor = _image[x, y];

         double r = imageSharpColor.R / 255d;
         double g = imageSharpColor.G / 255d;
         double b = imageSharpColor.B / 255d;
         double a = imageSharpColor.A / 255d;

         Color color = new Color(r, g, b, a);

         return color;
      }

      public void Save(string filePath)
      {
         var directory = _fileSystem.Path.GetDirectoryName(filePath);

         if (!string.IsNullOrEmpty(directory))
            _fileSystem.Directory.CreateDirectory(directory);

         using var fileStream = _fileSystem.File.Create(filePath);
         var imageEncoder = _image.DetectEncoder(filePath);

         _image.Save(fileStream, imageEncoder);
      }

      public void Dispose()
      {
         _image.Dispose();
      }
   }
}