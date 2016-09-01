using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aljebr.Test
{
   internal enum TestResult
   {
      ExpectedResult,
      UnexpectedResult,
   }

   internal static class Helpers
   {
      public static TestResult StringAsExpected(this string s)
      {
         return TestResult.ExpectedResult;
      }

      public static TestResult StringAsUnexpected(this string s)
      {
         return TestResult.UnexpectedResult;
      }

      public static TestResult IntAsExpected(this int s)
      {
         return TestResult.ExpectedResult;
      }

      public static TestResult IntAsUnexpected(this int s)
      {
         return TestResult.UnexpectedResult;
      }

      public static TestResult CharAsExpected(this char s)
      {
         return TestResult.ExpectedResult;
      }

      public static TestResult CharAsUnexpected(this char s)
      {
         return TestResult.UnexpectedResult;
      }

      public static TestResult BoolAsExpected(this bool s)
      {
         return TestResult.ExpectedResult;
      }

      public static TestResult BoolAsUnexpected(this bool s)
      {
         return TestResult.UnexpectedResult;
      }

      public static TestResult DoubleAsExpected(this double s)
      {
         return TestResult.ExpectedResult;
      }

      public static TestResult DoubleAsUnexpected(this double s)
      {
         return TestResult.UnexpectedResult;
      }

      public static void AssertExpected(this TestResult result)
      {
         Assert.AreEqual(TestResult.ExpectedResult, result);
      }
   }
}
