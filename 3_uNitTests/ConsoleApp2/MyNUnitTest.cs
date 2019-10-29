using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestFixture]
    class MyNUnitTest
    {
        MyTriangleCheckMethode trl = new MyTriangleCheckMethode();
        [TestCase]
        public void IsTriangleRightTest()
        {
            Assert.AreEqual(true, trl.Check(5, 4, 6));
        }
        [TestCase]
        public void IsTriangleEquilateralTest()
        {
            Assert.AreEqual(true, trl.Check(3, 3, 3));
        }
        [TestCase]
        public void IsTriangleIsoscelesTest()
        {
            Assert.AreEqual(true, trl.Check(5, 9, 5));
        }
        [TestCase]
        public void IsTriangleFalseTest()
        {
            Assert.AreEqual(false, trl.Check(2, 3, 9));
        }
        [TestCase]
        public void IsTriangleOneSideNullTest()
        {
            Assert.AreEqual(false, trl.Check(7, 0, 12));
        }
        [TestCase]
        public void IsTriangleAllSideNullTest()
        {
            Assert.AreEqual(false, trl.Check(0, 0, 0));
        }
        [TestCase]
        public void IsTriangleOneSideNegativeTest()
        {
            Assert.AreEqual(false, trl.Check(4, -3, 10));
        }
        [TestCase]
        public void IsTriangleAllSigeNegativeTest()
        {
            Assert.AreEqual(false, trl.Check(-4, -12, -9));
        }
        [TestCase]
        public void IsTriangleAllSideDoubleTest()
        {
            Assert.AreEqual(true, trl.Check(2.5, 7.6, 6.1));
        }
        [TestCase]
        public void IsTriangleSideDoubleAndNegativeTest()
        {
            Assert.AreEqual(false, trl.Check(5.4, -1.9, 4.4));
        }
    }
}
