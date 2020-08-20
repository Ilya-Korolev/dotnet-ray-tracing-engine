namespace RayTracingEngine.Models
{
   /// <summary> An interface for lights. </summary>
   public interface ILight
   {
      /// <summary> The brightness of the light. </summary>
      double Intensity { get; set; }
   }
}