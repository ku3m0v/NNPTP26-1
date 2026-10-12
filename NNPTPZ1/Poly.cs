using System.Collections.Generic;

namespace NNPTPZ1.Mathematics
{
        public class Poly
        {
            public List<Cplx> Coefficients { get; set; }

            public Poly() => Coefficients = new List<Cplx>();

            public void Add(Cplx coefficient) =>
                Coefficients.Add(coefficient);

            /// <summary>
            /// Creates the derivative of this polynomial.
            /// </summary>
            /// <returns>A new polynomial representing the derivative.</returns>
            public Poly Derive()
            {
                Poly derivative = new Poly();
                for (int coefficientIndex = 1; coefficientIndex < Coefficients.Count; coefficientIndex++)
                {
                    derivative.Coefficients.Add(Coefficients[coefficientIndex].Multiply(new Cplx() { Re = coefficientIndex }));
                }

                return derivative;
            }

            /// <summary>
            /// Evaluates the polynomial at a real value.
            /// </summary>
            /// <param name="x">The real value at which to evaluate the polynomial.</param>
            /// <returns>The polynomial value represented as a complex number.</returns>
            public Cplx Evaluate(double x)
            {
                return Evaluate(new Cplx() { Re = x, Imaginari = 0 });
            }

            /// <summary>
            /// Evaluates the polynomial at a complex value.
            /// </summary>
            /// <param name="x">The complex value at which to evaluate the polynomial.</param>
            /// <returns>The resulting complex value of the polynomial.</returns>
            public Cplx Evaluate(Cplx x)
            {
                Cplx result = Cplx.Zero;
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    Cplx coefficient = Coefficients[i];
                    Cplx poweredValue = x;

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