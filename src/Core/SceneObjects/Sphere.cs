using System;
using RayTracingEngine.MathExtra;

namespace RayTracingEngine.Core.SceneObjects
{
   public class Sphere : SceneObject
   {
      public Vector3d Center { get; set; }
      public double Radius { get; set; }

      public Sphere() { }

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
         normal = normal.Normalize();

         return normal;
      }
   }
}