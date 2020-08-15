using System;

namespace RayTracingEngine.MathExtra
{
   /// <summary> A structure encapsulating three double precision floating point values. </summary>
   public struct Vector3d
   {
      private double _x;
      private double _y;
      private double _z;
      private double _length;

      /// <summary> The X component of the vector. </summary>
      public double X { get => _x; set { _x = value; updateLength(); } }

      /// <summary> The Y component of the vector. </summary>
      public double Y { get => _y; set { _y = value; updateLength(); } }

      /// <summary> The Z component of the vector. </summary>
      public double Z { get => _z; set { _z = value; updateLength(); } }

      /// <summary> The length of the vector. </summary> 
      public double Length { get => _length; }

      /// <summary> Initializes a new instance of Vector3d class with given X, Y, Z components. </summary>
      public Vector3d(double x, double y, double z) : this()
      {
         _x = x;
         _y = y;
         _z = z;
         updateLength();
      }

      private void updateLength()
         => _length = Math.Sqrt(this * this);

      /// <summary> Adds two vectors together. </summary>
      public static Vector3d operator +(Vector3d left, Vector3d right)
         => new Vector3d(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

      /// <summary> Subtracts the second vector from the first. </summary>
      public static Vector3d operator -(Vector3d left, Vector3d right)
         => new Vector3d(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

      /// <summary> Returns a dot product of two vectors. </summary>
      public static double operator *(Vector3d left, Vector3d right)
         => left.X * right.X + left.Y * right.Y + left.Z * right.Z;

      /// <summary> Adds the scalar to the vector. </summary>
      public static Vector3d operator +(Vector3d left, double right)
         => new Vector3d(left.X + right, left.Y + right, left.Z + right);

      /// <summary> Adds the scalar to the vector. </summary>
      public static Vector3d operator +(double left, Vector3d right)
         => right + left;

      /// <summary> Subtracts the scalar from the vector. </summary>
      public static Vector3d operator -(Vector3d left, double right)
         => new Vector3d(left.X - right, left.Y - right, left.Z - right);

      /// <summary> Multiplies the vector by the scalar. </summary>
      public static Vector3d operator *(Vector3d left, double right)
         => new Vector3d(left.X * right, left.Y * right, left.Z * right);

      /// <summary> Multiplies the vector by the scalar. </summary>
      public static Vector3d operator *(double left, Vector3d right)
         => right * left;

      /// <summary> Divides the vector by the scalar. </summary>
      public static Vector3d operator /(Vector3d left, double right)
         => left * (1d / right);

      /// <summary> Negates the vector </summary>
      public static Vector3d operator -(Vector3d self)
         => new Vector3d(-self.X, -self.Y, -self.Z);

      /// <summary> Returns a vector with the same direction as the current vector, but with a length of 1. </summary>
      public Vector3d Normalized()
      {
         if (Length == 0d)
            return this;

         return this / Length;
      }

      /// <summary> Returns a reflection of the vector off a surface that has the specified normal. </summary>
      public Vector3d Reflect(Vector3d normal)
         => 2d * normal * (normal * this) - this;

      /// <summary> Converts the Vector3d to a Vector2d. </summary>
      public static explicit operator Vector2d(Vector3d self)
         => new Vector2d(self.X, self.Y);

      /// <summary> Returns a string representation of the current vector instance. </summary>
      public override string ToString()
         => $"({X}, {Y}, {Z})";
   }
}