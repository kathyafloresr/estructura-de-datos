public class Main {
    public static int findEle(int[] arr, int l, int h, int targetValue) {
        while (l <= h) {
            int mid = 1 + (h - 1) / 2;

            if (arr[mid] == targetValue) {
                return mid;
            } else if (arr[mid] < targetValue) {
                l = mid + 1;
            } else {
                h = mid - 1;
            }
        }
        return -1;
    }

    public static void main(String[] args) {
        int[] inputArr = {12, 34, 10, 6, 40, 89, 98, 57, 19, 69};
        int targetElement = 40;
        int s = inputArr.length;
        int idx = findEle(inputArr, 0, s - 1, targetElement);

        if (idx != -1) {
            System.out.println("El elemento se encuentra en la posicion: " + (idx + 1));
        } else {
            System.out.println("El elemento no se encuentra.");
        }
    }
}