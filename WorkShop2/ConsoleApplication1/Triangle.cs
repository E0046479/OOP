using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Triangle
    {

        // Attribute
        float side1, side2, side3;

        // Constructor
        public Triangle()
        {
            side1 = 0;
            side2 = 0;
            side3 = 0;
        }

        // Method
        public double FindArea(float side1, float side2, float side3)
        {
            float p = FindPerimeter(side1, side2, side3) / 2;
            double halfP = p * (p - side1) * (p - side2) * (p - side3);
            double area = Math.Sqrt(halfP);
            return area;
        }


        public float FindPerimeter(float side1, float side2, float side3)
        {
            float p = (side1 + side2 + side3);
            return p;
        }

        // Properties
        public float Side1
        {
            get
            {
                return side1;
            }
        }

        public float Side2
        {
            get
            {
                return side2;
            }
        }

        public float Side3
        {
            get
            {
                return side3;
            }
        }
    }

    class TestTriangle
    {
        public static void Main(string[] args)
        {
            Triangle triangle = new Triangle();
            Console.WriteLine("Area of Triangle side1: {0} side2: {1} and Breadth: {2} = {3}", 10, 20, 30,  triangle.FindArea(10, 20, 30));
            Console.WriteLine("Perimeter of Triangle side1: {0} side2: {1} and Breadth: {2} = {3}", 10, 20, 30, triangle.FindPerimeter(10, 20, 30));
        
        }
    }
}
