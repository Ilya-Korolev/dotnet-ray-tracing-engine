using System;
using System.Runtime.CompilerServices;
using RayTracingEngine.MathExtra;

[assembly: InternalsVisibleTo("UnitTests")]

namespace RayTracingEngine.Core
{
   /// <summary> A class which represents a sphere. </summary>
   public class Sphere : SceneObject
   {
      /// <summary> The center of the sphere. </summary>
      public Vector3d Center { get; set; }

      /// <summary> The radius of the sphere. </summary>
      public double Radius { get; set; }

      /// <summary> Creates a new instance of the Sphere class. </summary>
      public Sphere() { }

      /// <summary> Creates a new instance of the Sphere class with the given center and radius. </summary>
      public Sphere(Vector3d center, double radius)
      {
         Center = center;
         Radius = radius;
      }

      override internal (double? firstDistance, double? secondDistance) IntersectRay(Ray ray)
      {
         Vector3d oc = ray.Origin - Center;

         double a = ray.Direction * ray.Direction;
         double b = 2d * oc * ray.Direction;
         double c = oc * oc - Radius * Radius;

         double discriminant = b * b - 4d * a * c;

         if (discriminant < 0)
            return (null, null);

         double firstDistance = (-b - Math.Sqrt(discriminant)) / (2d * a);
         double secondDistance = (-b + Math.Sqrt(discriminant)) / (2d * a);

         return (firstDistance, secondDistance);
      }

      override internal Vector3d GetNormal(Vector3d point)
      {
         Vector3d normal = point - Center;
         normal = normal.Normalized();

         return normal;
      }
   }
}