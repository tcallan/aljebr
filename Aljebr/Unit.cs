using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aljebr
{
   public struct Unit
   {
      public static Unit Value;

      public static Func<T, Unit> Lift<T>(Action<T> action)
      {
         return arg =>
         {
            action(arg);
            return Value;
         };
      }
   }
}
