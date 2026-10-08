using System;

namespace NNPTPZ1.Mathematics
{
    public class Cplx
    {
        public double Re { get; set; }
        public float Imaginari { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Cplx other)
            {
                return other.Re == Re && other.Imaginari == Imaginari;
            }

            return false;
        }

        public readonly static Cplx Zero = new Cplx()
        {
            Re = 0,
            Imaginari = 0
        };

        public Cplx Multiply(Cplx other)
        {
            return new Cplx()
            {
                Re = Re * other.Re - Imaginari * other.Imaginari,
                Imaginari = (float)(Re * other.Imaginari + Imaginari * other.Re)
            };
        }
        public double GetAbs()
        {
            return Math.Sqrt( Re * Re + Imaginari * Imaginari);
        }

        public Cplx Add(Cplx other)
        {
            return new Cplx()
            {
                Re = Re + other.Re,
                Imaginari = Imaginari + other.Imaginari
            };
        }
        public double GetAngleInDegrees()
        {
            return Math.Atan(Imaginari / Re);
        }
        public Cplx Subtract(Cplx other)
        {
            return new Cplx()
            {
                Re = Re - other.Re,
                Imaginari = Imaginari - other.Imaginari
            };
        }

        public override string ToString()
        {
            return $"({Re} + {Imaginari}i)";
        }

        internal Cplx Divide(Cplx other)
        {
            var numerator = Multiply(new Cplx() { Re = other.Re, Imaginari = -other.Imaginari });
            var denominator = other.Re * other.Re + other.Imaginari * other.Imaginari;

            return new Cplx()
            {
                Re = numerator.Re / denominator,
                Imaginari = (float)(numerator.Imaginari / denominator)
            };
        }
    }
}