using RayTracingEngine.MathExtra;

namespace RayTracingEngine.Models.Light
{
   public struct DirectionalLight: ILight
   {
      public double Intensity { get; set; }
      public Vector3d Direction { get; set; }
   }
}