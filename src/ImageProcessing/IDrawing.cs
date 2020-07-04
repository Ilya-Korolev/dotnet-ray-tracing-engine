using System;

namespace RayTracingEngine.ImageProcessing
{
   public interface IDrawing : IDisposable
   {
      void SetPixel(int x, int y, Color color);

      Color GetPixel(int x, int y);

      void Save(string filePath);
   }
}