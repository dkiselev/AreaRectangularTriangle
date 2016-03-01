using Microsoft.VisualStudio.TestTools.UnitTesting;
using ru.Company.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ru.Company.Library.Tests
{
    [TestClass()]
    public class AreaRectangularTriangleTests
    {
        [TestMethod()]
        public void IsValidTest()
        {
            Assert.IsTrue(AreaRectangularTriangle.IsValid(0.0, 0.0));
            Assert.IsTrue(AreaRectangularTriangle.IsValid(1, 0));
            Assert.IsTrue(AreaRectangularTriangle.IsValid(2, 0.1));
            Assert.IsFalse(AreaRectangularTriangle.IsValid(-2, 0));
            Assert.IsFalse(AreaRectangularTriangle.IsValid(-2, -3));
            Assert.IsTrue(AreaRectangularTriangle.IsValid(double.MaxValue, 0));
            Assert.IsTrue(AreaRectangularTriangle.IsValid(double.MaxValue, double.MaxValue));
            Assert.IsFalse(AreaRectangularTriangle.IsValid(double.MinValue, 0));
            Assert.IsFalse(AreaRectangularTriangle.IsValid(double.NaN, 0));
            Assert.IsFalse(AreaRectangularTriangle.IsValid(double.NegativeInfinity, 0));
            Assert.IsTrue(AreaRectangularTriangle.IsValid(double.PositiveInfinity, 0));
        }

        [TestMethod()]
        public void IsValidTest1()
        {
            Assert.IsFalse(AreaRectangularTriangle.IsValid(-2, 0, 22));
            Assert.IsFalse(AreaRectangularTriangle.IsValid(-2, -3, 11));
            Assert.IsFalse(AreaRectangularTriangle.IsValid(-2, -3, -11));
            Assert.IsFalse(AreaRectangularTriangle.IsValid(1, 0, 0));
            Assert.IsFalse(AreaRectangularTriangle.IsValid(1, 5, 8));
            Assert.IsTrue(AreaRectangularTriangle.IsValid(0.0, 0.0, 0));
            Assert.IsTrue(AreaRectangularTriangle.IsValid(2, 0.1, Math.Sqrt(2*2 + 0.1*0.1)));
            Assert.IsTrue(AreaRectangularTriangle.IsValid(2, 0.1, Math.Sqrt(2 * 2 + 0.1 * 0.1), 3));
            Assert.IsTrue(AreaRectangularTriangle.IsValid(2, 0.0000000000000001, Math.Sqrt(2 * 2 + 0.0000000000000001 * 0.0000000000000001)));
            Assert.IsTrue(AreaRectangularTriangle.IsValid(3, 4, 5));
        }

        [TestMethod()]
        public void CalcAreaTest()
        {
            Assert.AreEqual(AreaRectangularTriangle.CalcArea(3, 4), 6);
            Assert.AreEqual(AreaRectangularTriangle.CalcArea(0.3, 0.4), 0.06);
        }

        [TestMethod()]
        public void CalcAreaTest1()
        {
            Assert.AreEqual(AreaRectangularTriangle.CalcArea(3, 4, 5), 6);
            Assert.AreEqual(Math.Round(AreaRectangularTriangle.CalcArea(0.3, 0.4, 0.5), 2), 0.06);
            Assert.IsTrue(double.IsInfinity(AreaRectangularTriangle.CalcArea(double.MaxValue, double.MaxValue, 0.1)));
        }
    }
}
