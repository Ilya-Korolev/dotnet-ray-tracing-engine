using RayTracingEngine.MathExtra;

namespace RayTracingEngine.Models
{
   /// <summary> A light which gets emitted from a fixed point in all directions equally. This light type is similar to a light bulb. </summary>
   public class PointLight : ILight
   {
      /// <summary> The brightness of the light. </summary>
      public double Intensity { get; set; }

      /// <summary> The position of the light. </summary>
      public Vector3d Position { get; set; }
   }
}