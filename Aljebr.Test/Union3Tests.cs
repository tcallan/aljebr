using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aljebr.Test
{
   [TestClass]
   public class Union3Tests
   {
      [TestMethod]
      public void TestExhaustiveMatch_First1()
      {
         var union3 = new Union<int, string, char>(7);

         var result = union3.With<TestResult>()
            .Match(i => i.IntAsExpected())
            .Match(s => s.StringAsUnexpected())
            .Match(c => c.CharAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustiveMatch_First2()
      {
         var union3 = new Union<int, string, char>(7);

         var result = union3.With<TestResult>()
            .Match(s => s.StringAsUnexpected())
            .Match(i => i.IntAsExpected())
            .Match(c => c.CharAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustiveMatch_First3()
      {
         var union3 = new Union<int, string, char>(7);

         var result = union3.With<TestResult>()
            .Match(i => i.IntAsExpected())
            .Match(c => c.CharAsUnexpected())
            .Match(s => s.StringAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustiveMatch_Second1()
      {
         var union3 = new Union<int, string, char>("foo");

         var result = union3.With<TestResult>()
            .Match(s => s.StringAsExpected())
            .Match(c => c.CharAsUnexpected())
            .Match(i => i.IntAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustiveMatch_Second2()
      {
         var union3 = new Union<int, string, char>("foo");

         var result = union3.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Match(s => s.StringAsExpected())
            .Match(c => c.CharAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustiveMatch_Second3()
      {
         var union3 = new Union<int, string, char>("foo");

         var result = union3.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Match(c => c.CharAsUnexpected())
            .Match(s => s.StringAsExpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustiveMatch_Third1()
      {
         var union3 = new Union<int, string, char>('a');

         var result = union3.With<TestResult>()
            .Match(c => c.CharAsExpected())
            .Match(i => i.IntAsUnexpected())
            .Match(s => s.StringAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustiveMatch_Third2()
      {
         var union3 = new Union<int, string, char>('a');

         var result = union3.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Match(c => c.CharAsExpected())
            .Match(s => s.StringAsUnexpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestExhaustiveMatch_Third3()
      {
         var union3 = new Union<int, string, char>('a');

         var result = union3.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Match(s => s.StringAsUnexpected())
            .Match(c => c.CharAsExpected())
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_FirstMatch()
      {
         var union3 = new Union<int, string, char>(7);

         var result = union3.With<TestResult>()
            .Match(i => i.IntAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_FirstNoMatch1()
      {
         
         var union3 = new Union<int, string, char>(7);

         var result = union3.With<TestResult>()
            .Match(s => s.StringAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_FirstNoMatch2()
      {
         
         var union3 = new Union<int, string, char>(7);

         var result = union3.With<TestResult>()
            .Match(c => c.CharAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_SecondMatch()
      {
         var union3 = new Union<int, string, char>("foo");

         var result = union3.With<TestResult>()
            .Match(s => s.StringAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_SecondNoMatch1()
      {
         var union3 = new Union<int, string, char>("foo");

         var result = union3.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_SecondNoMatch2()
      {
         var union3 = new Union<int, string, char>("foo");

         var result = union3.With<TestResult>()
            .Match(c => c.CharAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_ThirdMatch()
      {
         
         var union3 = new Union<int, string, char>('a');

         var result = union3.With<TestResult>()
            .Match(c => c.CharAsExpected())
            .Default(() => TestResult.UnexpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_ThirdNoMatch1()
      {
         
         var union3 = new Union<int, string, char>('a');

         var result = union3.With<TestResult>()
            .Match(i => i.IntAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestDefault_ThirdNoMatch2()
      {
         
         var union3 = new Union<int, string, char>('a');

         var result = union3.With<TestResult>()
            .Match(s => s.StringAsUnexpected())
            .Default(() => TestResult.ExpectedResult)
            .Do();

         result.AssertExpected();
      }
   }
}
