using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeronsAlgorithm
{
    public class MathSquareRoot
    {
        public double squareRoot(int no)
        {
            if(no < 0)
            {
                throw new ArgumentException("Number cannot be negative.");
            }

            return Math.Sqrt(no);
        }
    }
    public class SquareRoot
    {
        double errorLimit = 0.0;
        public SquareRoot(double errLimit)
        {
            this.errorLimit = errLimit;
        }

        public double squareRoot(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("The number provided cannot be negative.");
            }

            double G = number / 2;
            
            while (G > 1)
            {
                if ((G*G - number) < this.errorLimit)
                {
                    return G;
                }

                G = (G + (number / G)) / 2;
            }

            return -1;
        }

        
        static void Main(string[] args)
        {
            SquareRoot mySquareRoot = new SquareRoot(0.0001);
            MathSquareRoot mathSquareRoot = new MathSquareRoot();
            Random random = new Random();
            int randomNumber = 0;
            for (int i = 0; i < 10000; i++)
            {
                randomNumber = random.Next(0, 100000);
                double result = mySquareRoot.squareRoot(randomNumber) - mathSquareRoot.squareRoot(randomNumber);
                if ((result) > 0.0001)
                {
                    throw new InvalidOperationException("The difference is greater than the accepted error limit range.");
                }
                else
                    Console.WriteLine(result);
            }
        }
    }
}
