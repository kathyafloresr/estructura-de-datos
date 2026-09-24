#include <iostream>
using namespace std;

void bubbleSort(int a[], int s) {

    for (int i = 0; i < s; i++) {

        bool isSwapped = false;

        for (int j = 0; j < s - i - 1; j++) {

            if (a[j] > a[j + 1]) {

                int temp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = temp;

                isSwapped = true;
            }
        }

        if (isSwapped == false) {
            break;
        }
    }
}

int main() {

    int a[] = {15, 16, 11, 13, 14};

    int s = sizeof(a) / sizeof(a[0]);

    cout << "Antes de ordenar los elementos del array son:" << endl;

    for (int j = 0; j < s; j++) {
        cout << a[j] << " ";
    }

    bubbleSort(a, s);

    cout << "\nDespues de ordenar los elementos del array son:" << endl;

    for (int j = 0; j < s; j++) {
        cout << a[j] << " ";
    }

    return 0;
}