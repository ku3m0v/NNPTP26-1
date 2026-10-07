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
        public void AddTest()
        {
            Cplx a = new Cplx()
            {
                Re = 10,
                Imaginari = 20
            };
            Cplx b = new Cplx()
            {
                Re = 1,
                Imaginari = 2
            };

            Cplx actual = a.Add(b);
            Cplx shouldBe = new Cplx()
            {
                Re = 11,
                Imaginari = 22
            };

            Assert.AreEqual(shouldBe, actual);

            a = new Cplx()
            {
                Re = 1,
                Imaginari = -1
            };
            b = new Cplx() { Re = 0, Imaginari = 0 };
            shouldBe = new Cplx() { Re = 1, Imaginari = -1 };
            actual = a.Add(b);
            Assert.AreEqual(shouldBe, actual);
        }

        [TestMethod()]
        public void AddTestPolynome()
        {
            Poly poly = new Mathematics.Poly();
            poly.Coe.Add(new Cplx() { Re = 1, Imaginari = 0 });
            poly.Coe.Add(new Cplx() { Re = 0, Imaginari = 0 });
            poly.Coe.Add(new Cplx() { Re = 1, Imaginari = 0 });
            Cplx result = poly.Eval(new Cplx() { Re = 0, Imaginari = 0 });
            var expected = new Cplx() { Re = 1, Imaginari = 0 };
            Assert.AreEqual(expected, result);
            result = poly.Eval(new Cplx() { Re = 1, Imaginari = 0 });
            expected = new Cplx() { Re = 2, Imaginari = 0 };
            Assert.AreEqual(expected, result);
            result = poly.Eval(new Cplx() { Re = 2, Imaginari = 0 });
            expected = new Cplx() { Re = 5.0000000000, Imaginari = 0 };
            Assert.AreEqual(expected, result);

            var r2 = poly.ToString();
            var e2 = "(1 + 0i) + (0 + 0i)x + (1 + 0i)xx";
            Assert.AreEqual(e2, r2);
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
    }
}


