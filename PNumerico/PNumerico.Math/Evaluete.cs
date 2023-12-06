namespace PNumerico.PNumerico.Math
{
    public class Calculate
    {
        public static double[] Gauss(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] == 0)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (matrix[j, i] != 0)
                        {
                            for (int k = 0; k <= n; k++)
                            {
                                double temp = matrix[i, k];
                                matrix[i, k] = matrix[j, k];
                                matrix[j, k] = temp;
                            }
                            break;
                        }
                    }
                }

                for (int j = i + 1; j < n; j++)
                {
                    double factor = matrix[j, i] / matrix[i, i];
                    for (int k = 0; k <= n; k++)
                    {
                        matrix[j, k] -= factor * matrix[i, k];
                    }
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                result[i] = matrix[i, n] / matrix[i, i];
                for (int j = i - 1; j >= 0; j--)
                {
                    matrix[j, n] -= matrix[j, i] * result[i];
                }
            }

            return result;
        }
    }
}
