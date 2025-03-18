using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using STPRGR;


namespace STPRGR
{
    [TestClass]
    public class CnumTests
    {
        [TestMethod]
        public void TestSum()
        {
            CNum a = new CNum(3, 4);
            CNum b = new CNum(1, 2);
            CNum result = a.Sum(a, b);

            Assert.AreEqual(4, result.GetReal());
            Assert.AreEqual(6, result.GetIm());
        }

        [TestMethod]
        public void TestMult()
        {
            CNum a = new CNum(3, 4);
            CNum b = new CNum(1, 2);
            CNum result = a.Mult(a, b);

            Assert.AreEqual(-5, result.GetReal());
            Assert.AreEqual(10, result.GetIm());
        }

        [TestMethod]
        public void TestSub()
        {
            CNum a = new CNum(3, 4);
            CNum b = new CNum(1, 2);
            CNum result = a.Sub(a, b);

            Assert.AreEqual(2, result.GetReal());
            Assert.AreEqual(2, result.GetIm());
        }

        [TestMethod]
        public void TestDiv()
        {
            CNum a = new CNum(3, 4);
            CNum b = new CNum(1, 2);
            CNum result = a.Div(a, b);

            Assert.AreEqual(2.2, result.GetReal(), 0.0001);
            Assert.AreEqual(-0.4, result.GetIm(), 0.0001);
        }

        [TestMethod]
        public void TestMdl()
        {
            CNum a = new CNum(3, 4);
            double result = a.Mdl();

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestCnr()
        {
            CNum a = new CNum(1, 1);
            double result = a.Cnr();

            Assert.AreEqual(45, result, 0.0001);
        }

        [TestMethod]
        public void TestCnrad()
        {
            CNum a = new CNum(1, 1);
            double result = a.Cnrad();

            Assert.AreEqual(Math.PI / 4, result, 0.0001);
        }

        [TestMethod]
        public void TestPwr()
        {
            CNum a = new CNum(1, 1);
            a.Pwr(2, 0);

            Assert.AreEqual(0, a.GetReal(), 0.0001);
            Assert.AreEqual(2, a.GetIm(), 0.0001);
        }

        [TestMethod]
        public void TestRoot()
        {
            CNum a = new CNum(1, 1);
            a.Root(2, 0);

            Assert.AreEqual(1.0987, a.GetReal(), 0.0001);
            Assert.AreEqual(0.4551, a.GetIm(), 0.0001);
        }
    }
}