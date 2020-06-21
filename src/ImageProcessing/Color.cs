using RayTracingEngine.Helpers;

namespace RayTracingEngine.ImageProcessing
{
   public struct Color
   {
      private double _r;
      private double _g;
      private double _b;
      private double _a;

      public double R { get => _r; set => _r = value.Clamp(0d, 1d); }
      public double G { get => _g; set => _g = value.Clamp(0d, 1d); }
      public double B { get => _b; set => _b = value.Clamp(0d, 1d); }
      public double A { get => _a; set => _a = value.Clamp(0d, 1d); }

      public Color(double r, double g, double b, double a) : this()
      {
         R = r;
         G = g;
         B = b;
         A = a;
      }

      public Color(uint hex)
      {
         var r = (double)(hex >> 24) / 255d;
         var g = (double)((hex << 8) >> 24) / 255d;
         var b = (double)((hex << 16) >> 24) / 255d;
         var a = (double)((hex << 24) >> 24) / 255d;

         this = new Color(r, g, b, a);
      }

      public Color WithIntensity(double intensity)
      {
         var r = intensity * R;
         var g = intensity * G;
         var b = intensity * B;

         return new Color(r, g, b, A);
      }

      public static Color operator +(Color left, Color right)
      {
         var r = left.R + right.R;
         var g = left.G + right.G;
         var b = left.B + right.B;
         var a = left.A + right.A;

         return new Color(r, g, b, a);
      }

      public override string ToString()
         => $"(R={R}, G={G}, B={B}, A={A})";
   }
}