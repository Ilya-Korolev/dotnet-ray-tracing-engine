using System;

namespace RayTracingEngine.ImageProcessing
{
   /// <summary> An interface for images. </summary>
   public interface IDrawing : IDisposable
   {
      /// <summary> Sets the color of the specified pixel in this image. </summary>
      void SetPixel(int x, int y, Color color);

      /// <summary> Returns the color of the specified pixel in this image. </summary>
      Color GetPixel(int x, int y);

      /// <summary> Saves the image using the given path. </summary>
      void Save(string filePath);
   }
}