using System;

namespace RayTracingEngine.ImageProcessing
{
   public struct Color
   {
      public double R { get; set; }
      public double G { get; set; }
      public double B { get; set; }
      public double A { get; set; }

      public Color(double r, double g, double b, double a)
      {
         R = r;
         G = g;
         B = b;
         A = a;
      }

      public Color(UInt32 hex)
      {
         R = (double)(hex >> 24) / 255d;
         G = (double)((hex << 8) >> 24) / 255d;
         B = (double)((hex << 16) >> 24) / 255d;
         A = (double)((hex << 24) >> 24) / 255d;
      }

      public Color WithIntensity(double intensity)
      {
         intensity = Math.Min(1d, intensity);

         var r = intensity * R;
         var g = intensity * G;
         var b = intensity * B;

         return new Color(r, g, b, A);
      }

      public static Color operator +(Color left, Color right)
      {
         var r = Math.Min(1d, left.R + right.R);
         var g = Math.Min(1d, left.G + right.G);
         var b = Math.Min(1d, left.B + right.B);
         var a = Math.Min(1d, left.A + right.A);

         return new Color(r, g, b, a);
      }
   }
}