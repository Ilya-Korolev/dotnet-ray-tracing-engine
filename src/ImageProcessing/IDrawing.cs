using System;

namespace RayTracingEngine.ImageProcessing
{
   public interface IDrawing : IDisposable
   {
      void SetPixel(int x, int y, Color color);

      void Save(string filePath);
   }
}