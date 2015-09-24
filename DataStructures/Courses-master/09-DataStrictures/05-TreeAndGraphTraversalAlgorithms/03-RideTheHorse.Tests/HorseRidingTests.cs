using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03_RideTheHorse;

namespace _03_RideTheHorse.Tests
{
    [TestClass]
    public class HorseRidingTests
    {
        [TestMethod]
        public void TestFillMatrixWithValues_6_7_3_4()
        {
            int[,] init = new int[6, 7];
            int[,] matrix = HorseRiding.FillMatrixWithValues(3, 4, init);

            int[] expectedOutput = { 3, 2, 3, 4, 3, 2 };
            int col = matrix.GetLength(1) / 2;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Assert.AreEqual(expectedOutput[i], matrix[i, col]);
            }
        }

        [TestMethod]
        public void TestFillMatrixWithValues_6_7_0_0()
        {
            int[,] init = new int[6, 7];
            int[,] matrix = HorseRiding.FillMatrixWithValues(0, 0, init);

            int[] expectedOutput = { 4, 3, 4, 3, 4, 5 };
            int col = matrix.GetLength(1) / 2;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Assert.AreEqual(expectedOutput[i], matrix[i, col]);
            }
        }

        [TestMethod]
        public void TestFillMatrixWithValues_8_5_2_3()
        {
            int[,] init = new int[8, 5];
            int[,] matrix = HorseRiding.FillMatrixWithValues(2, 3, init);

            int[] expectedOutput = { 2, 3, 4, 3, 2, 3, 4, 5};
            int col = matrix.GetLength(1) / 2;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Assert.AreEqual(expectedOutput[i], matrix[i, col]);
            }
        }
    }
}
