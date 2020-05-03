using System.Collections.Generic;
using RayTracingEngine.Core.SceneObjects;
using RayTracingEngine.Helpers;
using RayTracingEngine.MathExtra;

namespace RayTracingEngine.Core
{
   public struct Ray
   {
      public Vector3d Origin { get; set; }
      public Vector3d Direction { get; set; }

      public Ray(Vector3d origin, Vector3d direction)
      {
         Origin = origin;
         Direction = direction;
      }

      public Vector3d GetPertainPoint(double distantion) => Origin + distantion * Direction;

      public (ISceneObject closestObject, double? distance) GetClosestObject(List<ISceneObject> sceneObjects, double minDistance, double maxDistance)
      {
         double? closestDistance = null;
         ISceneObject closestObject = null;

         foreach (var sceneObject in sceneObjects)
         {
            (double? firstDistance, double? secondDistance) = sceneObject.IntersectRay(this);

            if (firstDistance.HasValue &&
                firstDistance.Value.Between(minDistance, maxDistance) &&
               (firstDistance < closestDistance || !closestDistance.HasValue))
            {
               closestDistance = firstDistance;
               closestObject = sceneObject;
            }

            if (secondDistance.HasValue &&
                secondDistance.Value.Between(minDistance, maxDistance) &&
               (secondDistance < closestDistance || !closestDistance.HasValue))
            {
               closestDistance = secondDistance;
               closestObject = sceneObject;
            }
         }

         return (closestObject, closestDistance);
      }

      public bool HasIntersection(List<ISceneObject> sceneObjects, double minDistance, double maxDistance)
      {
         foreach (var sceneObject in sceneObjects)
         {
            (double? firstDistance, double? secondDistance) = sceneObject.IntersectRay(this);

            if (firstDistance.HasValue && firstDistance.Value.Between(minDistance, maxDistance))
               return true;

            if (secondDistance.HasValue && secondDistance.Value.Between(minDistance, maxDistance))
               return true;
         }

         return false;
      }
   }
}