using System;

class Program
{
    static void Main()
    {
        int r = 3;
        int c = 3;
        int[] arr = new int[r * c];
        int[][] TwoDArr = new int[][]
        {
            new int[] {1, 2, 3},
            new int[] {4, 5, 6},
            new int[] {7, 8, 9}
        };
        int k = 0;

        for (int x = 0; x < r; x++)
        {
            for (int y = 0; y < c; y++)
            {
                k = x * r + y;
                arr[k] = TwoDArr[x][y];
                k = k + 1;

                Console.WriteLine("Los elementos del array bidimiensioanl son: ");
                foreach (int[] row in TwoDArr)
                {
                    foreach (int ele in row)
                    {
                        Console.Write(ele + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\nLos elementos del array unidimensional son: ");
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        Console.Write(arr[i * r + j] + " ");
                    }
                }
            }
        }
    }
}