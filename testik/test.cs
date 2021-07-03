using Microsoft.VisualStudio.TestTools.UnitTesting;
using raspred;

namespace testik
{
    [TestClass]
    public class test
    {
        [TestMethod]
        public void test_zapisi_massiva()
        {
            massiv a = new massiv("3 4 45 15 22 20 25 9 5 3 10 55 6 3 8 2 22 3 8 4 7");
            int[,] rezult = { { 0, 45, 15, 22, 20 }, { 25, 9, 5, 3, 10 }, { 55, 6, 3, 8, 2 }, { 22, 3, 8, 4, 7 } };
            CollectionAssert.AreEqual(rezult, a.mas);
        }
        [TestMethod]
        public void test_otvet()
        {
            massiv a = new massiv("3 4 45 15 22 20 25 9 5 3 10 55 6 3 8 2 22 3 8 4 7");
            string actual_otv = Program.reshenie(a);
            string nuzhn_otv = "От 1-го поставщика к 1-му потребителю едет 25 ед. товара по цене 9у.д.е. за шт." +
    "\nОт 2-го поставщика к 1-му потребителю едет 20 ед. товара по цене 6у.д.е. за шт." +
    "\nОт 2-го поставщика к 2-му потребителю едет 15 ед. товара по цене 3у.д.е. за шт." +
    "\nОт 2-го поставщика к 3-му потребителю едет 20 ед. товара по цене 8у.д.е. за шт." +
    "\nОт 3-го поставщика к 3-му потребителю едет 2 ед. товара по цене 4у.д.е. за шт." +
    "\nОт 3-го поставщика к 4-му потребителю едет 20 ед. товара по цене 7у.д.е. за шт." +
    "\nОтвет: F = 698у.д.е.";
            Assert.AreEqual(nuzhn_otv, actual_otv);
        }

    }
}
