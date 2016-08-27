using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS.RV.LIB;

namespace ConsoleApplication1
{
    class Dice
    {
        // Attribute
        int faceUp;

        // Constructors
        public Dice()
        {
            Throw();
        }
        // Method
        public int GetFaceUp()
        {
            return faceUp;
        }

        public int Throw()
        {
            faceUp = ISSMath.RNDInt(6) + 1;
            return faceUp;
        }

        // Properties
        public string StrFaceUp
        {
            get
            {
                string strFaceUp = null;
                switch (faceUp)
                {
                    case 1:
                        strFaceUp = "ONE";
                        break;
                    case 2:
                        strFaceUp = "TWO";
                        break;
                    case 3:
                        strFaceUp = "THREE";
                        break;
                    case 4:
                        strFaceUp = "FOUR";
                        break;
                    case 5:
                        strFaceUp = "FIVE";
                        break;
                    case 6:
                        strFaceUp = "SIX";
                        break;
                    default:
                        strFaceUp = "Error";
                        break;
                }
                return strFaceUp;
            }
        }
    }

    public class DiceApp
    {
        public static void Main()
        {
            Dice dice1 = new Dice();
            dice1.Throw();
            dice1.Throw(); Console.WriteLine("Dice1: {0}", dice1.StrFaceUp);
            dice1.Throw(); Console.WriteLine("Dice1: {0}", dice1.StrFaceUp);
            dice1.Throw(); Console.WriteLine("Dice1: {0}", dice1.StrFaceUp);

            Dice dice2 = new Dice();
            dice2.Throw(); Console.WriteLine("Dice2: {0}", dice2.StrFaceUp);

            Console.WriteLine("Dice2: {0}", dice2.StrFaceUp);
        }
    }
}
