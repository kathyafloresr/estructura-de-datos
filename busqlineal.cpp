#include <iostream>
using namespace std;

int findEle(int inputArr[], int s, int targetEle) {
    for (int j = 0; j < s; j++) {
        if (inputArr[j] == targetEle) {
            return j;
        }
    }

    return -1;
}

int main() {
    int inputArr[] = {12, 34, 10, 6, 40, 89, 57, 19, 69};
    int targetElement = 40;

    int s = sizeof(inputArr) / sizeof(inputArr[0]);

    int idx = findEle(inputArr, s, targetElement);

    if (idx != -1) {
        cout << "El elemento se encuentra en la posicion: "
             << idx + 1 << endl;
    } else {
        cout << "No se encuentra el elemento." << endl;
    }

    return 0;
}