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

            Bitmap bmp = new Bitmap(width, height);
            double xMin = double.Parse(args[2]);
            double xMax = double.Parse(args[3]);
            double yMin = double.Parse(args[4]);
            double yMax = double.Parse(args[5]);

            double xStep = (xMax - xMin) / width;
            double yStep = (yMax - yMin) / height;

            List<ComplexNumber> roots = new List<ComplexNumber>();

            Polynomial polynomial = CreatePolynomial();
            Polynomial derivative = polynomial.Differentiate();

            Console.WriteLine(polynomial);
            Console.WriteLine(derivative);

            var colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };
            
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
        
        private static Polynomial CreatePolynomial()
        {
            // TODO: poly should be parameterised?
            Polynomial polynomial = new Polynomial();
            polynomial.Coefficients.Add(new ComplexNumber() { Real = 1 });
            polynomial.Coefficients.Add(ComplexNumber.Zero);
            polynomial.Coefficients.Add(ComplexNumber.Zero);
            polynomial.Coefficients.Add(new ComplexNumber() { Real = 1 });

            return polynomial;
        }
        
        private static Color CalculatePixelColor(double x, double y, Polynomial polynomial, Polynomial derivative, List<ComplexNumber> roots, Color[] colors)
        {
            float iterationCount;
            ComplexNumber approximation = CalculateRootApproximation(
                x,
                y,
                polynomial,
                derivative,
                out iterationCount);

            // find solution root number
            var rootFound = false;
            var rootId = 0;
            for (int rootIndex = 0; rootIndex < roots.Count; rootIndex++)
            {
                if (Math.Pow(approximation.Real - roots[rootIndex].Real, 2) + Math.Pow(approximation.Imaginary - roots[rootIndex].Imaginary, 2) <= RootMatchThreshold)
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
        
        private static ComplexNumber CalculateRootApproximation(
            double x,
            double y,
            Polynomial polynomial,
            Polynomial derivative,
            out float iterationCount)
        {
            ComplexNumber approximation = new ComplexNumber()
            {
                Real = x,
                Imaginary = (float)y
            };

            if (approximation.Real == 0)
                approximation.Real = CoordinateEpsilon;
            if (approximation.Imaginary == 0)
                approximation.Imaginary = (float)CoordinateEpsilon;

            iterationCount = 0;
            for (int q = 0; q < RequiredNewtonIterations; q++)
            {
                var correction = polynomial.Evaluate(approximation).Divide(derivative.Evaluate(approximation));
                approximation = approximation.Subtract(correction);

                if (Math.Pow(correction.Real, 2) + Math.Pow(correction.Imaginary, 2) >= NewtonCorrectionThreshold)
                {
                    q--;
                }

                iterationCount++;
            }

            return approximation;
        }
    }
}
