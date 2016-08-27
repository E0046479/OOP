using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Rectangle
    {
        // Attribute
        float length, breadth;

        // Constructors
        public Rectangle()
        {
            length = 0;
            breadth = 0;
        }

        // Methods
        public float FindArea(float length, float breadth)
        {
            return length * breadth;
        }

        public float FindPerimeter(float length, float breadth)
        {
            return 2 * (length + breadth);
        }

        // Properties

        public float Length
        {
            get
            {
                return length;
            }
        }

        public float Breadth
        {
            get
            {
                return breadth;
            }
        }
    }

    class TestRectangle
    {
        public static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            Console.WriteLine("Area of Rectangle Length: {0} and Breadth: {1} = {2}", 100, 200, rectangle.FindArea(100, 200));
            Console.WriteLine("Perimeter of Rectangle Length: {0} and Breadth: {1} = {2}", 100, 200, rectangle.FindPerimeter(100, 200));
        }
    }
}
