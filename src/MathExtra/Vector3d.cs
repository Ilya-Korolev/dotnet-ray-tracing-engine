using System;

namespace RayTracingEngine.MathExtra
{
   public struct Vector3d
   {
      public double X { get; set; }
      public double Y { get; set; }
      public double Z { get; set; }

      public double Length { get => Math.Sqrt(this * this); }

      public Vector3d(double x, double y, double z)
      {
         X = x;
         Y = y;
         Z = z;
      }

      // vector-vector
      public static Vector3d operator +(Vector3d left, Vector3d right)
          => new Vector3d(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

      public static Vector3d operator -(Vector3d left, Vector3d right)
          => new Vector3d(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

      public static double operator *(Vector3d left, Vector3d right)
          => left.X * right.X + left.Y * right.Y + left.Z * right.Z;


      // vector-scalar
      public static Vector3d operator +(Vector3d left, double right)
          => new Vector3d(left.X + right, left.Y + right, left.Z + right);

      public static Vector3d operator +(double left, Vector3d right)
          => right + left;


      public static Vector3d operator -(Vector3d left, double right)
          => new Vector3d(left.X - right, left.Y - right, left.Z - right);


      public static Vector3d operator *(Vector3d left, double right)
          => new Vector3d(left.X * right, left.Y * right, left.Z * right);

      public static Vector3d operator *(double left, Vector3d right)
          => right * left;


      public static Vector3d operator /(Vector3d left, double right)
          => left * (1d / right);


      // unary operations
      public static Vector3d operator -(Vector3d self)
          => new Vector3d(-self.X, -self.Y, -self.Z);


      public Vector3d Normalize()
          => this / Length;

      public Vector3d Reflect(Vector3d normal)
          => 2d * normal * (normal * this) - this;


      public static explicit operator Vector2d(Vector3d self)
          => new Vector2d(self.X, self.Y);


      public override string ToString()
          => $"({X}, {Y}, {Z})";
   }
}