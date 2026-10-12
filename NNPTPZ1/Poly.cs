using System.Collections.Generic;

namespace NNPTPZ1.Mathematics
{
        public class Poly
        {
            /// <summary>
            /// Coe
            /// </summary>
            public List<Cplx> Coe { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
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

            /// <summary>
            /// ToString
            /// </summary>
            /// <returns>String repr of polynomial</returns>
            public override string ToString()
            {
                string s = "";
                int i = 0;
                for (; i < Coe.Count; i++)
                {
                    s += Coe[i];
                    if (i > 0)
                    {
                        int j = 0;
                        for (; j < i; j++)
                        {
                            s += "x";
                        }
                    }
                    if (i+1<Coe.Count)
                    s += " + ";
                }
                return s;
            }
        }
    }