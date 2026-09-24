using System;

class Program
{
    static int FindEle(int[] arr, int l, int h, int targetValue)
    {
        while (l <= h)
        {
            int mid = 1 + (h - 1) / 2;

            if (arr[mid] == targetValue)
            {
                return mid;
            }
            else if (arr[mid] < targetValue)
            {
                l = mid + 1;
            }
            else
            {
                h = mid - 1;
            }
        }
        return -1;
    }

    static void Main()
    {
        int[] inputArr = { 12, 34, 10, 6, 40, 89, 98, 57, 19, 69 };
        int targetElement = 40;
        int s = inputArr.Length;
        int idx = FindEle(inputArr, 0, s - 1, targetElement);

        if (idx != -1)
        {
            Console.WriteLine("El elemento se encuentra en la posicion: " + (idx + 1));
        }
        else
        {
            Console.WriteLine("El elemento no se encuentra.");
        }
    }
}