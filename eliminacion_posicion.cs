using System;

class Program
{
    static void Main()
    {
        int[] inputArr = { 11, 21, 31, 41, 51, 61 };
        int position = 3;

        Console.WriteLine("Antes de la eliminación, el array es: ");
        for (int j = 0; j < inputArr.Length; j++)
        {
            Console.Write(inputArr[j] + " ");
            Console.Write("\nDespués de la eliminación, el array es: \n");
            for (int k = 0; k < inputArr.Length; k++)
            {
                Console.Write(inputArr[k] + " ");
            }
        }
    }
}