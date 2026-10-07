using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNPTPZ1;

namespace NNPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class CplxTests
    {

        [TestMethod()]
        public void AddTestPolynome()
        {
            Poly polynomial = CreateTestPolynomial();
            Cplx result = polynomial.Eval(new Cplx() { Re = 0, Imaginari = 0 });
            var expected = new Cplx() { Re = 1, Imaginari = 0 };
            Assert.AreEqual(expected, result);
            result = polynomial.Eval(new Cplx() { Re = 1, Imaginari = 0 });
            expected = new Cplx() { Re = 2, Imaginari = 0 };
            Assert.AreEqual(expected, result);
            result = polynomial.Eval(new Cplx() { Re = 2, Imaginari = 0 });
            expected = new Cplx() { Re = 5.0000000000, Imaginari = 0 };
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod()]
        public void ToString_ComplexNumber_ReturnsExpectedFormat()
        {
            Cplx positiveComplexNumber = new Cplx()
            {
                Re = 10,
                Imaginari = 20
            };

            Assert.AreEqual("(10 + 20i)", positiveComplexNumber.ToString());

            Cplx negativeImaginaryNumber = new Cplx()
            {
                Re = 1,
                Imaginari = -1
            };

            Assert.AreEqual("(1 + -1i)", negativeImaginaryNumber.ToString());

            Cplx zero = new Cplx()
            {
                Re = 0,
                Imaginari = 0
            };

            Assert.AreEqual("(0 + 0i)", zero.ToString());
        }
        
        [TestMethod()]
        public void Add_TwoComplexNumbers_ReturnsSum()
        {
            Cplx firstNumber = new Cplx()
            {
                Re = 10,
                Imaginari = 20
            };

            Cplx secondNumber = new Cplx()
            {
                Re = 1,
                Imaginari = 2
            };

            Cplx expected = new Cplx()
            {
                Re = 11,
                Imaginari = 22
            };

            Cplx actual = firstNumber.Add(secondNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Add_Zero_ReturnsOriginalNumber()
        {
            Cplx number = new Cplx()
            {
                Re = 1,
                Imaginari = -1
            };

            Cplx zero = new Cplx()
            {
                Re = 0,
                Imaginari = 0
            };

            Cplx expected = new Cplx()
            {
                Re = 1,
                Imaginari = -1
            };

            Cplx actual = number.Add(zero);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void ToString_Polynomial_ReturnsExpectedFormat()
        {
            Poly polynomial = CreateTestPolynomial();

            string expected = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";

            Assert.AreEqual(expected, polynomial.ToString());
        }
        
        private Poly CreateTestPolynomial()
        {
            Poly polynomial = new Poly();
            polynomial.Coe.Add(new Cplx() { Re = 1, Imaginari = 0 });
            polynomial.Coe.Add(new Cplx() { Re = 0, Imaginari = 0 });
            polynomial.Coe.Add(new Cplx() { Re = 1, Imaginari = 0 });

            return polynomial;
        }
    }
}


