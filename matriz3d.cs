using System;

class Program
{
    static void Main()
    {
        int[][][] ThreeDimensionalArray = new int[][][]
        {
            new int[][]
            {
                new int[] {1, 2, 3},
                new int[] {4, 5, 6},
                new int[] {7, 8, 9}
            },
            new int[][]
            {
                new int[] {10, 11, 12},
                new int[] {13, 14, 15},
                new int[] {16, 17, 18}
            }
        };

        Console.WriteLine("Los elementos del array son: ");
        foreach (int[][] TwoDimensionalArray in ThreeDimensionalArray)
        {
            foreach (int[] row in TwoDimensionalArray)
            {
                foreach (int element in row)
                {
                    Console.Write(element + " ");
                }
            }
            Console.WriteLine();
        }
    }
}