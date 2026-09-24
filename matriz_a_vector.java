public class Main {
    public static void main(String[] args) {
        int r = 3;
        int c = 3;
        int[] arr = new int[r * c];
        int[][] TwoDArr = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        int k = 0;

        for (int x = 0; x < r; x++) {
            for (int y = 0; y < c; y++) {
                k = x * r + y;
                arr[k] = TwoDArr[x][y];
                k = k + 1;

                System.out.println("Los elementos del array bidimiensioanl son: ");
                for (int[] row : TwoDArr) {
                    for (int ele : row) {
                        System.out.print(ele + " ");
                    }
                    System.out.println();
                }

                System.out.println("\nLos elementos del array unidimensional son: ");
                for (int i = 0; i < r; i++) {
                    for (int j = 0; j < c; j++) {
                        System.out.print(arr[i * r + j] + " ");
                    }
                }
            }
        }
    }
}