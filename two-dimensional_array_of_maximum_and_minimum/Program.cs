namespace two_dimensional_array_of_maximum_and_minimum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = GenerateRandomArray(5, 5, -100, 100);
            PrintArray(array);

            int minIndexX, minIndexY, maxIndexX, maxIndexY;
            FindMinMaxIndexes(array, out minIndexX, out minIndexY, out maxIndexX, out maxIndexY);

            int sum = SumElementsBetweenMinMax(array, minIndexX, minIndexY, maxIndexX, maxIndexY);

            Console.WriteLine($"Сумма элементов между минимальным и максимальным элементами: {sum}");
        }

        static int[,] GenerateRandomArray(int rows, int columns, int minValue, int maxValue)
        {
            Random random = new Random();
            int[,] array = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
            return array;
        }

        static void PrintArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void FindMinMaxIndexes(int[,] array, out int minIndexX, out int minIndexY, out int maxIndexX, out int maxIndexY)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            minIndexX = 0;
            minIndexY = 0;
            maxIndexX = 0;
            maxIndexY = 0;

            int min = array[minIndexX, minIndexY];
            int max = array[maxIndexX, maxIndexY];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minIndexX = i;
                        minIndexY = j;
                    }

                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        maxIndexX = i;
                        maxIndexY = j;
                    }
                }
            }
        }

        static int SumElementsBetweenMinMax(int[,] array, int minIndexX, int minIndexY, int maxIndexX, int maxIndexY)
        {
            int sum = 0;
            int startX, endX, startY, endY;

            if (minIndexX < maxIndexX)
            {
                startX = minIndexX;
                endX = maxIndexX;
            }
            else
            {
                startX = maxIndexX;
                endX = minIndexX;
            }

            if (minIndexY < maxIndexY)
            {
                startY = minIndexY;
                endY = maxIndexY;
            }
            else
            {
                startY = maxIndexY;
                endY = minIndexY;
            }

            for (int i = startX + 1; i < endX; i++)
            {
                for (int j = startY + 1; j < endY; j++)
                {
                    sum += array[i, j];
                }
            }

            return sum;
        }
    }
}
