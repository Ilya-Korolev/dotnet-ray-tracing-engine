using System;
using RayTracingEngine.Models;

namespace RayTracingEngine.Helpers
{
   public static class OutputPath
   {
      public static string Build(string fileName, string directory, ImageFormat imageFormat, bool addTimeStamp)
      {
         var fileExtension = imageFormat.ToString().ToLower();

         var resultFileName = addTimeStamp
            ? $"{fileName}_{DateTime.Now}.{fileExtension}"
            : $"{fileName}.{fileExtension}";

         var filePath = directory + resultFileName.ReplaceInvalidFileNameChars('_');

         return filePath;
      }
   }
}