using System.Collections.Generic;

namespace NNPTPZ1.Mathematics
{
        public class Poly
        {
            public List<Cplx> Coe { get; set; }

            public Poly() => Coe = new List<Cplx>();

            public void Add(Cplx coefficient) =>
                Coe.Add(coefficient);

            /// <summary>
            /// Creates the derivative of this polynomial.
            /// </summary>
            /// <returns>A new polynomial representing the derivative.</returns>
            public Poly Derive()
            {
                Poly derivative = new Poly();
                for (int coefficientIndex = 1; coefficientIndex < Coe.Count; coefficientIndex++)
                {
                    derivative.Coe.Add(Coe[coefficientIndex].Multiply(new Cplx() { Re = coefficientIndex }));
                }

                return derivative;
            }

            /// <summary>
            /// Evaluates the polynomial at a real value.
            /// </summary>
            /// <param name="x">The real value at which to evaluate the polynomial.</param>
            /// <returns>The polynomial value represented as a complex number.</returns>
            public Cplx Eval(double x)
            {
                return Eval(new Cplx() { Re = x, Imaginari = 0 });
            }

            /// <summary>
            /// Evaluates the polynomial at a complex value.
            /// </summary>
            /// <param name="x">The complex value at which to evaluate the polynomial.</param>
            /// <returns>The resulting complex value of the polynomial.</returns>
            public Cplx Eval(Cplx x)
            {
                Cplx result = Cplx.Zero;
                for (int i = 0; i < Coe.Count; i++)
                {
                    Cplx coefficient = Coe[i];
                    Cplx poweredValue = x;
                    int power = i;

                    if (i > 0)
                    {
                        for (int j = 0; j < power - 1; j++)
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

                for (int i = 0; i < Coe.Count; i++)
                {
                    result += Coe[i];

                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            result += "x";
                        }
                    }

                    if (i + 1 < Coe.Count)
                    {
                        result += " + ";
                    }
                }

                return result;
            }
        }
    }