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
            string nuzhn_otv = "�� 1-�� ���������� � 1-�� ����������� ���� 25 ��. ������ �� ���� 9�.�.�. �� ��." +
    "\n�� 2-�� ���������� � 1-�� ����������� ���� 20 ��. ������ �� ���� 6�.�.�. �� ��." +
    "\n�� 2-�� ���������� � 2-�� ����������� ���� 15 ��. ������ �� ���� 3�.�.�. �� ��." +
    "\n�� 2-�� ���������� � 3-�� ����������� ���� 20 ��. ������ �� ���� 8�.�.�. �� ��." +
    "\n�� 3-�� ���������� � 3-�� ����������� ���� 2 ��. ������ �� ���� 4�.�.�. �� ��." +
    "\n�� 3-�� ���������� � 4-�� ����������� ���� 20 ��. ������ �� ���� 7�.�.�. �� ��." +
    "\n�����: F = 698�.�.�.";
            Assert.AreEqual(nuzhn_otv, actual_otv);
        }

    }
}
