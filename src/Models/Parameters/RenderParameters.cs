namespace RayTracingEngine.Models
{
   public class RenderParameters
   {
      public int ReflectionDepth { get; set; }

      public double MinDistance { get; set; }
      public double MaxDistance { get; set; }

      public RenderParameters()
      {
         ReflectionDepth = 5;
         MinDistance = 0d;
         MaxDistance = double.MaxValue;
      }
   }
}