using RayTracingEngine.MathExtra;

namespace RayTracingEngine.Models.Light
{
   public class PointLight : ILight
   {
      public double Intensity { get; set; }

      public Vector3d Position { get; set; }
   }
}