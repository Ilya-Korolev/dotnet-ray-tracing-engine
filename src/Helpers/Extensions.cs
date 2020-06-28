using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]

namespace RayTracingEngine.Helpers
{
   internal static class Extensions
   {
      internal static string ReplaceInvalidFileNameChars(this string self, char newChar)
      {
         var splittedResult = self.Split(Path.GetInvalidFileNameChars());
         var result = string.Join(newChar, splittedResult);

         return result;
      }

      internal static bool IsBetween(this double self, double lower, double upper)
      {
         return lower <= self && self <= upper;
      }
   }
}