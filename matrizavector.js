let r = 3;
let c = 3;
let arr = new Array(r * c).fill(0);
let TwoDArr = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
];
let k = 0;

for (let x = 0; x < r; x++) {
    for (let y = 0; y < c; y++) {
        k = x * r + y;
        arr[k] = TwoDArr[x][y];
        k = k + 1;

        console.log("Los elementos del array bidimiensioanl son: ");
        for (const row of TwoDArr) {
            for (const ele of row) {
                process.stdout.write(ele + " ");
            }
            console.log();
        }

        process.stdout.write("\nLos elementos del array unidimensional son: \n");
        for (let i = 0; i < r; i++) {
            for (let j = 0; j < c; j++) {
                process.stdout.write(arr[i * r + j] + " ");
            }
        }
    }
}