#include <iostream>
#include <vector>
#include <string>

int findEle(const std::vector<int>& inputArr, int s, int targetEle) {
    for (int j = 0; j < s; ++j) {
        if (inputArr[j] == targetEle) {
            return j;
        }
    }
    return -1;
}

int main() {
    std::vector<int> inputArr = {12, 34, 10, 6, 40, 89, 57, 19, 69};
    int targetElement = 40;
    int s = inputArr.size();
    int idx = findEle(inputArr, s, targetElement);

    if (idx != -1) {
        std::cout << "El elemento se encuentra en la posición: " << (idx + 1) << std::endl;
    } else {
        std::cout << "No se encuentra el elemento." << std::endl;
    }

    return 0;
}