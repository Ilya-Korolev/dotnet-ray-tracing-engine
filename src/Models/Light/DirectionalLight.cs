using RayTracingEngine.MathExtra;

namespace RayTracingEngine.Models
{
   /// <summary> A light which gets emitted in a specific direction. This light type is most similar to the Sun. </summary>
   public struct DirectionalLight: ILight
   {
      /// <summary> The brightness of the light. </summary>
      public double Intensity { get; set; }

      /// <summary> The direction of the light. </summary>
      public Vector3d Direction { get; set; }
   }
}