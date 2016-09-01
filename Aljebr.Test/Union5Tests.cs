using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aljebr.Test
{
   [TestClass]
   public class Union5Tests
   {
      [TestMethod]
      public void TestExhaustive_First()
      {
         var union5 = new Union<int, bool, string, char, double>(12);
         var result = union5.With<TestResult>()
            .Match(i => i.IntAsExpected())
            .Match(b => b.BoolAsUnexpected())
            .Match(s => s.StringAsUnexpected())
            .Match(c => c.CharAsUnexpected())
            .Match(d => d.DoubleAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustive_Second()
      {
         var union5 = new Union<int, bool, string, char, double>(false);
         var result = union5.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Match(b => b.BoolAsExpected())
            .Match(s => s.StringAsUnexpected())
            .Match(c => c.CharAsUnexpected())
            .Match(d => d.DoubleAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustive_Third()
      {
         var union5 = new Union<int, bool, string, char, double>("foo");
         var result = union5.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Match(b => b.BoolAsUnexpected())
            .Match(s => s.StringAsExpected())
            .Match(c => c.CharAsUnexpected())
            .Match(d => d.DoubleAsUnexpected())
            .Do();

         result.AssertExpected();
      }
      [TestMethod]
      public void TestExhaustive_Fourth()
      {
         var union5 = new Union<int, bool, string, char, double>('a');
         var result = union5.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Match(b => b.BoolAsUnexpected())
            .Match(s => s.StringAsUnexpected())
            .Match(c => c.CharAsExpected())
            .Match(d => d.DoubleAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustive_Fifth()
      {
         var union5 = new Union<int, bool, string, char, double>(2.6);
         var result = union5.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Match(b => b.BoolAsUnexpected())
            .Match(s => s.StringAsUnexpected())
            .Match(c => c.CharAsUnexpected())
            .Match(d => d.DoubleAsExpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_MatchFirst()
      {
         var union5 = new Union<int, bool, string, char, double>(12);
         var result = union5.With<TestResult>()
            .Match(i => i.IntAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_MatchSecond()
      {
         var union5 = new Union<int, bool, string, char, double>(false);
         var result = union5.With<TestResult>()
            .Match(b => b.BoolAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_MatchThird()
      {
         var union5 = new Union<int, bool, string, char, double>("foo");
         var result = union5.With<TestResult>()
            .Match(s => s.StringAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }
      [TestMethod]
      public void TestDefault_MatchFourth()
      {
         var union5 = new Union<int, bool, string, char, double>('a');
         var result = union5.With<TestResult>()
            .Match(c => c.CharAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_MatchFifth()
      {
         var union5 = new Union<int, bool, string, char, double>(2.6);
         var result = union5.With<TestResult>()
            .Match(d => d.DoubleAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_NoMatchFirst()
      {
         var union5 = new Union<int, bool, string, char, double>(12);
         var result = union5.With<TestResult>()
            .Match(d => d.DoubleAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_NoMatchSecond()
      {
         var union5 = new Union<int, bool, string, char, double>(false);
         var result = union5.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_NoMatchThird()
      {
         var union5 = new Union<int, bool, string, char, double>("foo");
         var result = union5.With<TestResult>()
            .Match(b => b.BoolAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }
      [TestMethod]
      public void TestDefault_NoMatchFourth()
      {
         var union5 = new Union<int, bool, string, char, double>('a');
         var result = union5.With<TestResult>()
            .Match(s => s.StringAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_NoMatchFifth()
      {
         var union5 = new Union<int, bool, string, char, double>(2.6);
         var result = union5.With<TestResult>()
            .Match(c => c.CharAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }
   }
}
