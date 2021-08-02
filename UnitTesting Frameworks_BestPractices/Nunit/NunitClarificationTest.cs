using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace UnitTesting_Frameworks_BestPractices.Nunit
{
    [TestFixture]
    public class NunitClarificationTest
    {
        #region Classical Assertion
        [Test]
        public void Assert_Inconclusive()
        {
            // Arrange
            // Act
            // Assert
            Assert.Inconclusive();
        }
         
        [Test]
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
        [Test]
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
            CollectionAssert.IsSubsetOf(subset, superset, "Not Subset");
        }
        [Test]
        public void AssertFail()
        {
            // just failing the test Case
            Assert.Fail();
        }
        [Test]
        public void AreSame()
        {
            object A = new string("Ahmed");
            object B = A;
            //object B = new string("Ahmed");
            Assert.AreSame(A, B, "the 2 object Are Not the Same");
        }
        [Test]
        public void AreNotSame()
        {
            object A = new string("Ahmed");
            object B = new string("Ahmed");
            Assert.AreNotSame(A, B, "the 2 object Are Not the Same");
        }
        [Test]
        public void ReferenceEquals()
        {
            object A = new string("Ahmed");
            object B = A;
            //object B = new string("Ahmed");
            Assert.ReferenceEquals(A, B);
        }
        [Test]
        public void IsNull()
        {
            object A = null;
            Assert.IsNull(A);
        }
        [Test]
        public void IsNotNull()
        {
            object A = true;
            Assert.IsNotNull(A);
        }
        [Test]
        public void IsInstanceOfType()
        {
            object A = true;
            Assert.IsInstanceOf<bool>(A, " this is not string type");
        }
        [Test]
        public void IsNotInstanceOfType()
        {
            object A = null;
            Assert.IsNotInstanceOf(typeof(bool), A);
        }


        [Test]
        public void StringAssertStartsWith()
        {
            object A = "Football";
            StringAssert.StartsWith("Foot" ,A as string );
        }
        [Test]
        public void StringAssertEndsWith()
        {
            object A = "Football";
            StringAssert.EndsWith("ball" , A as string );
        }
        [Test]
        public void StringAssertContains()
        {
            
            string superstring = "ABCDEFGH";
            string substring = "CD";
            StringAssert.Contains( substring , superstring, "{0} Does not contain {1}", superstring, substring);

        }
        [Test]
        public void StringAssertEquals()
        {
            object A = "Football";
            string B = A.ToString();
            StringAssert.Equals(A as string,  B);
        }
        [Test]
        public void StringAssertMatches()
        {
            // Arrange
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // Assert
            StringAssert.IsMatch(regex.ToString(), "m_khalil82@hotmail.com", "This is not a valid Email");
            //StringAssert.Matches("qwerty", regex, "This is not a valid Email");
        }
        [Test]
        public void StringAssertDoesNotMatch()
        {
            // Arrange
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // Assert
            StringAssert.DoesNotMatch(regex.ToString(), "qwerty", "This is not a valid Email");
        }

        #endregion

        #region Constrained-based Syntax
        [Test]
        public void AssertThat()
        {
            var myString = "Football";
            //Assert.That(A as string, "Football");
            Assert.That(myString, Is.EqualTo("Hello"));
            Assert.That(myString, new EqualConstraint("Hello"));
        }

        [Test]
        public void AssertHasThat()
        {
            int Value = 35;
            int[] iarray = new int[] { 1, 2, 3 };
            string[] sarray = new string[] { "a", "b", "c" };
            Assert.That(Value, Is.Positive);
            Assert.That(Value, Is.Negative);
            Assert.That(Value, Is.InRange(1, 100));

            Assert.That(iarray, Is.All.Not.Null);
            Assert.That(iarray, Is.All.Not.Null);
            Assert.That(iarray, Is.All.Not.Null);
            Assert.That(iarray, Is.All.Not.Null);
            Assert.That(sarray, Is.All.InstanceOf(typeof(string)));
            Assert.That(iarray, Is.All.GreaterThan(0));
            Assert.That(iarray, Has.All.GreaterThan(0));
        }

        #endregion

        [Test]
        public void CollectionAssertAreEqual()
        {
            //Arrange
            List<string> expected = new List<string>()
            { "A" , "B" , "C" ,"D" };
            List<string> actual = new List<string>()
            { "A" , "B" , "C"  ,"D" };
            //Act
            //Assert
            CollectionAssert.AreEqual(expected, actual, "Not the same");
        }
        [Test]
        public void CollectionAssertAreNotEqual()
        {
            //Arrange
            List<string> expected = new List<string>()
            { "A" , "B" , "C" ,"D" };
            List<string> actual = new List<string>()
            { "A" , "B" , "C"   };
            //Act
            //Assert
            CollectionAssert.AreNotEqual(expected, actual, "Not the same");
        }
        [Test]
        public void CollectionAssertAreEquivalent()
        {
            //Arrange
            List<string> expected = new List<string>()
            { "A" , "B" , "C" ,"D" };
            List<string> actual = new List<string>()
            { "A" , "B" , "C"  ,"D" };
            //Act
            //Assert
            CollectionAssert.AreEquivalent(expected, actual, "Not the same");
        }
        [Test]
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
        [Test]
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
        [Test]
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
        [Test]
        public void CollectionAssertAllItemsAreNotNull()
        {
            //Arrange
            List<string> Collection = new List<string>()
            { "A" , "B" , "C" ,"D" };
            //Act
            //Assert
            CollectionAssert.AllItemsAreNotNull(Collection, "Not Contains");
        }
        [Test]
        public void CollectionAssertAllItemsAreInstancesOfType()
        {
            //Arrange
            List<string> Collection = new List<string>()
            { "A" , "B" , "C" ,"D" };
            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(Collection, typeof(string), "Not Contains");
        }
        [Test]
        public void CollectionAssertAllItemsAreUnique()
        {
            //Arrange
            List<string> Collection = new List<string>()
            { "A" , "B" , "C" ,"D" };
            //Assert
            CollectionAssert.AllItemsAreUnique(Collection, "Not Contains");
        }

        #region Functions Exatras Nunit Classical Functions
        [Test]
        public void Greater()
        {
            int Bigest = 150;
            int Smallest = 140;
            Assert.Greater(Bigest, Smallest, "the Bigest Are Not Greater Smallest");
        }
        [Test]
        public void GreaterOrEqual()
        {
            int Bigest = 150;
            int Smallest = 150;
            Assert.GreaterOrEqual(Bigest, Smallest, "the Bigest Are Not Greater Or Equal Smallest");
        }
        [Test]
        public void Less()
        {
            int Bigest = 150;
            int Smallest = 140;
            Assert.Less(Smallest,  Bigest, "the Bigest Are Not Less Smallest");
        }
        [Test]
        public void LessOrEqual()
        {
            int Bigest = 150;
            int Smallest = 150;
            Assert.LessOrEqual(Bigest, Smallest, "the Bigest Are Not Less Or Equal Smallest");
        }
        [Test]
        public void IsNotEmpty()
        {
            string Word = "Ahmed";
            Assert.IsNotEmpty(Word, "the Word Are Not Empty");
        }
        [Test]
        public void IsEmpty()
        {
            string Word = "";
            Assert.IsEmpty(Word, "the Word Are Not Empty");
        }
        [Test]
        public void Negative()
        {
            int number = -20;
            Assert.Negative(number, "the number Are Not Negative");
        }
        [Test]
        public void Positive()
        {
            int number = 20;
            Assert.Positive(number, "the number Are Not Positive");
        }
        [Test]
        public void Pass()
        {
            Assert.Pass("Any Pass Message");
        }
        [Test]
        public void Zero()
        {
            int number = 0;
            Assert.Zero(number, "the number Is Zero");
        }
        [Test]
        public void NotZero()
        {
            int number = 20;
            Assert.NotZero(number, "the number Is Zero");
        }
        [Test]
        public void IsNaN()
        {
            int number = 20;
            Assert.IsNaN(number, "the number Is Not NaN");
        }
      
        [Test]
        public void Multiple()
        {
            Assert.Multiple(() =>
            {
                Assert.That(2 + 2, Is.EqualTo(4));
                Assert.That(true, Is.EqualTo(5.2));
                Assert.That(true, Is.EqualTo(3.9));
            });
        }
        [Test]
        public void Ignore()
        {
            Assert.Ignore("the test case Is Ignore");
        }
        [Test]
        public void Warn()
        {
            Assert.Warn("the test case Is Warn");
        }
         
        [Test]
        public void Catch()
        {
            Assert.Catch(null, "the test case Is Warn");
        }
        [Test]
        public void AreEqualIgnoringCase()
        {
            object A = "Football";
            StringAssert.AreEqualIgnoringCase(A as string, "Football");
        }
        [Test]
        public void AreNotEqualIgnoringCase()
        {
            object A = "Football";
            StringAssert.AreNotEqualIgnoringCase(A as string, "Vollyball");
        }
        #endregion



    }
}
