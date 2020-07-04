using System;
using RayTracingEngine.Helpers;

namespace RayTracingEngine.Models
{
   public class OutputParameters
   {
      public string FileName { get; set; }
      public bool AddTimeStamp { get; set; }
      public string Directory { get; set; }
      public ImageFormat ImageFormat { get; set; }

      public OutputParameters()
      {
         FileName = "render";
         AddTimeStamp = true;
         Directory = @"renders\";
         ImageFormat = ImageFormat.Png;
      }

      public string FilePath
      {
         get
         {
            var fileExtension = ImageFormat.ToString().ToLower();

            var fileName = AddTimeStamp
               ? $"{FileName}_{DateTime.Now}.{fileExtension}"
               : $"{FileName}.{fileExtension}";

            var filePath = Directory + fileName.ReplaceInvalidFileNameChars('_');

            return filePath;
         }
      }
   }
}