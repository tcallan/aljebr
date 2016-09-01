using System;

namespace Aljebr
{
   public class Matcher<TResult>
   {
      private readonly Maybe<Func<TResult>> _result;

      internal Matcher(Maybe<Func<TResult>> result)
      {
         _result = result;
      }

      public TResult Do()
      {
         return _result.OrElseThrow(new Exception("Something went terribly wrong"))();
      }
   }

   public class Matcher<T1, TResult>
   {
      private readonly Maybe<T1> _v1;
      private readonly Maybe<Func<TResult>> _result;

      internal Matcher(Maybe<T1> v1, Maybe<Func<TResult>> result)
      {
         _v1 = v1;
         _result = result;
      }

      public Matcher<TResult> Match(Func<T1, TResult> func)
      {
         var result = _result.Or(_v1.Map<Func<TResult>>(v1 => () => func(v1)));
         return new Matcher<TResult>(result);
      }

      public Matcher<TResult> Default(Func<TResult> func)
      {
         return new Matcher<TResult>(_result.Or(Maybe<Func<TResult>>.Of(func)));
      }
   }

   public class Matcher<T1, T2, TResult>
   {
      private readonly Maybe<T1> _v1;
      private readonly Maybe<T2> _v2;
      private readonly Maybe<Func<TResult>> _result;

      internal Matcher(Union<T1, T2> union)
      {
         _v1 = union.V1;
         _v2 = union.V2;
         _result = Maybe<Func<TResult>>.Empty;
      }

      internal Matcher(Maybe<T1> v1, Maybe<T2> v2, Maybe<Func<TResult>> result)
      {
         _v1 = v1;
         _v2 = v2;
         _result = result;
      }

      public Matcher<T2, TResult> Match(Func<T1, TResult> func)
      {
         var result = _result.Or(_v1.Map<Func<TResult>>(v1 => () => func(v1)));
         return new Matcher<T2, TResult>(_v2, result);
      }

      public Matcher<T1, TResult> Match(Func<T2, TResult> func)
      {
         var result = _result.Or(_v2.Map<Func<TResult>>(v2 => () => func(v2)));
         return new Matcher<T1, TResult>(_v1, result);
      }

      public Matcher<TResult> Default(Func<TResult> func)
      {
         return new Matcher<TResult>(_result.Or(Maybe<Func<TResult>>.Of(func)));
      }
   }

   public class Matcher<T1, T2, T3, TResult>
   {
      private readonly Maybe<T1> _v1;
      private readonly Maybe<T2> _v2;
      private readonly Maybe<T3> _v3;
      private readonly Maybe<Func<TResult>> _result;

      internal Matcher(Union<T1, T2, T3> union)
      {
         _v1 = union.V1;
         _v2 = union.V2;
         _v3 = union.V3;
         _result = Maybe<Func<TResult>>.Empty;
      }

      internal Matcher(Maybe<T1> v1, Maybe<T2> v2, Maybe<T3> v3, Maybe<Func<TResult>> result)
      {
         _v1 = v1;
         _v2 = v2;
         _v3 = v3;
         _result = result;
      }

      public Matcher<T2, T3, TResult> Match(Func<T1, TResult> func)
      {
         var result = _result.Or(_v1.Map<Func<TResult>>(v1 => () => func(v1)));
         return new Matcher<T2, T3, TResult>(_v2, _v3, result);
      }

      public Matcher<T1, T3, TResult> Match(Func<T2, TResult> func)
      {
         var result = _result.Or(_v2.Map<Func<TResult>>(v2 => () => func(v2)));
         return new Matcher<T1, T3, TResult>(_v1, _v3, result);
      }

      public Matcher<T1, T2, TResult> Match(Func<T3, TResult> func)
      {
         var result = _result.Or(_v3.Map<Func<TResult>>(v3 => () => func(v3)));
         return new Matcher<T1, T2, TResult>(_v1, _v2, result);
      }

      public Matcher<TResult> Default(Func<TResult> func)
      {
         return new Matcher<TResult>(_result.Or(Maybe<Func<TResult>>.Of(func)));
      }
   }

   public class Matcher<T1, T2, T3, T4, TResult>
   {
      private readonly Maybe<T1> _v1;
      private readonly Maybe<T2> _v2;
      private readonly Maybe<T3> _v3;
      private readonly Maybe<T4> _v4;
      private readonly Maybe<Func<TResult>> _result;

