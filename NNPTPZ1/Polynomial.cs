using System.Collections.Generic;

namespace NNPTPZ1.Mathematics
{
        public class Polynomial
        {
            public List<ComplexNumber> Coefficients { get; set; } = new List<ComplexNumber>();

            public void Add(ComplexNumber coefficient) =>
                Coefficients.Add(coefficient);

            /// <summary>
            /// Creates the derivative of this polynomial.
            /// </summary>
            /// <returns>A new polynomial representing the derivative.</returns>
            public Polynomial Differentiate()
            {
                Polynomial derivative = new Polynomial();
                for (int coefficientIndex = 1; coefficientIndex < Coefficients.Count; coefficientIndex++)
                {
                    derivative.Coefficients.Add(Coefficients[coefficientIndex].Multiply(new ComplexNumber() { Real = coefficientIndex }));
                }

                return derivative;
            }

            /// <summary>
            /// Evaluates the polynomial at a real value.
            /// </summary>
            /// <param name="x">The real value at which to evaluate the polynomial.</param>
            /// <returns>The polynomial value represented as a complex number.</returns>
            public ComplexNumber Evaluate(double x)
            {
                return Evaluate(new ComplexNumber() { Real = x, Imaginary = 0 });
            }

            /// <summary>
            /// Evaluates the polynomial at a complex value.
            /// </summary>
            /// <param name="x">The complex value at which to evaluate the polynomial.</param>
            /// <returns>The resulting complex value of the polynomial.</returns>
            public ComplexNumber Evaluate(ComplexNumber x)
            {
                ComplexNumber result = ComplexNumber.Zero;
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    ComplexNumber coefficient = Coefficients[i];
                    ComplexNumber poweredValue = x;

                    if (i > 0)
                    {
                        for (int j = 0; j < i - 1; j++)
                            poweredValue = poweredValue.Multiply(x);

                        coefficient = coefficient.Multiply(poweredValue);
                    }

                    result = result.Add(coefficient);
                }

                return result;
            }

            public override string ToString()
            {
                string result = "";

                for (int i = 0; i < Coefficients.Count; i++)
                {
                    result += Coefficients[i];

                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            result += "x";
                        }
                    }

                    if (i + 1 < Coefficients.Count)
                    {
                        result += " + ";
                    }
                }

                return result;
            }
        }
    }