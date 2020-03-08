namespace RayTracingEngine.ImageProcessing
{
   public ref struct Color
   {
      public byte R { get; set; }
      public byte G { get; set; }
      public byte B { get; set; }
      public byte A { get; set; }

      public Color(byte r, byte g, byte b, byte a)
      {
         R = r;
         G = g;
         B = b;
         A = a;
      }
   }
}