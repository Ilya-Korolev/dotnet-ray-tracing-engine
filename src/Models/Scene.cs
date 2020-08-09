using System.Collections.Generic;
using RayTracingEngine.Core;
using RayTracingEngine.ImageProcessing;

namespace RayTracingEngine.Models
{
   public class Scene
   {
      public Color BackgroundColor { get; set; }

      public List<SceneObject> Objects { get; set; }

      public List<ILight> Lights { get; set; }

      public Scene()
      {
         BackgroundColor = new Color(0d, 0d, 0d, 1d);
         Objects = new List<SceneObject>();
         Lights = new List<ILight>();
      }
   }
}