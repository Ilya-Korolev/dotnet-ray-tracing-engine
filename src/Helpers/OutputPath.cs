using System;
using RayTracingEngine.Models;

namespace RayTracingEngine.Helpers
{
   /// <summary> A class which provides a static method for the creation of a file path. </summary>
   public static class OutputPath
   {
      /// <summary> Creates a file path from the given file name, directory path and image format. </summary>
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