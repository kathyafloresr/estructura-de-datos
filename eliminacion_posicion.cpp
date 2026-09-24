#include <iostream>
#include <vector>

int main() {
    std::vector<int> inputArr = {11, 21, 31, 41, 51, 61};
    int position = 3;

    std::cout << "Antes de la eliminación, el array es: \n";
    for (size_t j = 0; j < inputArr.size(); ++j) {
        std::cout << inputArr[j] << " ";
        std::cout << "\nDespués de la eliminación, el array es: \n";
        for (size_t j = 0; j < inputArr.size(); ++j) {
            std::cout << inputArr[j] << " ";
        }
    }
    return 0;
}