using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class PolynomialTests
    {
        [TestMethod()]
        public void ToString_Polynomial_ReturnsExpectedFormat()
        {
            Polynomial polynomial = CreateTestPolynomial();

            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";

            Assert.AreEqual(expected, polynomial.ToString());
        }
        
        [TestMethod()]
        public void Evaluate_AtZero_ReturnsOne()
        {
            Polynomial polynomial = CreateTestPolynomial();

            ComplexNumber input = new ComplexNumber() { Real = 0, Imaginary = 0 };
            ComplexNumber expected = new ComplexNumber() { Real = 1, Imaginary = 0 };

            ComplexNumber actual = polynomial.Evaluate(input);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void Evaluate_AtOne_ReturnsTwo()
        {
            Polynomial polynomial = CreateTestPolynomial();

            ComplexNumber input = new ComplexNumber() { Real = 1, Imaginary = 0 };
            ComplexNumber expected = new ComplexNumber() { Real = 2, Imaginary = 0 };

            ComplexNumber actual = polynomial.Evaluate(input);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void Evaluate_AtTwo_ReturnsFive()
        {
            Polynomial polynomial = CreateTestPolynomial();

            ComplexNumber input = new ComplexNumber() { Real = 2, Imaginary = 0 };
            ComplexNumber expected = new ComplexNumber() { Real = 5, Imaginary = 0 };

            ComplexNumber actual = polynomial.Evaluate(input);

            Assert.AreEqual(expected, actual);
        }
        
        private Polynomial CreateTestPolynomial()
        {
            Polynomial polynomial = new Polynomial();
            polynomial.Coefficients.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Real = 0, Imaginary = 0 });
            polynomial.Coefficients.Add(new ComplexNumber() { Real = 1, Imaginary = 0 });

            return polynomial;
        }
    }
}