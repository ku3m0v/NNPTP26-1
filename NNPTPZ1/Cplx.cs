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

        public Cplx Multiply(Cplx b)
        {
            // aRe*bRe + aRe*bIm*i + aIm*bRe*i + aIm*bIm*i*i
            return new Cplx()
            {
                Re = Re * b.Re - Imaginari * b.Imaginari,
                Imaginari = (float)(Re * b.Imaginari + Imaginari * b.Re)
            };
        }
        public double GetAbS()
        {
            return Math.Sqrt( Re * Re + Imaginari * Imaginari);
        }

        public Cplx Add(Cplx b)
        {
            return new Cplx()
            {
                Re = Re + b.Re,
                Imaginari = Imaginari + b.Imaginari
            };
        }
        public double GetAngleInDegrees()
        {
            return Math.Atan(Imaginari / Re);
        }
        public Cplx Subtract(Cplx b)
        {
            return new Cplx()
            {
                Re = Re - b.Re,
                Imaginari = Imaginari - b.Imaginari
            };
        }

        public override string ToString()
        {
            return $"({Re} + {Imaginari}i)";
        }

        internal Cplx Divide(Cplx b)
        {
            // (aRe + aIm*i) / (bRe + bIm*i)
            // ((aRe + aIm*i) * (bRe - bIm*i)) / ((bRe + bIm*i) * (bRe - bIm*i))
            //  bRe*bRe - bIm*bIm*i*i
            var numerator = Multiply(new Cplx() { Re = b.Re, Imaginari = -b.Imaginari });
            var denominator = b.Re * b.Re + b.Imaginari * b.Imaginari;

            return new Cplx()
            {
                Re = numerator.Re / denominator,
                Imaginari = (float)(numerator.Imaginari / denominator)
            };
        }
    }
}