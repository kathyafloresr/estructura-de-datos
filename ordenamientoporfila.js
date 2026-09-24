let r = 3;
let c = 3;

let arr = new Array(r * c).fill(0);

let TwoDArr = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
];

let k = 0;

// Convertir el arreglo 2D en 1D
for (let x = 0; x < r; x++) {
    for (let y = 0; y < c; y++) {
        k = x * r + y;
        arr[k] = TwoDArr[x][y];
        k++;
    }
}

console.log("Los elementos del array bidimensional son:");

for (let x = 0; x < r; x++) {
    for (let y = 0; y < c; y++) {
        process.stdout.write(TwoDArr[x][y] + " ");
    }

    console.log();
}

console.log("\nLos elementos del array unidimensional son:");

for (let x = 0; x < r; x++) {
    for (let y = 0; y < c; y++) {
        process.stdout.write(arr[x * r + y] + " ");
    }
}