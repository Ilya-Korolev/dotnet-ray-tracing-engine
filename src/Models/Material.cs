using System;
using RayTracingEngine.ImageProcessing;

namespace RayTracingEngine.Models
{
   public class Material
   {
      private double _reflectiveCoefficient;

      public Color Color { get; set; }
      public double SpecularExponent { get; set; }
      public double ReflectiveCoefficient
      {
         get => _reflectiveCoefficient;
         set => _reflectiveCoefficient = Math.Clamp(value, 0d, 1d);
      }

      public Material()
      {
         Color = new Color(0d, 0d, 0d, 1d);
         SpecularExponent = 0d;
         ReflectiveCoefficient = 0d;
      }
   }
}
