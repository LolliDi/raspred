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
    }
}