      internal Matcher(Union<T1, T2, T3, T4> union)
      {
         _v1 = union.V1;
         _v2 = union.V2;
         _v3 = union.V3;
         _v4 = union.V4;
         _result = Maybe<Func<TResult>>.Empty;
      }

      internal Matcher(Maybe<T1> v1, Maybe<T2> v2, Maybe<T3> v3, Maybe<T4> v4, Maybe<Func<TResult>> result)
      {
         _v1 = v1;
         _v2 = v2;
         _v3 = v3;
         _v4 = v4;
         _result = result;
      }

      public Matcher<T2, T3, T4, TResult> Match(Func<T1, TResult> func)
      {
         var result = _result.Or(_v1.Map<Func<TResult>>(v1 => () => func(v1)));
         return new Matcher<T2, T3, T4, TResult>(_v2, _v3, _v4, result);
      }

      public Matcher<T1, T3, T4, TResult> Match(Func<T2, TResult> func)
      {
         var result = _result.Or(_v2.Map<Func<TResult>>(v2 => () => func(v2)));
         return new Matcher<T1, T3, T4, TResult>(_v1, _v3, _v4, result);
      }

      public Matcher<T1, T2, T4, TResult> Match(Func<T3, TResult> func)
      {
         var result = _result.Or(_v3.Map<Func<TResult>>(v3 => () => func(v3)));
         return new Matcher<T1, T2, T4, TResult>(_v1, _v2, _v4, result);
      }

      public Matcher<T1, T2, T3, TResult> Match(Func<T4, TResult> func)
      {
         var result = _result.Or(_v4.Map<Func<TResult>>(v4 => () => func(v4)));
         return new Matcher<T1, T2, T3, TResult>(_v1, _v2, _v3, result);
      }

      public Matcher<TResult> Default(Func<TResult> func)
      {
         return new Matcher<TResult>(_result.Or(Maybe<Func<TResult>>.Of(func)));
      }
   }

   public class Matcher<T1, T2, T3, T4, T5, TResult>
   {
      private readonly Maybe<T1> _v1;
      private readonly Maybe<T2> _v2;
      private readonly Maybe<T3> _v3;
      private readonly Maybe<T4> _v4;
      private readonly Maybe<T5> _v5;
      private readonly Maybe<Func<TResult>> _result;

      internal Matcher(Union<T1, T2, T3, T4, T5> union)
      {
         _v1 = union.V1;
         _v2 = union.V2;
         _v3 = union.V3;
         _v4 = union.V4;
         _v5 = union.V5;
         _result = Maybe<Func<TResult>>.Empty;
      }

      public Matcher<T2, T3, T4, T5, TResult> Match(Func<T1, TResult> func)
      {
         var result = _result.Or(_v1.Map<Func<TResult>>(v1 => () => func(v1)));
         return new Matcher<T2, T3, T4, T5, TResult>(_v2, _v3, _v4, _v5, result);
      }

      public Matcher<T1, T3, T4, T5, TResult> Match(Func<T2, TResult> func)
      {
         var result = _result.Or(_v2.Map<Func<TResult>>(v2 => () => func(v2)));
         return new Matcher<T1, T3, T4, T5, TResult>(_v1, _v3, _v4, _v5, result);
      }

      public Matcher<T1, T2, T4, T5, TResult> Match(Func<T3, TResult> func)
      {
         var result = _result.Or(_v3.Map<Func<TResult>>(v3 => () => func(v3)));
         return new Matcher<T1, T2, T4, T5, TResult>(_v1, _v2, _v4, _v5, result);
      }

      public Matcher<T1, T2, T3, T5, TResult> Match(Func<T4, TResult> func)
      {
         var result = _result.Or(_v4.Map<Func<TResult>>(v4 => () => func(v4)));
         return new Matcher<T1, T2, T3, T5, TResult>(_v1, _v2, _v3, _v5, result);
      }

      public Matcher<T1, T2, T3, T4, TResult> Match(Func<T5, TResult> func)
      {
         var result = _result.Or(_v5.Map<Func<TResult>>(v5 => () => func(v5)));
         return new Matcher<T1, T2, T3, T4, TResult>(_v1, _v2, _v3, _v4, result);
      }
   }
}
