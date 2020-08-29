namespace RayTracingEngine.Models
{
   /// <summary> A class encapsulating screen parameters. </summary>
   public class ScreenParameters
   {
      /// <summary> The width of the output image in pixels. </summary>
      public int Width { get; set; }

      /// <summary> The height of the output image in pixels. </summary>
      public int Height { get; set; }

      /// <summary> Initializes a new instance of the ScreenParameters class. </summary>
      public ScreenParameters()
      {
         Width = 1920;
         Height = 1080;
      }
   }
}