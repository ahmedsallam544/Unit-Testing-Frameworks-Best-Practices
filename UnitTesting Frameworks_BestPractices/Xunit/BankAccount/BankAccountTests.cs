using System;
using Production_Code; 
using Xunit;

namespace UnitTesting_Frameworks_BestPractices.Xunit
{
    
    public class BankAccountTest
    {
        [Fact]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 1000;
            double debitAmount = 300;
            double expected = 700;
            BankAccount account = new BankAccount("Mr. Mohamed Khalil", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            //0.001 is the Delta, this means the method will fail only if the difference between Expected and Actual is more than 0.001
            Assert.Equal(expected, actual, 3);
        }
        [Fact]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WithLessThanZeroAmount_ThrowsException()
        {
            // arrange  
            double beginningBalance = 1000;
            double debitAmount = -100;
            BankAccount account = new BankAccount("Mr. Mohamed Khalil", beginningBalance);

            // act  
            //account.Debit(debitAmount);

            // assert  
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
        [Fact]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WithMoreThanBalanceAmount_ThrowsException()
        {
            // arrange  
            double beginningBalance = 1000;
            double debitAmount = 2000;
            BankAccount account = new BankAccount("Mr. Mohamed Khalil", beginningBalance);

            // act  
            //account.Debit(debitAmount);

            // assert  
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
        [Fact]
        //[ExpectedException(typeof(Exception))]
        public void Debit_WithFreezedAccount_ThrowsException()
        {
            // arrange  
            double beginningBalance = 1000;
            double debitAmount = 300;
            BankAccount account = new BankAccount("Mr. Mohamed Khalil", beginningBalance);
            account.FreezeAccount();

            // act  
            //account.Debit(debitAmount);

            // assert  
            Assert.Throws<Exception>(() => account.Debit(debitAmount));
        }
    }
}
