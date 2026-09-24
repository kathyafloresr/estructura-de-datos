const TwoDimensionalArray = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
];

console.log("Los elementos del array son: ");
for (const row of TwoDimensionalArray) {
    for (const element of row) {
        process.stdout.write(element + " ");
        console.log();
    }
}