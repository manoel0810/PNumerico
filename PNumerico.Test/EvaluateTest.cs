namespace PNumerico.Test
{
    public class EvaluateTest
    {
        [Fact]
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
            double[] realSolution = { 1d, 2d, 3d };

            Assert.Equal<double[]>(solution, realSolution);
        }
    }
}