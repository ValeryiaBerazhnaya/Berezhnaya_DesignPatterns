using System;
using System.Collections.Generic;

namespace Visitor
{
    public static class VolumeCalculator
    {
        public static void Run()
        {
            List<IShape> shapes = new List<IShape>
            {
                new Sphere(3),
                new Parallelepiped(2, 4, 5),
                new Torus(5, 1),
                new Cube(2)
            };

            var visitor = new VolumeVisitor();

            foreach (var shape in shapes)
            {
                shape.Accept(visitor);
            }
        }

        public interface IShape
        {
            void Accept(IShapeVisitor visitor);
        }

        public interface IShapeVisitor
        {
            void Visit(Sphere sphere);
            void Visit(Parallelepiped parallelepiped);
            void Visit(Torus torus);
            void Visit(Cube cube);
        }

        public class VolumeVisitor : IShapeVisitor
        {
            public void Visit(Sphere sphere)
            {
                double volume = (4.0 / 3.0) * Math.PI * Math.Pow(sphere.Radius, 3);
                Console.WriteLine($"Sphere: volume = {volume:F2}");
            }

            public void Visit(Parallelepiped p)
            {
                double volume = p.Width * p.Height * p.Depth;
                Console.WriteLine($"Parallelepiped: volume = {volume:F2}");
            }

            public void Visit(Torus torus)
            {
                double volume = 2 * Math.PI * Math.PI * torus.MajorRadius * Math.Pow(torus.MinorRadius, 2);
                Console.WriteLine($"Torus: volume = {volume:F2}");
            }

            public void Visit(Cube cube)
            {
                double volume = Math.Pow(cube.Side, 3);
                Console.WriteLine($"Cube: volume = {volume:F2}");
            }
        }

        public class Sphere : IShape
        {
            public double Radius { get; }
            public Sphere(double radius) => Radius = radius;
            public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
        }

        public class Parallelepiped : IShape
        {
            public double Width { get; }
            public double Height { get; }
            public double Depth { get; }

            public Parallelepiped(double w, double h, double d)
            {
                Width = w; Height = h; Depth = d;
            }

            public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
        }

        public class Torus : IShape
        {
            public double MajorRadius { get; }
            public double MinorRadius { get; }

            public Torus(double major, double minor)
            {
                MajorRadius = major; MinorRadius = minor;
            }

            public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
        }

        public class Cube : IShape
        {
            public double Side { get; }
            public Cube(double side) => Side = side;
            public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
        }
    }
}
