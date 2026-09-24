using System;

class Program
{
    static void BubbleSort(int[] a)
    {
        int s = a.Length;

        for (int i = 0; i < s; i++)
        {
            bool isSwapped = false;

            for (int j = 0; j < s - i - 1; j++)
            {
                if (a[j] > a[j + 1])
                {
                    int temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;

                    isSwapped = true;
                }
            }

            if (isSwapped == false)
            {
                break;
            }
        }
    }

    static void Main()
    {
        int[] a = { 15, 16, 11, 13, 14 };

        Console.WriteLine("Antes de ordenar los elementos del array son:");

        for (int j = 0; j < a.Length; j++)
        {
            Console.Write(a[j] + " ");
        }

        BubbleSort(a);

        Console.WriteLine("\nDespués de ordenar los elementos del array son:");

        for (int j = 0; j < a.Length; j++)
        {
            Console.Write(a[j] + " ");
        }
    }
}