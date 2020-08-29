namespace RayTracingEngine.Models
{
   /// <summary> A class encapsulating render parameters. </summary>
   public class RenderParameters
   {
      /// <summary> The reflection depth defines the number of times a reflection ray is reflected off of surfaces. </summary>
      public int ReflectionDepth { get; set; }

      /// <summary> The closest distance relative to the camera that drawing will occur. </summary>
      public double MinDistance { get; set; }

      /// <summary> The furthest distance relative to the camera that drawing will occur. </summary>
      public double MaxDistance { get; set; }

      /// <summary> Initializes a new instance of the RenderParameters class. </summary>
      public RenderParameters()
      {
         ReflectionDepth = 5;
         MinDistance = 0d;
         MaxDistance = double.MaxValue;
      }
   }
}