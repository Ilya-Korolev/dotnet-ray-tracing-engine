namespace RayTracingEngine.Models
{
   public class ScreenParameters
   {
      public int Width { get; set; }
      public int Height { get; set; }

      public ScreenParameters()
      {
         Width = 1920;
         Height = 1080;
      }
   }
}