using System;
using RayTracingEngine.ImageProcessing;
using RayTracingEngine.MathExtra;
using RayTracingEngine.Models;

namespace RayTracingEngine.Core
{
   internal class RayTracer
   {
      private const double Delta = 0.000001d;

      private readonly Scene _scene;
      private readonly RenderParameters _renderParameters;

      internal RayTracer(Scene scene, RenderParameters renderParameters)
      {
         _scene = scene;
         _renderParameters = renderParameters;
      }

      internal Color Trace(Ray ray)
         => Trace(ray, _renderParameters.MinDistance, _renderParameters.ReflectionDepth);

      private Color Trace(Ray ray, double minDistance, int reflectionDepth)
      {
         (SceneObject closestObject, double? distance) = ray.GetClosestObject(_scene.Objects, minDistance, _renderParameters.MaxDistance);

         if (closestObject == null)
            return _scene.BackgroundColor;

         Vector3d intersectionPoint = ray.GetPoint(distance.Value);
         Vector3d normal = closestObject.GetNormal(intersectionPoint);
         Vector3d viewDirection = -ray.Direction;

         double lightIntensity = ComputeLightIntensity(intersectionPoint, normal, viewDirection, closestObject.Material.SpecularExponent);

         Color localColor = closestObject.Material.Color.WithIntensity(lightIntensity);

         if (reflectionDepth <= 0)
            return localColor;

         Vector3d reflection = viewDirection.Reflect(normal);
         Ray reflectedRay = new Ray(intersectionPoint, reflection);

         Color reflectedColor = Trace(reflectedRay, RayTracer.Delta, reflectionDepth - 1);

         return localColor.WithIntensity(1d - closestObject.Material.ReflectiveCoefficient) + reflectedColor.WithIntensity(closestObject.Material.ReflectiveCoefficient);
      }

      private double ComputeLightIntensity(Vector3d intersectionPoint, Vector3d normal, Vector3d viewDirection, double specularExponent)
      {
         double intensity = 0d;

         foreach (var light in _scene.Lights)
            intensity += ComputeLightIntensity(light, intersectionPoint, normal, viewDirection, specularExponent);

         return intensity;
      }

      private double ComputeLightIntensity(ILight light, Vector3d intersectionPoint, Vector3d normal, Vector3d viewDirection, double specularExponent)
      {
         if (light is AmbientLight)
            return light.Intensity;

         Vector3d oppositeLightDirection;
         double maxDistance;

         switch (light)
         {
            case DirectionalLight directionalLight:
               oppositeLightDirection = -directionalLight.Direction;
               maxDistance = double.PositiveInfinity;
               break;

            case PointLight pointLight:
               oppositeLightDirection = pointLight.Position - intersectionPoint;
               maxDistance = 1d;
               break;

            default:
               throw new NotSupportedException($"Cannot handle light of type {light.GetType().Name}");
         }

         // shadow
         Ray shadowRay = new Ray(intersectionPoint, oppositeLightDirection);
         bool hasShadow = shadowRay.HasIntersection(_scene.Objects, RayTracer.Delta, maxDistance);
         if (hasShadow)
            return 0d;

         double intensity = 0d;

         // diffuse
         double nl = normal * oppositeLightDirection;
         if (nl > 0d)
            intensity += light.Intensity * nl / (normal.Length * intersectionPoint.Length);

         // specular
         if (specularExponent < 0d)
            return intensity;

         Vector3d lightReflection = oppositeLightDirection.Reflect(normal);
         double rv = lightReflection * viewDirection;
         if (rv > 0d)
            intensity += light.Intensity * Math.Pow(rv / (lightReflection.Length * viewDirection.Length), specularExponent);

         return intensity;
      }
   }
}