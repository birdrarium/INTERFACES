using System;
using System.Collections.Generic;

namespace interfaces
{
    public interface IFigure : IComparable<IFigure>
    {
        ConsoleColor figureColor { get; set; }
        double Area();
    }

    public class Circle : IFigure, IComparable<IFigure>
    {
        public double radius;
        public ConsoleColor FigureColor;
        public ConsoleColor figureColor
        {
            get { return FigureColor; }
            set { FigureColor = value; }
        }

        public Circle(double r, ConsoleColor fC)
        {
            this.radius = r;
            this.figureColor = fC;
        }
        public double Area()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public override string ToString()
        {
            return $"Figure Color: {figureColor} Area: {Area():F2} Radius: {radius}";
        }
        public int CompareTo(IFigure obj)
        {
            if (this.Area() == 0 || this.Area() < obj.Area())
                return -1;
            else if (obj.Area() == 0 || this.Area() > obj.Area())
                return 1;
            else
                return 0;
        }

    }

    public class Rectangle : IFigure, IComparable<IFigure>
    {
        public double width, height;
        public ConsoleColor FigureColor;
        public ConsoleColor figureColor
        {
            get { return FigureColor; }
            set { FigureColor = value; }
        }

        public Rectangle(double w, double h, ConsoleColor fC)
        {
            this.width = w;
            this.height = h;
            this.figureColor = fC;
        }
        public double Area()
        {
            return width * height;
        }

        public override string ToString()
        {
            return $"Figure Color: {figureColor} Area: {Area():F2} Width: {width} Height: {height}";
        }
        public int CompareTo(IFigure obj)
        {
            if (this.Area() == 0 || this.Area() < obj.Area())
                return -1;
            else if (obj.Area() == 0 || this.Area() > obj.Area())
                return 1;
            else
                return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFigure[] figures =
            {
                new Rectangle(4,6, ConsoleColor.Black),
                new Circle(3, ConsoleColor.Red),
                new Circle(6, ConsoleColor.DarkBlue),
                new Rectangle(1,2,ConsoleColor.White)
            };

            foreach(IFigure obj in figures)
            {
                Console.WriteLine(obj.ToString());
            }

            Console.WriteLine(figures[0].CompareTo(figures[1])); 
        }
    }
}
