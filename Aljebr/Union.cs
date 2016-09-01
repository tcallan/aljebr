using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aljebr
{
   public class Union<T1, T2>
   {
      public Union(T1 v1)
      {
         V1 = Maybe<T1>.Of(v1);
         V2 = Maybe<T2>.Empty;
      }

      public Union(T2 v2)
      {
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Of(v2);
      }

      internal Maybe<T1> V1 { get; }

      internal Maybe<T2> V2 { get; }

      public Matcher<T1, T2, TResult> With<TResult>()
      {
         return new Matcher<T1, T2, TResult>(this);
      }
   }

   public class Union<T1, T2, T3>
   {
      public Union(T1 v1)
      {
         V1 = Maybe<T1>.Of(v1);
         V2 = Maybe<T2>.Empty;
         V3 = Maybe<T3>.Empty;
      }

      public Union(T2 v2)
      {
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Of(v2);
         V3 = Maybe<T3>.Empty;
      }

      public Union(T3 v3)
      {
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Empty;
         V3 = Maybe<T3>.Of(v3);
      }

      internal Union()
      {
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Empty;
         V3 = Maybe<T3>.Empty;
      }

      internal Maybe<T1> V1 { get; }

      internal Maybe<T2> V2 { get; }

      internal Maybe<T3> V3 { get; }

      public Matcher<T1, T2, T3, TResult> With<TResult>()
      {
         return new Matcher<T1, T2, T3, TResult>(this);
      }
   }

   public class Union<T1, T2, T3, T4>
   {
      public Union(T1 v1)
      {
         V1 = Maybe<T1>.Of(v1);
         V2 = Maybe<T2>.Empty;
         V3 = Maybe<T3>.Empty;
         V4 = Maybe<T4>.Empty;
      }

      public Union(T2 v2)
      {
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Of(v2);
         V3 = Maybe<T3>.Empty;
         V4 = Maybe<T4>.Empty;
      }

      public Union(T3 v3)
      {
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Empty;
         V3 = Maybe<T3>.Of(v3);
         V4 = Maybe<T4>.Empty;
      }

      public Union(T4 v4)
      {
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Empty;
         V3 = Maybe<T3>.Empty;
         V4 = Maybe<T4>.Of(v4);
      }

      internal Maybe<T1> V1 { get; }

      internal Maybe<T2> V2 { get; }

      internal Maybe<T3> V3 { get; }

      internal Maybe<T4> V4 { get; }

      public Matcher<T1, T2, T3, T4, TResult> With<TResult>()
      {
         return new Matcher<T1, T2, T3, T4, TResult>(this);
      }
   }

   public class Union<T1, T2, T3, T4, T5>
   {
      public Union(T1 v1)
      {
         V1 = Maybe<T1>.Of(v1);
         V2 = Maybe<T2>.Empty;
         V3 = Maybe<T3>.Empty;
         V4 = Maybe<T4>.Empty;
         V5 = Maybe<T5>.Empty;
      }

      public Union(T2 v2)
      {
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Of(v2);
         V3 = Maybe<T3>.Empty;
         V4 = Maybe<T4>.Empty;
         V5 = Maybe<T5>.Empty;

      }

      public Union(T3 v3)
      {
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Empty;
         V3 = Maybe<T3>.Of(v3);
         V4 = Maybe<T4>.Empty;
         V5 = Maybe<T5>.Empty;
      }

      public Union(T4 v4)
      {
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Empty;
         V3 = Maybe<T3>.Empty;
         V4 = Maybe<T4>.Of(v4);
         V5 = Maybe<T5>.Empty;
      }

      public Union(T5 v5)
      {
         
         V1 = Maybe<T1>.Empty;
         V2 = Maybe<T2>.Empty;
         V3 = Maybe<T3>.Empty;
         V4 = Maybe<T4>.Empty;
         V5 = Maybe<T5>.Of(v5);
      }

      internal Maybe<T1> V1 { get; }

      internal Maybe<T2> V2 { get; }

      internal Maybe<T3> V3 { get; }

      internal Maybe<T4> V4 { get; }

      internal Maybe<T5> V5 { get; }

      public Matcher<T1, T2, T3, T4, T5, TResult> With<TResult>()
      {
         return new Matcher<T1, T2, T3, T4, T5, TResult>(this);
      }
   }
}
