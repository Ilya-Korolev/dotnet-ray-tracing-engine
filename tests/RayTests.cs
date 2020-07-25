using System.Collections.Generic;
using RayTracingEngine.Core;
using RayTracingEngine.Core.SceneObjects;
using RayTracingEngine.MathExtra;
using Xunit;

namespace UnitTests
{
   public class RayTests
   {
      public static IEnumerable<object[]> RayPointData =>
         new List<object[]>
         {
            new object[]
            {
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d)),
               0d,
               new Vector3d(0d, 0d, 0d)
            },
            new object[]
            {
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 1d, 1d)),
               1d,
               new Vector3d(1d, 1d, 1d)
            },
            new object[]
            {
               new Ray(new Vector3d(1d, 0d, 1d), new Vector3d(0d, 1d, 1d)),
               1d,
               new Vector3d(1d, 1d, 2d)
            },
            new object[]
            {
               new Ray(new Vector3d(3d, 2d, 1d), new Vector3d(5d, -3d, 7d)),
               -2d,
               new Vector3d(-7d, 8d, -13d)
            },
            new object[]
            {
               new Ray(new Vector3d(double.MinValue, 0d, double.MinValue), new Vector3d(1d, 1d, 0d)),
               double.MaxValue,
               new Vector3d(0d, double.MaxValue, double.MinValue)
            },
         };

      [Theory]
      [MemberData(nameof(RayPointData))]
      internal void Get_RayPoint_ReturnsPoint(Ray ray, double distance, Vector3d expected)
      {
         var result = ray.GetPoint(distance);

         Assert.Equal(expected, result);
      }

      private static SceneObject _closestSphere = new Sphere(new Vector3d(2d, 0d, 0d), 1d);
      private static SceneObject _distantSphere = new Sphere(new Vector3d(4d, 0d, 0d), 1d);

      public static IEnumerable<object[]> ClosestObjectData =>
         new List<object[]>
         {
            new object[]
            {
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d)),
               new List<SceneObject> { _closestSphere },
               0d, double.MaxValue,
               ((SceneObject)null, (double?)null)
            },
            new object[]
            {
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 1d, 1d)),
               new List<SceneObject> { _closestSphere },
               0d, 0d,
               ((SceneObject)null, (double?)null)
            },
            new object[]
            {
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 0d, 0d)),
               new List<SceneObject> { _closestSphere, _distantSphere },
               0d, double.MaxValue,
               (_closestSphere, (double?)1d)
            },
            new object[]
            {
               new Ray(new Vector3d(6d, 0d, 0d), new Vector3d(-1d, 0d, 0d)),
               new List<SceneObject> { _closestSphere, _distantSphere },
               0d, double.MaxValue,
               (_distantSphere, (double?)1d)
            },
            new object[]
            {
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 1d, 1d)),
               new List<SceneObject> { _closestSphere },
               0d, double.MaxValue,
               ((SceneObject)null, (double?)null)
            },
         };

      [Theory]
      [MemberData(nameof(ClosestObjectData))]
      internal void Get_ClosestObject_ReturnsClosestObject(Ray ray, List<SceneObject> sceneObjects, double minDistance, double maxDistance, (SceneObject, double?) expected)
      {
         var result = ray.GetClosestObject(sceneObjects, minDistance, maxDistance);

         Assert.Equal(expected, result);
      }

      public static IEnumerable<object[]> HasIntersectionData =>
         new List<object[]>
         {
            new object[]
            {
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(0d, 0d, 0d)),
               new List<SceneObject> { _closestSphere },
               0d, double.MaxValue,
               false
            },
            new object[]
            {
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 1d, 1d)),
               new List<SceneObject> { _closestSphere },
               0d, 0d,
               false
            },
            new object[]
            {
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 0d, 0d)),
               new List<SceneObject> { _closestSphere, _distantSphere },
               0d, double.MaxValue,
               true
            },
            new object[]
            {
               new Ray(new Vector3d(6d, 0d, 0d), new Vector3d(-1d, 0d, 0d)),
               new List<SceneObject> { _closestSphere, _distantSphere },
               0d, double.MaxValue,
               true
            },
            new object[]
            {
               new Ray(new Vector3d(0d, 0d, 0d), new Vector3d(1d, 1d, 1d)),
               new List<SceneObject> { _closestSphere },
               0d, double.MaxValue,
               false
            },
         };

      [Theory]
      [MemberData(nameof(HasIntersectionData))]
      internal void Check_IntersectionExistence_ReturnsTrueIfExists(Ray ray, List<SceneObject> sceneObjects, double minDistance, double maxDistance, bool expected)
      {
         var result = ray.HasIntersection(sceneObjects, minDistance, maxDistance);

         Assert.Equal(expected, result);
      }
   }
}