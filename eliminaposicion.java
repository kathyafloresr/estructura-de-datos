public class Main {
    public static void main(String[] args) {
        int[] inputArr = {11, 21, 31, 41, 51, 61};
        int position = 3;

        System.out.println("Antes de la eliminación, el array es: ");
        for (int j = 0; j < inputArr.length; j++) {
            System.out.print(inputArr[j] + " ");
            System.out.print("\nDespués de la eliminación, el array es: \n");
            for (int k = 0; k < inputArr.length; k++) {
                System.out.print(inputArr[k] + " ");
            }
        }
    }
}