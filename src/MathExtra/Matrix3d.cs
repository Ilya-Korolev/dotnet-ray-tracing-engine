using System;

namespace RayTracingEngine.MathExtra
{
   /// <summary> A structure encapsulating a 3x3 matrix. </summary>
   public struct Matrix3d
   {
      /// <summary> Value at row 1, column 1 of the matrix. </summary>
      public double A1 { get; set; }
      /// <summary> Value at row 1, column 2 of the matrix. </summary>
      public double B1 { get; set; }
      /// <summary> Value at row 1, column 3 of the matrix. </summary>
      public double C1 { get; set; }

      /// <summary> Value at row 2, column 1 of the matrix. </summary>
      public double A2 { get; set; }
      /// <summary> Value at row 2, column 2 of the matrix. </summary>
      public double B2 { get; set; }
      /// <summary> Value at row 2, column 3 of the matrix. </summary>
      public double C2 { get; set; }

      /// <summary> Value at row 3, column 1 of the matrix. </summary>
      public double A3 { get; set; }
      /// <summary> Value at row 3, column 2 of the matrix. </summary>
      public double B3 { get; set; }
      /// <summary> Value at row 3, column 3 of the matrix. </summary>
      public double C3 { get; set; }

      /// <summary> Initializes a new instance of the Matrix3d class with the specified elements. </summary>
      public Matrix3d(double a1, double b1, double c1, double a2, double b2, double c2, double a3, double b3, double c3)
      {
         A1 = a1; B1 = b1; C1 = c1;
         A2 = a2; B2 = b2; C2 = c2;
         A3 = a3; B3 = b3; C3 = c3;
      }

      /// <summary> Returns an identity matrix. </summary>
      static public Matrix3d Identity()
         => new Matrix3d(1d, 0d, 0d, 0d, 1d, 0d, 0d, 0d, 1d);

      /// <summary> Returns a rotation matrix for rotations around X-axis. </summary>
      /// <param name="degrees"> The amount, in degrees, by which to rotate around the X-axis. </param>
      static public Matrix3d RotationX(double degrees)
      {
         var radians = degrees * Math.PI / 180d;

         var cos = Math.Cos(radians);
         var sin = Math.Sin(radians);

         return new Matrix3d(1d, 0d, 0d, 0d, cos, -sin, 0d, sin, cos);
      }

      /// <summary> Returns a rotation matrix for rotations around Y-axis. </summary>
      /// <param name="degrees"> The amount, in degrees, by which to rotate around the Y-axis. </param>
      static public Matrix3d RotationY(double degrees)
      {
         var radians = degrees * Math.PI / 180d;

         var cos = Math.Cos(radians);
         var sin = Math.Sin(radians);

         return new Matrix3d(cos, 0d, sin, 0d, 1d, 0d, -sin, 0d, cos);
      }

      /// <summary> Returns a rotation matrix for rotations around Z-axis. </summary>
      /// <param name="degrees"> The amount, in degrees, by which to rotate around the Z-axis. </param>
      static public Matrix3d RotationZ(double degrees)
      {
         var radians = degrees * Math.PI / 180d;

         var cos = Math.Cos(radians);
         var sin = Math.Sin(radians);

         return new Matrix3d(cos, -sin, 0d, sin, cos, 0d, 0d, 0d, 1d);
      }

      /// <summary> Multiplies the matrix by the vector. </summary>
      public static Vector3d operator *(Matrix3d left, Vector3d right)
      {
         var x = left.A1 * right.X + left.B1 * right.Y + left.C1 * right.Z;
         var y = left.A2 * right.X + left.B2 * right.Y + left.C2 * right.Z;
         var z = left.A3 * right.X + left.B3 * right.Y + left.C3 * right.Z;

         return new Vector3d(x, y, z);
      }

      /// <summary> Multiplies two matrices together. </summary>
      public static Matrix3d operator *(Matrix3d left, Matrix3d right)
      {
         var a1 = left.A1 * right.A1 + left.B1 * right.A2 + left.C1 * right.A3;
         var b1 = left.A1 * right.B1 + left.B1 * right.B2 + left.C1 * right.B3;
         var c1 = left.A1 * right.C1 + left.B1 * right.C2 + left.C1 * right.C3;

         var a2 = left.A2 * right.A1 + left.B2 * right.A2 + left.C2 * right.A3;
         var b2 = left.A2 * right.B1 + left.B2 * right.B2 + left.C2 * right.B3;
         var c2 = left.A2 * right.C1 + left.B2 * right.C2 + left.C2 * right.C3;

         var a3 = left.A3 * right.A1 + left.B3 * right.A2 + left.C3 * right.A3;
         var b3 = left.A3 * right.B1 + left.B3 * right.B2 + left.C3 * right.B3;
         var c3 = left.A3 * right.C1 + left.B3 * right.C2 + left.C3 * right.C3;

         return new Matrix3d(a1, b1, c1, a2, b2, c2, a3, b3, c3);
      }

      /// <summary> Returns a string representation of the current matrix instance. </summary>
      public override string ToString()
         => $"({{{A1}, {B1}, {C1}}}, {{{A2}, {B2}, {C2}}}, {{{A3}, {B3}, {C3}}})";
   }
}