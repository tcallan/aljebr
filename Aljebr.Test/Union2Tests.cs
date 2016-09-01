using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aljebr.Test
{
   [TestClass]
   public class Union2Tests 
   {
      [TestMethod]
      public void TestUnion2_MatchFirstFirst()
      {
         var union2 = new Union<string, int>("foo");

         var result = union2.With<TestResult>()
            .Match(str => str.StringAsExpected())
            .Match(integ => integ.IntAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestUnion2_MatchFirstSecond()
      {
         var union2 = new Union<string, int>("foo");

         var result = union2.With<TestResult>()
            .Match(integ => integ.IntAsUnexpected())
            .Match(str => str.StringAsExpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestUnion2_MatchSecondFirst()
      {
         var union2 = new Union<string, int>(12);

         var result = union2.With<TestResult>()
            .Match(integ => integ.IntAsExpected())
            .Match(str => str.StringAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestUnion2_MatchSecondSecond()
      {
         var union2 = new Union<string, int>(12);

         var result = union2.With<TestResult>()
            .Match(str => str.StringAsUnexpected())
            .Match(integ => integ.IntAsExpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestUnion2_DefaultFirst()
      {
         var union2 = new Union<string, int>("foo");

         var result = union2.With<TestResult>()
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestUnion2_DefaultSecond()
      {
         var union2 = new Union<string, int>(3);

         var result = union2.With<TestResult>()
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestUnion2_FirstThenDefaultMatch()
      {
         var union2 = new Union<string, int>("foo");

         var result = union2.With<TestResult>()
            .Match(s => s.StringAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestUnion2_FirstThenDefaultNoMatch()
      {
         var union2 = new Union<string, int>(7);

         var result = union2.With<TestResult>()
            .Match(s => s.StringAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestUnion2_SecondThenDefaultMatch()
      {
         var union2 = new Union<string, int>(7);

         var result = union2.With<TestResult>()
            .Match(i => i.IntAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestUnion2_SecondThenDefaultNoMatch()
      {
         var union2 = new Union<string, int>("foo");

         var result = union2.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }
   }
}
