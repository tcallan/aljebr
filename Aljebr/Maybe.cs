using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aljebr
{
   internal class Maybe<T>
   {
      private readonly T _value;
      private readonly bool _hasValue;

      public static Maybe<T> Empty = new Maybe<T>();

      public static Maybe<T> Of(T value)
      {
         return new Maybe<T>(value);
      }

      private Maybe()
      {
         _value = default(T);
         _hasValue = false;
      }

      private Maybe(T value)
      {
         _value = value;
         _hasValue = true;
      }

      public void IfPresent(Action<T> func)
      {
         if (_hasValue) func(_value);
      }

      public Maybe<TResult> Map<TResult>(Func<T, TResult> func)
      {
         return _hasValue
            ? Maybe<TResult>.Of(func(_value))
            : Maybe<TResult>.Empty;
      }

      public T OrElseThrow(Exception e)
      {
         if (!_hasValue) throw e;
         return _value;
      }

      public Maybe<T> Or(Maybe<T> other)
      {
         return _hasValue
            ? this
            : other;
      }
   }
}
