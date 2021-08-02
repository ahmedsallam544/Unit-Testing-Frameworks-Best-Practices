using Xunit;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Production_Code;

namespace UnitTesting_Frameworks_BestPractices.Xunit
{
    public class XunitClarificationTest
    {

        [Fact]
        public void Assert_Contains()
        {
            // Arrange
            string superstring = "ABCDEFGH";
            string substring = "CD";
            //string substring = "XYZ";
            // Act
            // Assert
            Assert.Contains(  substring , superstring );
        }
        [Fact]
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
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AreSame()
        {
            object A = new string("Ahmed");
            object B = A;
            Assert.Same(A, B);
        }
        [Fact]
        public void AreNotSame()
        {
            object A = new string("Ahmed");
            object B = new string("Ahmed");
            Assert.NotSame(A, B);
        }
        [Fact]
        public void IsNull()
        {
            object A = null;
            Assert.Null(A);
        }
        [Fact]
        public void IsNotNull()
        {
            object A = true;
            Assert.NotNull(A);
        }
        [Fact]
        public void IsInstanceOfType()
        {
            object A = true;
            Assert.IsType<bool>(A);
        }
        [Fact]
        public void IsNotInstanceOfType()
        {
            object A = null;
            Assert.IsNotType(typeof(bool), A);
        }
        [Fact]
        public void AssertStartsWith()
        {
            object A = "Football";
            Assert.StartsWith("Foot" , A as string  );
        }
        [Fact]
        public void AssertEndsWith()
        {
            object A = "Football";
            Assert.EndsWith("ball" , A as string);
        }
        [Fact]
        public void AssertContains()
        {
            //object A = "Football";
            //Assert.Contains(A as string, "otbal");
            // Arrange
            string superstring = "ABCDEFGH";
            string substring = "CD";
            Assert.Contains( substring , superstring);

        }
        [Fact]
        public void AssertEquals()
        {
            object A = "Football";
            Assert.Equal(A as string, "Football");
        }
        [Fact]
        public void AssertMatches()
        {
            // Arrange
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // Assert
            Assert.Matches(regex.ToString(), "m_khalil82@hotmail.com");
            //Assert.Matches("qwerty", regex, "This is not a valid Email");
        }
        [Fact]
        public void AssertDoesNotMatch()
        {
            // Arrange
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // Assert
            Assert.DoesNotMatch(regex.ToString(), "qwerty");
        }
        [Fact]
        public void AssertAreEqual()
        {
            //Arrange
            List<string> expected = new List<string>()
            { "A" , "B" , "C" ,"D" };
            List<string> actual = new List<string>()
            { "A" , "B" , "C" ,"D"  };
            //Act
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AssertAreNotEqual()
        {
            //Arrange
            List<string> expected = new List<string>()
            { "A" , "B" , "C" ,"D" };
            List<string> actual = new List<string>()
            { "A" , "B" , "C" ,"D"  };
            //Act
            //Assert
            Assert.Equal<string>(expected, actual);
        }
        [Fact]
        public void AssertContainsElement()
        {
            //Arrange
            List<string> Collection = new List<string>()
            { "A" , "B" , "C" ,"D" };
            string element = "A";
            //Act
            //Assert
            Assert.Contains(element, Collection);
        }
        [Fact]
        public void CollectionAssertDoesNotContain()
        {
            //Arrange
            List<string> Collection = new List<string>()
            { "A" , "B" , "C" ,"D" };
            string element = "F";
            //Act
            //Assert
            Assert.DoesNotContain(element, Collection);
        }

        #region Functions Exatras Nunit

        [Fact]
        public void IsNotEmpty()
        {
            string Word = "Ahmed";
            Assert.NotEmpty(Word);
        }
        [Fact]
        public void IsEmpty()
        {
            string Word = "";
            Assert.Empty(Word);
        }
        [Fact]
        public void AssertInRange()
        {
            //Arrange
            //Act
            //Assert
            Assert.InRange(1, 0, 100);
        }
        [Fact]
        public void AssertNotInRange()
        {
            //Assert
            Assert.NotInRange(1, 50, 100);
        }
        [Fact]
        public void AssertAll()
        {
            //Arrange
            List<int> Collection = new List<int>()
            { 100,200,300,400,500 };
            Assert.All(Collection, u => Assert.NotNull(u));
        }
        /*
         The first assertion is Assert.Raises, 
         it verifies that a event with the exact event args
         is raised. It requires a delegate for subscription,
         another delegate to unsubscribe. 
         Finally it accepts another delegate that execute 
         the action. The Assert.RaisesAny verifies 
         that an event with the exact or a derived event 
         args is raised. The accepted parameter for this method
         is the same as previous ones. Finally 
         Assert.RaisesAsync does the same thing as Assert.
         Raises but in an asynchronous manner. 
         We can see that instead of Action testCode 
         it receive a Func<Task> testCode.
         */
        [Fact]
        public async Task RaiseEventAssertions()
        {
            var messageSender = new Message();

            var receivedEvent = Assert.Raises<MessageEventArgs>(
             a => messageSender.SendMessageEvent += a,
             a => messageSender.SendMessageEvent -= a,
             () => messageSender.SendMessageToUser("This is an event message"));
            Assert.NotNull(receivedEvent);
            Assert.Equal("This is an event message", receivedEvent.Arguments.Message);

            var receivedEvent2 = Assert.RaisesAny<MessageEventArgs>(
            a => messageSender.SendMessageEvent += a,
            a => messageSender.SendMessageEvent -= a,
            () => messageSender.SendMessageToUser("This is an event message"));
            Assert.NotNull(receivedEvent2);
            Assert.Equal("This is an event message", receivedEvent2.Arguments.Message);

            var receivedEventTask = Assert.RaisesAsync<MessageEventArgs>(
            a => messageSender.SendMessageEvent += a,
            a => messageSender.SendMessageEvent -= a,
            async () => messageSender.SendMessageToUser("This is an event message"));
            var receivedEventAsync = await receivedEventTask;
            Assert.NotNull(receivedEventAsync);
            Assert.Equal("This is an event message", receivedEventAsync.Arguments.Message);
        }

        /*
         The first method uses Assert.Throws, it verifies that the exact exception is thrown (and not a derived exception type). Assert.ThrowsAny on the other hand verifies that the exact exception or a derived exception type is thrown. There are also the asynchronous version of these methods, namely Assert.ThrowsAsync and Assert.ThrowsAnyAsync. We can also use Record.Exception by passing the action in to see if it throws specific exception.
             */
        //[Fact]
        //public void ThrowsExceptionAssertions()
        //{
        //    var exceptionThrower = new Buggy();
        //    Assert.Throws<InvalidCastException>(exceptionThrower.ThrowsInvalidCastException);
        //    Assert.ThrowsAny<CustomInvalidOperationException>(exceptionThrower.ThrowsCustomInvalidOperationException);
        //}

        [Fact]
        public void ThrowsExceptionAssertionsAsync()
        {
            var exceptionThrower = new Buggy();

            Func<Task> ThrowExceptionFunc = () => exceptionThrower.ThrowsExceptionAsync();
            Assert.ThrowsAsync<InvalidCastException>(ThrowExceptionFunc);
            Assert.ThrowsAnyAsync<InvalidCastException>(ThrowExceptionFunc);
        }

        [Fact]
        public void ThrowsExceptionAssertionsRecord()
        {
            var exceptionThrower = new Buggy();
            Exception ex = Record.Exception(() => exceptionThrower.ThrowsInvalidCastException());
            Assert.NotNull(ex);
        }
          /*
         The first method uses Assert.All, 
         it verifies that all items in the collection pass 
         when executed against action. 
         Assert.Collection verifies that a collection contains
         exactly a given number of elements, 
         which meet the criteria provided by 
         the element inspectors. In other word 
         we pass a series of actions  into the assert to check 
         to see if elements of the collection are as expected. 
         Lastly there is the Assert.PropertyChanged, 
         Verifies that the provided object raised 
         INotifyPropertyChanged.PropertyChanged
         as a result of executing the given test code.
             */

        [Fact]
        public void AllNumberIsEven()
        {
            var numbers = new List<int> { 2, 4, 6 };
            Action<int> allAreEven = (a) =>
            {
                Assert.True(a % 2 == 0);
            };
            Assert.All(numbers, allAreEven);
        }

        [Fact]
        public void AllNumberAreEvenAndNotZero()
        {
            var numbers = new List<int> { 2, 4, 6 };
            Assert.Collection(numbers, a => Assert.True(a == 2), a => Assert.True(a == 4), a => Assert.True(a == 6));
            // Assert.All(result, item => Assert.True(a % 2 == 0));
        }
       
        #endregion

        //#region Asserts Not Exist in Xunit
        //[Fact]
        //public void Assert_Inconclusive()
        //{
        //    // Arrange
        //    // Act
        //    // Assert
        //    Assert.Inconclusive();
        //}
        //[Fact]
        //public void Test_ListIsSubsetOfAnother_Passes()
        //{
        //    //Arrange
        //    List<string> superset = new List<string>();
        //    superset.Add("A");
        //    superset.Add("B");
        //    superset.Add("C");
        //    List<string> subset = new List<string>();
        //    subset.Add("B");
        //    subset.Add("A");

        //    subset.Add("C");
        //    Assert.ProperSubset<string>(subset, superset, "Not Subset");
        //}
        //[Fact]
        //public void AssertFail()
        //{
        //    // just failing the test Case
        //    Assert.Fail();
        //}
        //[Fact]
        //public void ReferenceEquals()
        //{
        //    object A = new string("Ahmed");
        //    object B = new string("Ahmed");
        //    Assert.ReferenceEquals(A, B);
        //}
        //[Fact]
        //public void CollectionAssertAreEquivalent()
        //{
        //    //Arrange
        //    List<string> expected = new List<string>()
        //    { "A" , "B" , "C" ,"D" };
        //    List<string> actual = new List<string>()
        //    { "A" , "B" , "C"   };
        //    //Act
        //    //Assert
        //    Assert.AreEquivalent(expected, actual, "Not the same");
        //}
        //[Fact]
        //public void CollectionAssertAreNotEquivalent()
        //{
        //    //Arrange
        //    List<string> expected = new List<string>()
        //    { "A" , "B" , "C" ,"D" };
        //    List<string> actual = new List<string>()
        //    { "A" , "B" , "C"   };
        //    //Act
        //    //Assert
        //    Assert.AreNotEquivalent(expected, actual, "Not the same");
        //}
        //[Fact]
        //public void CollectionAssertAllItemsAreNotNull()
        //{
        //    //Arrange
        //    List<string> Collection = new List<string>()
        //    { "A" , "B" , "C" ,"D" };
        //    //Act
        //    //Assert
        //    Assert.AllItemsAreNotNull(Collection, "Not Contains");
        //}
        //[Fact]
        //public void CollectionAssertAllItemsAreInstancesOfType()
        //{
        //    //Arrange
        //    List<string> Collection = new List<string>()
        //    { "A" , "B" , "C" ,"D" };
        //    //Assert
        //    Assert.AllItemsAreInstancesOfType(Collection, typeof(string), "Not Contains");
        //}
        //[Fact]
        //public void CollectionAssertAllItemsAreUnique()
        //{
        //    //Arrange
        //    List<string> Collection = new List<string>()
        //    { "A" , "B" , "C" ,"D" };
        //    //Assert
        //    Assert.AllItemsAreUnique(Collection, "Not Contains");
        //}
        //[Fact]
        //public void Greater()
        //{
        //    int Bigest = 150;
        //    int Smallest = 140;
        //    Assert.Greater(Bigest, Smallest, "the Bigest Are Not Greater Smallest");
        //}
        //[Fact]
        //public void GreaterOrEqual()
        //{
        //    int Bigest = 150;
        //    int Smallest = 150;
        //    Assert.GreaterOrEqual(Bigest, Smallest, "the Bigest Are Not Greater Or Equal Smallest");
        //}
        //[Fact]
        //public void Less()
        //{
        //    int Bigest = 150;
        //    int Smallest = 140;
        //    Assert.Less(Bigest, Smallest, "the Bigest Are Not Less Smallest");
        //}
        //[Fact]
        //public void LessOrEqual()
        //{
        //    int Bigest = 150;
        //    int Smallest = 150;
        //    Assert.LessOrEqual(Bigest, Smallest, "the Bigest Are Not Less Or Equal Smallest");
        //}

        //[Fact]
        //public void Negative()
        //{
        //    int number = -20;
        //    Assert.Negative(number, "the number Are Not Negative");
        //}
        //[Fact]
        //public void Positive()
        //{
        //    int number = 20;
        //    Assert.Positive(number, "the number Are Not Positive");
        //}
        //[Fact]
        //public void Pass()
        //{
        //    Assert.Pass("Any Pass Message");
        //}

        //[Fact]
        //public void Zero()
        //{
        //    int number = 0;
        //    Assert.Zero(number, "the number Is Zero");
        //}
        //[Fact]
        //public void NotZero()
        //{
        //    int number = 20;
        //    Assert.NotZero(number, "the number Is Zero");
        //}
        //[Fact]
        //public void IsNaN()
        //{
        //    int number = 20;
        //    Assert.IsNaN(number, "the number Is Not NaN");
        //}
        //[Fact]
        //public void Ignore()
        //{
        //    Assert.Ignore("the test case Is Ignore");
        //}
        //[Fact]
        //public void Warn()
        //{
        //    Assert.Warn("the test case Is Warn");
        //}
        //[Fact]
        //public void Multiple()
        //{
        //    Assert.Multiple(null);// ???
        //}
        //[Fact]
        //public void Catch()
        //{
        //    Assert.Catch(null, "the test case Is Warn");
        //}
        //[Fact]
        //public void AreEqualIgnoringCase()
        //{
        //    object A = "Football";
        //    Assert.AreEqualIgnoringCase(A as string, "Football");
        //}
        //[Fact]
        //public void AreNotEqualIgnoringCase()
        //{
        //    object A = "Football";
        //    Assert.AreNotEqualIgnoringCase(A as string, "Football");
        //}
        //#endregion

    }

}
