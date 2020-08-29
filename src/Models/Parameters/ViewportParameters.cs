using RayTracingEngine.MathExtra;

namespace RayTracingEngine.Models
{
   /// <summary> A class encapsulating viewport parameters. </summary>
   public class ViewportParameters
   {
      /// <summary> The width of the viewport in world units. </summary>
      public double Width { get; set; }

      /// <summary> The height of the viewport in world units. </summary>
      public double Height { get; set; }

      /// <summary> The distance to the viewport in world units. </summary>
      public double ProjectionPlaneDistance { get; set; }

      /// <summary> The position of the camera. </summary>
      public Vector3d CameraPosition { get; set; }

      /// <summary> The rotation of the camera. </summary>
      public Matrix3d CameraRotation { get; set; }

      /// <summary> Initializes a new instance of the ScreenParameters class. </summary>
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