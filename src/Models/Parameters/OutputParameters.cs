using System;
using RayTracingEngine.Helpers;

namespace RayTracingEngine.Models
{
   public class OutputParameters
   {
      private readonly string _fileFormat = "png";

      public string FilePrefix { get; set; }
      public bool AddTimeStamp { get; set; }
      public string Directory { get; set; }

      public OutputParameters()
      {
         FilePrefix = "render";
         AddTimeStamp = true;
         Directory = @"renders\";
      }

      public string FilePath
      {
         get
         {
            var filePath = AddTimeStamp ?
               $"{FilePrefix}_{DateTime.Now}.{_fileFormat}" :
               $"{FilePrefix}.{_fileFormat}";

            filePath = Directory + filePath.ReplaceInvalidFileNameChars('_');

            return filePath;
         }
      }
   }
}