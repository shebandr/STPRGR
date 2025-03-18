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
            CNum result = CNum.Sum(a, b);

            Assert.AreEqual(4, result.GetReal());
            Assert.AreEqual(6, result.GetIm());
        }

        [TestMethod]
        public void TestMult()
        {
            CNum a = new CNum(3, 4);
            CNum b = new CNum(1, 2);
            CNum result = CNum.Mult(a, b);

            Assert.AreEqual(-5, result.GetReal());
            Assert.AreEqual(10, result.GetIm());
        }

        [TestMethod]
        public void TestSub()
        {
            CNum a = new CNum(3, 4);
            CNum b = new CNum(1, 2);
            CNum result = CNum.Sub(a, b);

            Assert.AreEqual(2, result.GetReal());
            Assert.AreEqual(2, result.GetIm());
        }

        [TestMethod]
        public void TestDiv()
        {
            CNum a = new CNum(3, 4);
            CNum b = new CNum(1, 2);
            CNum result = CNum.Div(a, b);

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
            double result = a.Deg();

            Assert.AreEqual(45, result, 0.0001);
        }

        [TestMethod]
        public void TestCnrad()
        {
            CNum a = new CNum(1, 1);
            double result = a.Rad();

            Assert.AreEqual(Math.PI / 4, result, 0.0001);
        }

        [TestMethod]
        public void TestPwr()
        {
			CNum a = new CNum(1, 1);
			CNum b = new CNum(2, 0);

			CNum c = CNum.Pwr(a, b);

			Assert.AreEqual(0, c.GetReal(), 0.0001);
            Assert.AreEqual(2, c.GetIm(), 0.0001);
        }

        [TestMethod]
        public void TestRoot()
        {
			CNum a = new CNum(1, 1);
			CNum b = new CNum(2, 0);

			CNum c = CNum.Root(a, b);

            Assert.AreEqual(1.0987, c.GetReal(), 0.0001);
            Assert.AreEqual(0.4551, c.GetIm(), 0.0001);
        }
    }
}