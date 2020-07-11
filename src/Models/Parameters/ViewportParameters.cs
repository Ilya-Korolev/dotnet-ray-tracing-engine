using RayTracingEngine.MathExtra;

namespace RayTracingEngine.Models
{
   public class ViewportParameters
   {
      public double Width { get; set; }
      public double Height { get; set; }
      public double ProjectionPlaneDistance { get; set; }

      public Vector3d CameraPosition { get; set; }
      public Matrix3d CameraRotation { get; set; }

      public ViewportParameters()
      {
         Width = 1d;
         Height = 1d;
         ProjectionPlaneDistance = 1d;

         CameraPosition = new Vector3d(0d, 0d, 0d);
         CameraRotation = Matrix3d.Identity();
      }
   }
}