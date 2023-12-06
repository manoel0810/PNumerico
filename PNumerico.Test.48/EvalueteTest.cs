using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PNumerico.Test._48
{
    [TestClass]
    public class EvalueteTest
    {
        [TestMethod]
        public void GaussPossivelDeterminado()
        {
            double[,] values = new double[3, 4];
            int[] nvalues = { 1, -2, 3, 6, 2, -1, -1, -3, 1, -3, 2, 1 };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    values[i, j] = (double)nvalues[4 * i + j];
                }
            }

            double[] solution = PNumerico.Math.Calculate.Gauss(values);
            double[] realSolution = { 1.0000, 2.0000, 3.0000 };


            bool check = solution.Length == 3;

            if (!check)
                Assert.Fail();


            for (int i = 0; i < 3; i++)
            {
                check = Math.Round(solution[i], 4) == realSolution[i];
                if (!check)
                    Assert.Fail();
            }

            Assert.IsTrue(check);
        }
    }
}
