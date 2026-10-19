using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class CplxTests
    {
        [TestMethod()]
        public void ToString_ComplexNumber_ReturnsExpectedFormat()
        {
            Cplx positiveComplexNumber = new Cplx()
            {
                Real = 10,
                Imaginary = 20
            };

            Assert.AreEqual("(10 + 20i)", positiveComplexNumber.ToString());

            Cplx negativeImaginaryNumber = new Cplx()
            {
                Real = 1,
                Imaginary = -1
            };

            Assert.AreEqual("(1 + -1i)", negativeImaginaryNumber.ToString());

            Cplx zero = new Cplx()
            {
                Real = 0,
                Imaginary = 0
            };

            Assert.AreEqual("(0 + 0i)", zero.ToString());
        }
        
        [TestMethod()]
        public void Add_TwoComplexNumbers_ReturnsSum()
        {
            Cplx firstNumber = new Cplx()
            {
                Real = 10,
                Imaginary = 20
            };

            Cplx secondNumber = new Cplx()
            {
                Real = 1,
                Imaginary = 2
            };

            Cplx expected = new Cplx()
            {
                Real = 11,
                Imaginary = 22
            };

            Cplx actual = firstNumber.Add(secondNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Add_Zero_ReturnsOriginalNumber()
        {
            Cplx number = new Cplx()
            {
                Real = 1,
                Imaginary = -1
            };

            Cplx zero = new Cplx()
            {
                Real = 0,
                Imaginary = 0
            };

            Cplx expected = new Cplx()
            {
                Real = 1,
                Imaginary = -1
            };

            Cplx actual = number.Add(zero);

            Assert.AreEqual(expected, actual);
        }
    }
}