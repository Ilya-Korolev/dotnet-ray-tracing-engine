using System.Collections.Generic;
using RayTracingEngine.Core;
using RayTracingEngine.ImageProcessing;

namespace RayTracingEngine.Models
{
   /// <summary> A class encapsulating a collection of objects, lights and additional properties. </summary>
   public class Scene
   {
      /// <summary> The clear screen color. </summary>
      public Color BackgroundColor { get; set; }

      /// <summary> The collection of objects </summary>
      public List<SceneObject> Objects { get; set; }

      /// <summary> The collection of lights </summary>
      public List<ILight> Lights { get; set; }

      /// <summary> Initializes a new instance of the Scene class. </summary>
      public Scene()
      {
         BackgroundColor = new Color(0d, 0d, 0d, 1d);
         Objects = new List<SceneObject>();
         Lights = new List<ILight>();
      }
   }
}