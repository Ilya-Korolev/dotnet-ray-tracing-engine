using RayTracingEngine.MathExtra;
using RayTracingEngine.Models;

namespace RayTracingEngine.Core
{
    /// <summary> A base class for all objects in the Scene. </summary>
    public abstract class SceneObject
    {
        /// <summary> The Material of the object. </summary>
        public Material Material { get; set; } = new Material();

        internal abstract (double? firstDistance, double? secondDistance) IntersectRay(Ray ray);

        internal abstract Vector3d GetNormal(Vector3d point);
    }
}