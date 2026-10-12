using System;
using System.Collections.Generic;
using System.Drawing;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class Program
    {
        private const double CoordinateEpsilon = 0.0001;
        private const int RequiredNewtonIterations = 30;
        private const double NewtonCorrectionThreshold = 0.5;
        private const double RootMatchThreshold = 0.01;
        private const int ColorDarkeningPerIteration = 2;
        
        static void Main(string[] args)
        {
            int width = int.Parse(args[0]);
            int height = int.Parse(args[1]);
            string output = args[6];
            // TODO: add parameters from args?
            Bitmap bmp = new Bitmap(width, height);
            double xMin = double.Parse(args[2]);
            double xMax = double.Parse(args[3]);
            double yMin = double.Parse(args[4]);
            double yMax = double.Parse(args[5]);

            double xStep = (xMax - xMin) / width;
            double yStep = (yMax - yMin) / height;

            List<Cplx> roots = new List<Cplx>();
            // TODO: poly should be parameterised?
            Poly polynomial = CreatePolynomial();
            Poly derivative = polynomial.Differentiate();

            Console.WriteLine(polynomial);
            Console.WriteLine(derivative);

            var colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };

            // TODO: cleanup!!!
            // for every pixel in image...
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // find "world" coordinates of pixel
                    double y = yMin + i * yStep;
                    double x = xMin + j * xStep;

                    Color pixelColor = CalculatePixelColor(x, y, polynomial, derivative, roots, colors);

                    bmp.SetPixel(j, i, pixelColor);
                }
            } 
            
            bmp.Save(output ?? "../../../out.png");
        }
        
        private static Poly CreatePolynomial()
        {
            Poly polynomial = new Poly();
            polynomial.Coefficients.Add(new Cplx() { Re = 1 });
            polynomial.Coefficients.Add(Cplx.Zero);
            polynomial.Coefficients.Add(Cplx.Zero);
            polynomial.Coefficients.Add(new Cplx() { Re = 1 });

            return polynomial;
        }
        
        private static Color CalculatePixelColor(double x, double y, Poly polynomial, Poly derivative, List<Cplx> roots, Color[] colors)
        {
            Cplx approximation = new Cplx()
            {
                Re = x,
                Imaginari = (float)y
            };

            if (approximation.Re == 0)
                approximation.Re = CoordinateEpsilon;
            if (approximation.Imaginari == 0)
                approximation.Imaginari = (float)CoordinateEpsilon;

            // find solution of equation using newton's iteration
            float iterationCount = 0;
            for (int q = 0; q < RequiredNewtonIterations; q++)
            {
                var correction = polynomial.Evaluate(approximation).Divide(derivative.Evaluate(approximation));
                approximation = approximation.Subtract(correction);

                if (Math.Pow(correction.Re, 2) + Math.Pow(correction.Imaginari, 2) >= NewtonCorrectionThreshold)
                {
                    q--;
                }

                iterationCount++;
            }

            // find solution root number
            var rootFound = false;
            var rootId = 0;
            for (int rootIndex = 0; rootIndex < roots.Count; rootIndex++)
            {
                if (Math.Pow(approximation.Re - roots[rootIndex].Re, 2) + Math.Pow(approximation.Imaginari - roots[rootIndex].Imaginari, 2) <= RootMatchThreshold)
                {
                    rootFound = true;
                    rootId = rootIndex;
                }
            }

            if (!rootFound)
            {
                roots.Add(approximation);
                rootId = roots.Count;
            }

            // colorize pixel according to root number
            var pixelColor = colors[rootId % colors.Length];
            pixelColor = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
            pixelColor = Color.FromArgb(
                Math.Min(Math.Max(0, pixelColor.R - (int)iterationCount * ColorDarkeningPerIteration), 255),
                Math.Min(Math.Max(0, pixelColor.G - (int)iterationCount * ColorDarkeningPerIteration), 255),
                Math.Min(Math.Max(0, pixelColor.B - (int)iterationCount * ColorDarkeningPerIteration), 255));

            return pixelColor;
        }
    }
}
