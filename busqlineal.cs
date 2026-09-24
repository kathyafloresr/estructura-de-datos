using System;

class Program
{
    static int findEle(int[] inputArr, int s, int targetEle)
    {
        for (int j = 0; j < s; j++)
        {
            if (inputArr[j] == targetEle)
            {
                return j;
            }
        }

        return -1;
    }

    static void Main()
    {
        int[] inputArr = { 12, 34, 10, 6, 40, 89, 57, 19, 69 };
        int targetElement = 40;

        int s = inputArr.Length;

        int idx = findEle(inputArr, s, targetElement);

        if (idx != -1)
        {
            Console.WriteLine(
                "El elemento se encuentra en la posicion: " + (idx + 1)
            );
        }
        else
        {
            Console.WriteLine("No se encuentra el elemento.");
        }
    }
}