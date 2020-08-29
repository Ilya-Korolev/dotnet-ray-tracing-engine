using System;

namespace RayTracingEngine.ImageProcessing
{
   /// <summary> A structure which represents a RGBA (red, green, blue, alpha) color. </summary>
   public struct Color
   {
      private double _r;
      private double _g;
      private double _b;
      private double _a;

      /// <summary> The red component of the color. </summary>
      public double R { get => _r; set => _r = Math.Clamp(value, 0d, 1d); }

      /// <summary> The green component of the color. </summary>
      public double G { get => _g; set => _g = Math.Clamp(value, 0d, 1d); }

      /// <summary> The blue component of the color. </summary>
      public double B { get => _b; set => _b = Math.Clamp(value, 0d, 1d); }

      /// <summary> The alpha component of the color. </summary>
      public double A { get => _a; set => _a = Math.Clamp(value, 0d, 1d); }

      /// <summary> Creates a new instance of the Color class from the given R, G, B, A components. </summary>
      public Color(double r, double g, double b, double a) : this()
      {
         R = r;
         G = g;
         B = b;
         A = a;
      }

      /// <summary> Creates a new instance of the Color class from the given hexadecimal value. </summary>
      public Color(uint hex)
      {
         var r = (double)(hex >> 24) / 255d;
         var g = (double)((hex << 8) >> 24) / 255d;
         var b = (double)((hex << 16) >> 24) / 255d;
         var a = (double)((hex << 24) >> 24) / 255d;

         this = new Color(r, g, b, a);
      }

      /// <summary> Returns a color with the given intensity. </summary>
      /// <param name="intensity">
      /// <para> The lightness of the color. </para>
      /// A value for this paremeter can range from 0 to double.MaxValue,
      /// where 0.0 represents black and 1.0 represents the same color.
      /// </param>
      public Color WithIntensity(double intensity)
      {
         var r = intensity * R;
         var g = intensity * G;
         var b = intensity * B;

         return new Color(r, g, b, A);
      }

      /// <summary> Adds two colors together. </summary>
      public static Color operator +(Color left, Color right)
      {
         var r = left.R + right.R;
         var g = left.G + right.G;
         var b = left.B + right.B;
         var a = left.A + right.A;

         return new Color(r, g, b, a);
      }

      /// <summary> Returns a string representation of the current color instance. </summary>
      public override string ToString()
         => $"(R={R}, G={G}, B={B}, A={A})";
   }
}