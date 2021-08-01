using System;
using System.Collections.Generic;
using System.Text;

namespace Production_Code
{
    public class FizzBuzz 
    {
        public string CheckFizzBuzz(int i)
        {
            string result = i.ToString();

            if (i % 3 == 0 && i % 5 == 0)
            {
                result = "FizzBuzz";
            }

            else if (i % 3 == 0)
            {
                result = "Fizz";
            }

            else if (i % 5 == 0)
            {
                result = "Buzz";
            }

            return result;
        }
    }
}
