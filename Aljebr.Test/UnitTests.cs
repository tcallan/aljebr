using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aljebr.Test
{
   [TestClass]
   public class UnitTests
   {
      [TestMethod]
      public void TestLiftDoesStuffWhenCalled1()
      {
         var called = false;
         Action<bool> action = param => called = param;

         Unit.Lift(action)(true);

         Assert.IsTrue(called);
      }

      [TestMethod]
      public void TestLiftDoesStuffWhenCalled2()
      {
         var result = string.Empty;
         Action<string> action = param => result = param;

         Unit.Lift(action)("foo");

         Assert.AreEqual("foo", result);
      }

      [TestMethod]
      public void TestLiftDoesNotDoStuffWhenNotCalled()
      {
         var called = false;
         Action<bool> action = param => called = true;

         Unit.Lift(action);

         Assert.IsFalse(called);
      }

      [TestMethod]
      public void TestLiftReturnsUnit()
      {
         Action<string> action = Console.WriteLine;

         var result = Unit.Lift(action)("foo");

         Assert.AreEqual(Unit.Value, result);
      }

      [TestMethod]
      public void TestLiftWorksAsExpectedWithMatching1()
      {
         var union = new Union<char, int>('c');
         var result = TestResult.UnexpectedResult;

         union.With<Unit>()
            .Match(Unit.Lift<char>(c => result = c.CharAsExpected()))
            .Match(Unit.Lift<int>(i => result = i.IntAsUnexpected()))
            .Do();

         result.AssertExpected();
      }

      [TestMethod]
      public void TestLiftWorksAsExpectedWithMatching2()
      {
         var union = new Union<char, int>(12);
         var result = TestResult.UnexpectedResult;

         union.With<Unit>()
            .Match(Unit.Lift<char>(c => result = c.CharAsUnexpected()))
            .Match(Unit.Lift<int>(i => result = i.IntAsExpected()))
            .Do();

         result.AssertExpected();
      }
   }
}
