using Microsoft.VisualStudio.TestTools.UnitTesting;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTests
    {
        [TestMethod()]
        public void ToString_ComplexNumber_ReturnsExpectedFormat()
        {
            ComplexNumber positiveComplexNumber = new ComplexNumber()
            {
                Real = 10,
                Imaginary = 20
            };

            Assert.AreEqual("(10 + 20i)", positiveComplexNumber.ToString());

            ComplexNumber negativeImaginaryNumber = new ComplexNumber()
            {
                Real = 1,
                Imaginary = -1
            };

            Assert.AreEqual("(1 + -1i)", negativeImaginaryNumber.ToString());

            ComplexNumber zero = new ComplexNumber()
            {
                Real = 0,
                Imaginary = 0
            };

            Assert.AreEqual("(0 + 0i)", zero.ToString());
        }
        
        [TestMethod()]
        public void Add_TwoComplexNumbers_ReturnsSum()
        {
            ComplexNumber firstNumber = new ComplexNumber()
            {
                Real = 10,
                Imaginary = 20
            };

            ComplexNumber secondNumber = new ComplexNumber()
            {
                Real = 1,
                Imaginary = 2
            };

            ComplexNumber expected = new ComplexNumber()
            {
                Real = 11,
                Imaginary = 22
            };

            ComplexNumber actual = firstNumber.Add(secondNumber);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Add_Zero_ReturnsOriginalNumber()
        {
            ComplexNumber number = new ComplexNumber()
            {
                Real = 1,
                Imaginary = -1
            };

            ComplexNumber zero = new ComplexNumber()
            {
                Real = 0,
                Imaginary = 0
            };

            ComplexNumber expected = new ComplexNumber()
            {
                Real = 1,
                Imaginary = -1
            };

            ComplexNumber actual = number.Add(zero);

            Assert.AreEqual(expected, actual);
        }
    }
}