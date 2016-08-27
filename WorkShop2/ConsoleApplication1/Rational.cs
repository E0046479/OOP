using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Rational
    {
        // private so this class only can access
        private int numerator, denominator;

        // public can access from any where
        public int GetNumerator()
        {
            return numerator;
        }

        // public can access from any where
        public int GetDenominator()
        {
            return denominator;
        }

        // public can access from any where
        public Rational Add(Rational num2)
        {
            int commonDenom = denominator * num2.GetDenominator();
            int numer1 = numerator * num2.GetDenominator();
            int numer2 = num2.GetNumerator() * denominator;
            int sum = numer1 + numer2;
            Rational result = new Rational(sum, commonDenom);
            return result;
        }

        // public can access from any where
        public Rational Subtract(Rational num2)
        {
            int commonDenom = denominator * num2.GetDenominator();
            int numer1 = numerator * num2.GetDenominator();
            int numer2 = num2.GetNumerator() * denominator;
            int difference = numer1 - numer2;
            Rational result = new Rational(difference, commonDenom);
            return result;
        }

        // public can access from any where
        public Rational Multiply(Rational num2)
        {
            int numer = numerator * num2.GetNumerator();
            int denom = denominator * num2.GetDenominator();
            Rational result = new Rational(numer, denom);
            return result;
        }

        // public can access from any where
        public Rational Divide(Rational num2)
        {
            int numer = num2.GetDenominator();
            int denom = num2.GetNumerator();

            Rational r = new Rational(numer, denom);
            Rational result = Multiply(r);
            return result;
        }
        // public can access from any where
        public string StrVal()
        {
            string result;

            if (numerator == 0)
                result = "0";
            else
            {
                if (denominator == 1)
                    result = numerator.ToString();
                else
                    result = numerator + "/" + denominator;
            }
            return result;
        }

        // Constructors
        public Rational()
        {
            numerator = 0;
            denominator = 0;
        }

        public Rational(int numer, int denom)
        {
            if (denom == 0)    // set denominator to 1 if
                denom = 1;      // argument is zero
            if (denom < 0)
            {   // make numerator "store" the sign
                numer = numer * -1;
                denom = denom * -1;
            }
            numerator = numer;
            denominator = denom;
            Reduce();          // calling a private method
        }

        // private so this class only can access
        private void Reduce()
        {
            if (numerator != 0)
            {
                int common = HCF(Math.Abs(numerator), denominator);
                numerator = numerator / common;
                denominator = denominator / common;
            }
        }

        // private so this class only can access
        private int HCF(int num1, int num2)
        {
            while (num1 != num2)
            {
                if (num1 > num2)
                    num1 -= num2;
                else
                    num2 -= num1;
            }
            return num1;
        }

        //public static void Main(string[] args)
        //{
        //    Rational rational = new Rational(); // need to create default constructor because 2 arguments are created by developer so system would not create automatically for default constructor.
        //    rational.denominator = 0; // private can access only in the same class.
        //    rational.numerator = 0; // private can access only in the same class.

        //    Rational rational2 = new Rational();

        //    rational.GetNumerator(); // public so can access from any where
        //    rational.GetDenominator(); // public so can access from any where
        //    rational.Add(rational2); // public so can access from any where
        //    rational.Subtract(rational2); // public so can access from any where
        //    rational.Multiply(rational2); // public so can access from any where
        //    rational.Divide(rational2); // public so can access from any where
        //    rational.StrVal(); // public so can access from any where

        //    rational.Reduce(); // private can access on the same class
        //    rational.HCF(10, 20); // private can access on the same class
        //}
    }
}
