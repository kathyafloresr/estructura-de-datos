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

        // Convertir el arreglo 2D en 1D
        for (int x = 0; x < r; x++) {
            for (int y = 0; y < c; y++) {
                k = x * r + y;
                arr[k] = TwoDArr[x][y];
                k++;
            }
        }

        System.out.println("Los elementos del array bidimensional son:");

        for (int x = 0; x < r; x++) {
            for (int y = 0; y < c; y++) {
                System.out.print(TwoDArr[x][y] + " ");
            }

            System.out.println();
        }

        System.out.println("\nLos elementos del array unidimensional son:");

        for (int x = 0; x < r; x++) {
            for (int y = 0; y < c; y++) {
                System.out.print(arr[x * r + y] + " ");
            }
        }
    }
}