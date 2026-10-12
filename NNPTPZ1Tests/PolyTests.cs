using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class PolyTests
    {
        [TestMethod()]
        public void ToString_Polynomial_ReturnsExpectedFormat()
        {
            Poly polynomial = CreateTestPolynomial();

            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";

            Assert.AreEqual(expected, polynomial.ToString());
        }
        
        [TestMethod()]
        public void Evaluate_AtZero_ReturnsOne()
        {
            Poly polynomial = CreateTestPolynomial();

            Cplx input = new Cplx() { Re = 0, Imaginari = 0 };
            Cplx expected = new Cplx() { Re = 1, Imaginari = 0 };

            Cplx actual = polynomial.Evaluate(input);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void Evaluate_AtOne_ReturnsTwo()
        {
            Poly polynomial = CreateTestPolynomial();

            Cplx input = new Cplx() { Re = 1, Imaginari = 0 };
            Cplx expected = new Cplx() { Re = 2, Imaginari = 0 };

            Cplx actual = polynomial.Evaluate(input);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void Evaluate_AtTwo_ReturnsFive()
        {
            Poly polynomial = CreateTestPolynomial();

            Cplx input = new Cplx() { Re = 2, Imaginari = 0 };
            Cplx expected = new Cplx() { Re = 5, Imaginari = 0 };

            Cplx actual = polynomial.Evaluate(input);

            Assert.AreEqual(expected, actual);
        }
        
        private Poly CreateTestPolynomial()
        {
            Poly polynomial = new Poly();
            polynomial.Coefficients.Add(new Cplx() { Re = 1, Imaginari = 0 });
            polynomial.Coefficients.Add(new Cplx() { Re = 0, Imaginari = 0 });
            polynomial.Coefficients.Add(new Cplx() { Re = 1, Imaginari = 0 });

            return polynomial;
        }
    }
}