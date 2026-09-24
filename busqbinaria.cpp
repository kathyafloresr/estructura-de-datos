#include <iostream>
#include <vector>

int findEle(const std::vector<int>& arr, int l, int h, int targetValue) {
    while (l <= h) {
        int mid = 1 + (h - 1) / 2;

        if (arr[mid] == targetValue) {
            return mid;
        } else if (arr[mid] < targetValue) { // Corregida la variable 'x' por targetValue
            l = mid + 1;
        } else {
            h = mid - 1;
        }
    }
    return -1;
}

int main() {
    std::vector<int> inputArr = {12, 34, 10, 6, 40, 89, 98, 57, 19, 69};
    int targetElement = 40;
    int s = inputArr.size();
    int idx = findEle(inputArr, 0, s - 1, targetElement);

    if (idx != -1) {
        std::cout << "El elemento se encuentra en la posicion: " << (idx + 1) << std::endl;
    } else {
        std::cout << "El elemento no se encuentra." << std::endl;
    }

    return 0;
}