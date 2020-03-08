namespace RayTracingEngine.ImageProcessing
{
   public interface IDrawing
   {
      void SetPixel(int x, int y, Color color);

      void Save(string filePath);
   }
}