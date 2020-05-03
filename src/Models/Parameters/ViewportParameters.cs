using RayTracingEngine.MathExtra;

namespace RayTracingEngine.Models
{
   public class ViewportParameters
   {
      public double Width { get; set; }
      public double Height { get; set; }
      public double ProjectionPlaneD { get; set; }

      public Vector3d Origin { get; set; }

      public ViewportParameters()
      {
         Width = 1d;
         Height = 1d;
         ProjectionPlaneD = 1d;
         Origin = new Vector3d(0d, 0d, 0d);
      }
   }
}