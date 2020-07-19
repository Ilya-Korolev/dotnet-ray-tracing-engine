using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RayTracingEngine.Core.SceneObjects;
using RayTracingEngine.Helpers;
using RayTracingEngine.MathExtra;

[assembly: InternalsVisibleTo("UnitTests")]

namespace RayTracingEngine.Core
{
   internal struct Ray
   {
      internal Vector3d Origin { get; set; }
      internal Vector3d Direction { get; set; }

      internal Ray(Vector3d origin, Vector3d direction)
      {
         Origin = origin;
         Direction = direction;
      }

      internal Vector3d GetPertainPoint(double distance) => Origin + distance * Direction;

      internal (SceneObject closestObject, double? distance) GetClosestObject(List<SceneObject> sceneObjects, double minDistance, double maxDistance)
      {
         double? closestDistance = null;
         SceneObject closestObject = null;

         foreach (var sceneObject in sceneObjects)
         {
            (double? firstDistance, double? secondDistance) = sceneObject.IntersectRay(this);

            if (firstDistance.HasValue &&
                firstDistance.Value.IsBetween(minDistance, maxDistance) &&
               (firstDistance < closestDistance || !closestDistance.HasValue))
            {
               closestDistance = firstDistance;
               closestObject = sceneObject;
            }

            if (secondDistance.HasValue &&
                secondDistance.Value.IsBetween(minDistance, maxDistance) &&
               (secondDistance < closestDistance || !closestDistance.HasValue))
            {
               closestDistance = secondDistance;
               closestObject = sceneObject;
            }
         }

         return (closestObject, closestDistance);
      }

      internal bool HasIntersection(List<SceneObject> sceneObjects, double minDistance, double maxDistance)
      {
         foreach (var sceneObject in sceneObjects)
         {
            (double? firstDistance, double? secondDistance) = sceneObject.IntersectRay(this);

            if (firstDistance.HasValue && firstDistance.Value.IsBetween(minDistance, maxDistance))
               return true;

            if (secondDistance.HasValue && secondDistance.Value.IsBetween(minDistance, maxDistance))
               return true;
         }

         return false;
      }
   }
}