using System.Collections.Generic;
using RayTracingEngine.Core;
using RayTracingEngine.Core.SceneObjects;
using RayTracingEngine.MathExtra;
using Xunit;

namespace UnitTests
{
   public class SphereTests
   {
      public static IEnumerable<object[]> RaySphereIntersectionData =>
         new List<object[]>
         {
            // ray is facing the sphere - two point intersection, both are positive
            new object[]
            {
               new Sphere(new Vector3d(2d, 0d, 0d), 1d),
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 0d, 0d)),
               ((double?)1d, (double?)3d)
            },
            // ray is shooting from inside the sphere - two point intersection, one positive one negative
            new object[]
            {
               new Sphere(new Vector3d(0d, 0d, 0d), 1d),
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 0d, 0d)),
               ((double?)(-1d), (double?)1d)
            },
            // ray is shooting away from the sphere - two point intersection, both are negative
            new object[]
            {
               new Sphere(new Vector3d(-2d, 0d, 0d), 1d),
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 0d, 0d)),
               ((double?)(-3d), (double?)(-1d))
            },
            // one point intersection, tangent
            new object[]
            {
               new Sphere(new Vector3d(2d, -1d, 0d), 1d),
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 0d, 0d)),
               ((double?)2d, (double?)2d)
            },
            // no intersection
            new object[]
            {
               new Sphere(new Vector3d(2d, -2d, 0d), 1d),
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 0d, 0d)),
               ((double?)null, (double?)null)
            },
         };

      [Theory]
      [MemberData(nameof(RaySphereIntersectionData))]
      internal void Intersect_SphereAndRay_ReturnsIntersectionDistances(Sphere sphere, Ray ray, (double?, double?) expected)
      {
         var result = sphere.IntersectRay(ray);

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> SphereNormalData =>
         new List<object[]>
         {
            // zero vector
            new object[]
            {
               new Sphere(new Vector3d(1d, 2d, 3d), 1d),
               new Vector3d(1d, 2d, 3d),
               new Vector3d(0d, 0d, 0d)
            },
            // left
            new object[]
            {
               new Sphere(new Vector3d(1d, 2d, 3d), 1d),
               new Vector3d(0d, 2d, 3d),
               new Vector3d(-1d, 0d, 0d)
            },
            // right
            new object[]
            {
               new Sphere(new Vector3d(1d, 2d, 3d), 1d),
               new Vector3d(2d, 2d, 3d),
               new Vector3d(1d, 0d, 0d)
            },
            // top
            new object[]
            {
               new Sphere(new Vector3d(1d, 2d, 3d), 1d),
               new Vector3d(1d, 3d, 3d),
               new Vector3d(0d, 1d, 0d)
            },
            // bottom
            new object[]
            {
               new Sphere(new Vector3d(1d, 2d, 3d), 1d),
               new Vector3d(1d, 1d, 3d),
               new Vector3d(0d, -1d, 0d)
            },
            // front
            new object[]
            {
               new Sphere(new Vector3d(1d, 2d, 3d), 1d),
               new Vector3d(1d, 2d, 2d),
               new Vector3d(0d, 0d, -1d)
            },
            // back
            new object[]
            {
               new Sphere(new Vector3d(1d, 2d, 3d), 1d),
               new Vector3d(1d, 2d, 4d),
               new Vector3d(0d, 0d, 1d)
            },
         };

      [Theory]
      [MemberData(nameof(SphereNormalData))]
      internal void Get_SphereNormal_ReturnsSphereNormal(Sphere sphere, Vector3d point, Vector3d expected)
      {
         var result = sphere.GetNormal(point);

         Assert.Equal(expected, result);
      }
   }
}