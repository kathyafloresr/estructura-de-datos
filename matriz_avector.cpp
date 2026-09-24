#include <iostream>
#include <vector>

int main() {
    int r = 3;
    int c = 3;
    std::vector<int> arr(r * c, 0);
    std::vector<std::vector<int>> TwoDArr = {
        {1, 2, 3},
        {4, 5, 6},
        {7, 8, 9}
    };
    int k = 0;

    for (int x = 0; x < r; ++x) {
        for (int y = 0; y < c; ++y) {
            k = x * r + y;
            arr[k] = TwoDArr[x][y];
            k = k + 1;

            std::cout << "Los elementos del array bidimiensioanl son: \n";
            for (const auto& row : TwoDArr) {
                for (int ele : row) {
                    std::cout << ele << " ";
                }
                std::cout << "\n";
            }

            std::cout << "\nLos elementos del array unidimensional son: \n";
            for (int i = 0; i < r; ++i) {
                for (int j = 0; j < c; ++j) {
                    std::cout << arr[i * r + j] << " ";
                }
            }
        }
    }

    return 0;
}