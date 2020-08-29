using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Advanced;
using System.IO.Abstractions;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]

namespace RayTracingEngine.ImageProcessing
{
   /// <summary> Encapsulates an image using the SixLabors.ImageSharp 2D graphics library. </summary>
   public class ImageSharpDrawing : IDrawing
   {
      private readonly IFileSystem _fileSystem;
      private readonly Image<Rgba32> _image;

      /// <summary> Initializes a new instance of the ImageSharpDrawing class with the height and the width of the image. </summary>
      public ImageSharpDrawing(int width, int height) : this(width, height, new FileSystem()) { }

      internal ImageSharpDrawing(int width, int height, IFileSystem fileSystem)
      {
         _image = new Image<Rgba32>(width, height);
         _fileSystem = fileSystem;
      }

      /// <summary> Sets the color of the specified pixel in this image. </summary>
      public void SetPixel(int x, int y, Color color)
      {
         Rgba32 imageSharpColor = new Rgba32((float)color.R, (float)color.G, (float)color.B, (float)color.A);

         _image[x, y] = imageSharpColor;
      }

      /// <summary> Returns the color of the specified pixel in this image. </summary>
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

      /// <summary> Saves the image using the given path. </summary>
      public void Save(string filePath)
      {
         var directory = _fileSystem.Path.GetDirectoryName(filePath);

         if (!string.IsNullOrEmpty(directory))
            _fileSystem.Directory.CreateDirectory(directory);

         using var fileStream = _fileSystem.File.Create(filePath);
         var imageEncoder = _image.DetectEncoder(filePath);

         _image.Save(fileStream, imageEncoder);
      }

      /// <summary> Disposes the object and frees resources for the Garbage Collector. </summary>
      public void Dispose()
      {
         _image.Dispose();
      }
   }
}