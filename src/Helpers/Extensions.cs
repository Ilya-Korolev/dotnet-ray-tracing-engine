using System.IO;

namespace RayTracingEngine.Helpers
{
   public static class Extensions
   {
      public static string ReplaceInvalidFileNameChars(this string self, char newChar)
      {
         var splittedResult = self.Split(Path.GetInvalidFileNameChars());
         var result = string.Join(newChar, splittedResult);

         return result;
      }

      public static bool Between(this double self, double lower, double upper)
      {
         return lower <= self && self <= upper;
      }

      public static double Clamp(this double self, double lower, double upper)
      {
         if (self < lower)
            return lower;

         if (self > upper)
            return upper;

         return self;
      }
   }
}