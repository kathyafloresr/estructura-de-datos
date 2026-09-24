public class Main {
    public static void main(String[] args) {
        int[] inputArr = {11, 21, 31, 41, 51, 61};
        int position = 3;

        System.out.println("Antes de eliminar, el array es: ");
        for (int j = 0; j < inputArr.length; j++) {
            System.out.print(inputArr[j] + " ");
        }

        System.out.println("\nDespués de eliminar, el array es: ");
        for (int j = 0; j < inputArr.length; j++) {
            System.out.print(inputArr[j] + " ");
        }
    }
}