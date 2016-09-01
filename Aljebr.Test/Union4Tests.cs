using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aljebr.Test
{
   [TestClass]
   public class Union4Tests
   {
      [TestMethod]
      public void TestExhaustive_First()
      {
         var union4 = new Union<string, char, int, bool>("foo");
         var result = union4.With<TestResult>()
            .Match(s => s.StringAsExpected())
            .Match(c => c.CharAsUnexpected())
            .Match(i => i.IntAsUnexpected())
            .Match(b => b.BoolAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustive_Second()
      {
         var union4 = new Union<string, char, int, bool>('a');
         var result = union4.With<TestResult>()
            .Match(s => s.StringAsUnexpected())
            .Match(c => c.CharAsExpected())
            .Match(i => i.IntAsUnexpected())
            .Match(b => b.BoolAsUnexpected())
            .Do();

         result.AssertExpected();
      }
      
      [TestMethod]
      public void TestExhaustive_Third()
      {
         var union4 = new Union<string, char, int, bool>(12);
         var result = union4.With<TestResult>()
            .Match(s => s.StringAsUnexpected())
            .Match(c => c.CharAsUnexpected())
            .Match(i => i.IntAsExpected())
            .Match(b => b.BoolAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustive_Fourth()
      {
         var union4 = new Union<string, char, int, bool>(true);
         var result = union4.With<TestResult>()
            .Match(s => s.StringAsUnexpected())
            .Match(c => c.CharAsUnexpected())
            .Match(i => i.IntAsUnexpected())
            .Match(b => b.BoolAsExpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_FirstMatch()
      {
         var union4 = new Union<string, char, int, bool>("foo");
         var result = union4.With<TestResult>()
            .Match(s => s.StringAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_FirstNoMatch()
      {
         var union4 = new Union<string, char, int, bool>("foo");
         var result = union4.With<TestResult>()
            .Match(c => c.CharAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_SecondMatch()
      {
         var union4 = new Union<string, char, int, bool>('a');
         var result = union4.With<TestResult>()
            .Match(c => c.CharAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_SecondNoMatch()
      {
         var union4 = new Union<string, char, int, bool>('a');
         var result = union4.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_ThirdMatch()
      {
         var union4 = new Union<string, char, int, bool>(12);
         var result = union4.With<TestResult>()
            .Match(i => i.IntAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_ThirdNoMatch()
      {
         var union4 = new Union<string, char, int, bool>(12);
         var result = union4.With<TestResult>()
            .Match(b => b.BoolAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_FourthMatch()
      {
         var union4 = new Union<string, char, int, bool>(true);
         var result = union4.With<TestResult>()
            .Match(b => b.BoolAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_FourthNoMatch()
      {
         var union4 = new Union<string, char, int, bool>(true);
         var result = union4.With<TestResult>()
            .Match(s => s.StringAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }
   }
}
