using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TestRational
    {
        public static void Main(string[] args)
        {
            Rational rational = new Rational(); // need to create default constructor because 2 arguments are created by developer so system would not create automatically for default constructor.
            // rational.denominator = 0; // private can not access because not in the same class
            // rational.numerator = 0; // private can not access because not in the same class

            Rational rational2 = new Rational();

            rational.GetNumerator(); // public so can access from any where
            rational.GetDenominator(); // public so can access from any where
            rational.Add(rational2); // public so can access from any where
            rational.Subtract(rational2); // public so can access from any where
            rational.Multiply(rational2); // public so can access from any where
            rational.Divide(rational2); // public so can access from any where
            rational.StrVal(); // public so can access from any where

           // rational.Reduce(); // private can not access because not in the same class
           // rational.HCF(10, 20); // private can not access because not in the same class
        }
    }
}
