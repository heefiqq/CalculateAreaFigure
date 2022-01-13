using СalculateAreaFigure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.CalculateAreaFigureTest
{
    [TestClass]
    public class CalculateAreaTest
    {
        [TestMethod]
        public void TestCircle()
        {
            double area;
            area = CalculateAreaFigure.CalculateArea(5);
            Assert.AreEqual(15.7, area);
        }

        [TestMethod]
        public void TestTriangle()
        {
            double area;
            area = CalculateAreaFigure.CalculateArea(9, 8, 7);
            Assert.AreEqual(26.83, area);
        }

        [TestMethod]
        public void TestIsoscelesTriangle()
        {
            double area;
            area = CalculateAreaFigure.CalculateArea(6, 6, 3);
            Assert.AreEqual(8.71, area);
        }

        [TestMethod]
        public void TestRightTriangle()
        {
            double area;
            area = CalculateAreaFigure.CalculateArea(3, 4, 5);
            Assert.AreEqual(6, area);
        }

        [TestMethod]
        public void TestThrowTriangle()
        {
            Assert.ThrowsException<Exception>(() => CalculateAreaFigure.CalculateArea(9, 3, 4));
        }

        [TestMethod]
        public void TestSquare()
        {
            double area;
            area = CalculateAreaFigure.CalculateArea(4, 4, 4, 4);
            Assert.AreEqual(16, area);
        }

        [TestMethod]
        public void TestRectangle()
        {
            double area;
            area = CalculateAreaFigure.CalculateArea(4,5,4,5);
            Assert.AreEqual(20, area);
        }

        [TestMethod]
        public void TestTrapeze()
        {
            double area;
            area = CalculateAreaFigure.CalculateArea(10, 7, 6, 6);
            Assert.AreEqual(49.38, area);
        }
    }
}
