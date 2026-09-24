#include <iostream>
#include <vector>

int main() {
    std::vector<std::vector<int>> TwoDimensionalArray = {
        {1, 2, 3},
        {4, 5, 6},
        {7, 8, 9}
    };

    std::cout << "Los elementos del array son: \n";
    for (const auto& row : TwoDimensionalArray) {
        for (int element : row) {
            std::cout << element << " ";
            std::cout << "\n";
        }
    }

    return 0;
}