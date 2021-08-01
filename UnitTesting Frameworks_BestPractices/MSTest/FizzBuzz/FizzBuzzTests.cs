using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Production_Code;
namespace UnitTesting_Frameworks_BestPractices.MSTest
{
    [TestClass]
    public class FizzBuzzTests
    {
       [TestMethod]
        public void FizzBuzz_Input9_ReturnsFizz()
        {
            //Arrange

            FizzBuzz fb = new FizzBuzz();

            string expected = "Fizz";
            string actual = fb.CheckFizzBuzz(9);

            Assert.AreEqual(expected, actual);

        }
       [TestMethod]
        public void FizzBuzz_Input10_ReturnsBuzz()
        {
            // Arrange

            FizzBuzz fb = new FizzBuzz();

            string expected = "Buzz";
            string actual = fb.CheckFizzBuzz(10);

            Assert.AreEqual(expected, actual);

        }
       [TestMethod]
        public void FizzBuzz_Input15_ReturnsFizzBuzz()
        {
           // Arrange

           FizzBuzz fb = new FizzBuzz();

            string expected = "FizzBuzz";
            string actual = fb.CheckFizzBuzz(15);

            Assert.AreEqual(expected, actual);

        }
       [TestMethod]
        public void FizzBuzz_Input7_Returns7()
        {
           // Arrange

           FizzBuzz fb = new FizzBuzz();

            string expected = "7";
            string actual = fb.CheckFizzBuzz(7);

            Assert.AreEqual(expected, actual);
        }
    }

}
