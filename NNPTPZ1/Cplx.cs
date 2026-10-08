using System;

namespace NNPTPZ1.Mathematics
{
    public class Cplx
    {
        public double Re { get; set; }
        public float Imaginari { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Cplx)
            {
                Cplx x = obj as Cplx;
                return x.Re == Re && x.Imaginari == Imaginari;
            }
            return base.Equals(obj);
        }

        public readonly static Cplx Zero = new Cplx()
        {
            Re = 0,
            Imaginari = 0
        };

        public Cplx Multiply(Cplx other)
        {
            // aRe*bRe + aRe*bIm*i + aIm*bRe*i + aIm*bIm*i*i
            return new Cplx()
            {
                Re = Re * other.Re - Imaginari * other.Imaginari,
                Imaginari = (float)(Re * other.Imaginari + Imaginari * other.Re)
            };
        }
        public double GetAbS()
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
            // (aRe + aIm*i) / (bRe + bIm*i)
            // ((aRe + aIm*i) * (bRe - bIm*i)) / ((bRe + bIm*i) * (bRe - bIm*i))
            //  bRe*bRe - bIm*bIm*i*i
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