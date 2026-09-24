const ThreeDimensionalArray = [
    [
        [1, 2, 3],
        [4, 5, 6],
        [7, 8, 9]
    ],
    [
        [10, 11, 12],
        [13, 14, 15],
        [16, 17, 18]
    ]
];

console.log("Los elementos del array son: ");
for (const TwoDimensionalArray of ThreeDimensionalArray) {
    for (const row of TwoDimensionalArray) {
        for (const element of row) {
            process.stdout.write(element + " ");
        }
    }
    console.log();
}