using System;

namespace NNPTPZ1.Mathematics
{
    public class Cplx
    {
        public double Real { get; set; }
        public float Imaginary { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Cplx other)
            {
                return other.Real == Real && other.Imaginary == Imaginary;
            }

            return false;
        }

        public readonly static Cplx Zero = new Cplx()
        {
            Real = 0,
            Imaginary = 0
        };

        public Cplx Multiply(Cplx other)
        {
            return new Cplx()
            {
                Real = Real * other.Real - Imaginary * other.Imaginary,
                Imaginary = (float)(Real * other.Imaginary + Imaginary * other.Real)
            };
        }
        public double GetAbs()
        {
            return Math.Sqrt( Real * Real + Imaginary * Imaginary);
        }

        public Cplx Add(Cplx other)
        {
            return new Cplx()
            {
                Real = Real + other.Real,
                Imaginary = Imaginary + other.Imaginary
            };
        }
        public double GetAngleInDegrees()
        {
            return Math.Atan(Imaginary / Real);
        }
        public Cplx Subtract(Cplx other)
        {
            return new Cplx()
            {
                Real = Real - other.Real,
                Imaginary = Imaginary - other.Imaginary
            };
        }

        public override string ToString()
        {
            return $"({Real} + {Imaginary}i)";
        }

        internal Cplx Divide(Cplx other)
        {
            var numerator = Multiply(new Cplx() { Real = other.Real, Imaginary = -other.Imaginary });
            var denominator = other.Real * other.Real + other.Imaginary * other.Imaginary;

            return new Cplx()
            {
                Real = numerator.Real / denominator,
                Imaginary = (float)(numerator.Imaginary / denominator)
            };
        }
    }
}