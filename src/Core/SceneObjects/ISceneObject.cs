using RayTracingEngine.MathExtra;
using RayTracingEngine.Models;

namespace RayTracingEngine.Core.SceneObjects
{
    public interface ISceneObject
    {
        Material Material { get; set; }

        (double? firstDistance, double? secondDistance) IntersectRay(Ray ray);

        Vector3d GetNormal(Vector3d point);
    }
}