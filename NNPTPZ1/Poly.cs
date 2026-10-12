using System.Collections.Generic;

namespace NNPTPZ1.Mathematics
{
        public class Poly
        {
            public List<Cplx> Coe { get; set; }

            public Poly() => Coe = new List<Cplx>();

            public void Add(Cplx coe) =>
                Coe.Add(coe);

            /// <summary>
            /// Derives this polynomial and creates new one
            /// </summary>
            /// <returns>Derivated polynomial</returns>
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
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="x">point of evaluation</param>
            /// <returns>y</returns>
            public Cplx Eval(double x)
            {
                return Eval(new Cplx() { Re = x, Imaginari = 0 });
            }

            /// <summary>
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="x">point of evaluation</param>
            /// <returns>y</returns>
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