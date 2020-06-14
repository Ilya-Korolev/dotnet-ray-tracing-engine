namespace RayTracingEngine.MathExtra
{
   public struct Vector2d
   {
      public double X { get; set; }
      public double Y { get; set; }

      public Vector2d(double x, double y)
      {
         X = x;
         Y = y;
      }

      public static implicit operator Vector3d(Vector2d self)
          => new Vector3d(self.X, self.Y, 0d);

      public override string ToString()
          => $"({X}, {Y})";
   }
}