namespace RayTracingEngine.Models
{
   /// <summary> A light which unconditionally contributes intensity to every point. </summary>
   public struct AmbientLight: ILight
   {
      /// <summary> The brightness of the light. </summary>
      public double Intensity { get; set; }
   }
}