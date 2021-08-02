using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UnitTesting_Frameworks_BestPractices.MSTest
{
    [TestClass]
    public class MSTestClarificationTest
    {
        [TestMethod]
        public void Assert_Inconclusive()
        {
            /* enables you to indicate that the test result 
              cannot be verified as a pass or fail.
              is typically a temporary measure 
              until a unittest (or the related implementation) has
            */
            // Arrange
            // Act
            // Assert
            Assert.Inconclusive();
        }
        [TestMethod]
        public void Test_ListsAreEqual_Passes()
        {
            //Arrange
            List<string> expected = new List<string>();
            expected.Add("A");
            expected.Add("B");
            expected.Add("C");

            List<string> actual = new List<string>();
            actual.Add("A");
            actual.Add("B");
            actual.Add("C");
            //Act

            //Assert
            CollectionAssert.AreEqual(expected, actual, "Not the same");
        }
        [TestMethod]
        public void Test_ListIsSubsetOfAnother_Passes()
        {
            //Arrange

            List<string> superset = new List<string>();
            superset.Add("A");
            superset.Add("B");
            superset.Add("C");

            List<string> subset = new List<string>();
            subset.Add("B");
            subset.Add("A");
            subset.Add("C");
            //Act
            //Assert
            CollectionAssert.IsSubsetOf(subset, superset, "Not Subset");
        }
        [TestMethod]
        public void ListsAreEqual_Passes()
        {
            //Arrange
            List<string> expected = new List<string>();
            expected.Add("A");
            expected.Add("B");
            expected.Add("C");

            List<string> actual = new List<string>();
            actual.Add("A");
            actual.Add("B");
            actual.Add("C");

            //Act

            //Assert
            CollectionAssert.AreEqual(expected, actual, "Not the same");
        }
        [TestMethod]
        public void ListIsSubsetOfAnother_Passes()
        {
            //Arrange
            List<string> subset = new List<string>();
            subset.Add("A");
            subset.Add("B");
            subset.Add("C");

            List<string> superset = new List<string>();
            superset.Add("A");
            superset.Add("B");
            superset.Add("C");
            superset.Add("D");
            superset.Add("E");

            //Act

            //Assert
            CollectionAssert.IsSubsetOf(subset, superset, "Not Subset");
        }
        [TestMethod]
        public void AssertFail()
        {
            // just failing the test Case
            //Used to immediately fail a test
            Assert.Fail();
        }
        [TestMethod]
        public void AreSame()
        {
  /*
    Similar to Assert.AreEqual & Assert.AreNotEqual, 
    but compare thereferences of the supplied arguments
    ensure that properties return expected instances or that 
    collections handle references correctly
     
  */
            object A = new string("Ahmed");
            object B = A;
            //object B = new string("Ahmed");
            Assert.AreSame(A,B,"the 2 object Are Not the Same");
        }
        [TestMethod]
        public void AreNotSame()
        {
            object A = new string("Ahmed");
            object B = new string("Ahmed");
            Assert.AreNotSame(A, B, "the 2 object Are Not the Same");
        }
        [TestMethod]
        public void ReferenceEquals()
        {
            object A = new string("Ahmed");
            object B = new string("Ahmed");
            Assert.ReferenceEquals(A, B);
        }
        [TestMethod]
        public void IsNull()
        {
            object A = null;
            Assert.IsNull(A );
        }
        [TestMethod]
        public void IsNotNull()
        {
            object A = true;
            Assert.IsNotNull(A);
        }
        [TestMethod]
        public void IsInstanceOfType()
        {
            object A = true;
            Assert.IsInstanceOfType(A, typeof(bool));
        }
        [TestMethod]
        public void IsNotInstanceOfType()
        {
            object A = null;
            Assert.IsNotInstanceOfType(A, typeof(bool));
        }
        [TestMethod]
        public void StringAssertStartsWith()
        {
            object A = "Football" ;
            StringAssert.StartsWith(A as string, "Foot");
        }
        [TestMethod]
        public void StringAssertEndsWith()
        {
            object A = "Football";
            StringAssert.EndsWith(A as string, "ball");
        }
        [TestMethod]
        public void StringAssertContains()
        {
            //object A = "Football";
            //StringAssert.Contains(A as string, "otbal");
            // Arrange
            string superstring = "ABCDEFGH";
            string substring = "CD";
            StringAssert.Contains(superstring, substring, "{0} Does not contain {1}", superstring, substring);

        }
        [TestMethod]
        public void StringAssertEquals()
        {
            object A = "Football";
            StringAssert.Equals(A as string, "Football");
        }
        [TestMethod]
        public void StringAssertMatches()
        {
            // Arrange
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // Act
            // Assert
            StringAssert.Matches("m_khalil82@hotmail.com", regex, "This is not a valid Email");
            //StringAssert.Matches("qwerty", regex, "This is not a valid Email");
        }
        [TestMethod]
        public void StringAssertDoesNotMatch()
        {
            // Arrange
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // Assert
            StringAssert.DoesNotMatch("qwerty", regex, "This is not a valid Email");
        }
        [TestMethod]
        public void CollectionAssertAreEqual()
        {
            // Ensures that two collections have reference-equivalent Members
            //Arrange
            List<string> expected = new List<string>()
            { "A" , "B" , "C" ,"D" };
            List<string> actual = expected;
            //List<string> actual = new List<string>()
            //{ "A" , "B" , "C"   };
            //Act
            //Assert
            CollectionAssert.AreEqual(expected, actual, "Not the same");
        }
        [TestMethod]
        public void CollectionAssertAreNotEqual()
        {
            //Ensures that two collections do not have reference- equivalent Members


            //Arrange
            List<string> expected = new List<string>()
            { "A" , "B" , "C" ,"D" };
            List<string> actual = new List<string>()
            { "A" , "B" , "C"   };
            //Act
            //Assert
            CollectionAssert.AreNotEqual(expected, actual, "Not the same");
        }
        [TestMethod]
        public void CollectionAssertAreEquivalent()
        {
            //Arrange
            List<string> expected = new List<string>()
            { "A" , "B" , "C" };
            List<string> actual = new List<string>()
            { "A" , "B" , "C"   };
            //Act
            //Assert
            CollectionAssert.AreEquivalent(expected, actual, "Not the same");
        }
        [TestMethod]
        public void CollectionAssertAreNotEquivalent()
        {
            //Arrange
            List<string> expected = new List<string>()
            { "A" , "B" , "C" ,"D" };
            List<string> actual = new List<string>()
            { "A" , "B" , "C"   };
            //Act
            //Assert
            CollectionAssert.AreNotEquivalent(expected, actual, "Not the same");
        }
        [TestMethod]
        public void CollectionAssertContains()
        {
            //Arrange
            List<string> Collection = new List<string>()
            { "A" , "B" , "C" ,"D" };
            string element = "A";
            //Act
            //Assert
            CollectionAssert.Contains(Collection, element, "Not Contains");
        }
        [TestMethod]
        public void CollectionAssertDoesNotContain()
        {
            //Arrange
            List<string> Collection = new List<string>()
            { "A" , "B" , "C" ,"D" };
            string element = "F";
            //Act
            //Assert
            CollectionAssert.DoesNotContain(Collection, element, "Not Contains");
        }
        [TestMethod]
        public void CollectionAssertAllItemsAreNotNull()
        {
            //Arrange
            List<string> Collection = new List<string>()
            { "A" , "B" , "C" ,"D" };
            //Act
            //Assert
            CollectionAssert.AllItemsAreNotNull(Collection, "Not Contains");
        }
        [TestMethod]
        public void CollectionAssertAllItemsAreInstancesOfType()
        {
            //Arrange
            List<string> Collection = new List<string>()
            { "A" , "B" , "C" ,"D" };
            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(Collection, typeof(string) ,"Not Contains");
        }
        [TestMethod]
        public void CollectionAssertAllItemsAreUnique()
        {
            //Searches a collection, failing if a duplicate member is found

            //Arrange
            List<string> Collection = new List<string>()
            { "A" , "B" , "C" ,"D" };
            //Assert
            CollectionAssert.AllItemsAreUnique(Collection, "Not Contains");
        }
    }
}
