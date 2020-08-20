using System;
using RayTracingEngine.ImageProcessing;

namespace RayTracingEngine.Models
{
   /// <summary> A class encapsulating parameters for the interaction of light with an object. </summary>
   public class Material
   {
      private double _reflectiveCoefficient;

      /// <summary> The color of the material. </summary>
      public Color Color { get; set; }

      /// <summary>
      /// <para> The specular exponent defines the size of specular highlights. </para>
      /// A value for this property can range from 0 to double.MaxValue.
      /// As the value increases, specular highlights get smaller.
      /// A negative value means that specular highlights shouldn’t be computed.
      /// </summary>
      public double SpecularExponent { get; set; }

      /// <summary>
      /// <para> The reflective coefficient defines how reflective the material is. </para>
      /// Values for this property can range from 0 to 1.
      /// </summary>
      public double ReflectiveCoefficient
      {
         get => _reflectiveCoefficient;
         set => _reflectiveCoefficient = Math.Clamp(value, 0d, 1d);
      }

      /// <summary> Initializes a new instance of Material class. </summary>
      public Material()
      {
         Color = new Color(0d, 0d, 0d, 1d);
         SpecularExponent = 0d;
         ReflectiveCoefficient = 0d;
      }
   }
}
