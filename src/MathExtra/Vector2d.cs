namespace RayTracingEngine.MathExtra
{
   /// <summary> A structure encapsulating two double precision floating point values. </summary>
   public struct Vector2d
   {
      /// <summary> The X component of the vector. </summary>
      public double X { get; set; }

      /// <summary> The Y component of the vector. </summary>
      public double Y { get; set; }

      /// <summary> Initializes a new instance of Vector2d class with given X and Y components. </summary>
      public Vector2d(double x, double y)
      {
         X = x;
         Y = y;
      }

      /// <summary> Converts the Vector2d to a Vector3d. </summary>
      public static implicit operator Vector3d(Vector2d self)
         => new Vector3d(self.X, self.Y, 0d);

      /// <summary> Returns a string representation of the current vector instance. </summary>
      public override string ToString()
         => $"({X}, {Y})";
   }
}