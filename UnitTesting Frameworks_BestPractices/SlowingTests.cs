using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting_Frameworks_BestPractices
{
    [TestFixture]
   public class SlowingTests
    {

        public const int SINGLE_TEST_DELAY = 1000;
        private static void Delay()
        {
            System.Threading.Thread.Sleep(SINGLE_TEST_DELAY);
        }

        [Test]
        public void SlowTestDelay()=>       
            SlowingTests.Delay();
         
    }
}
