let inputArr = [11, 21, 31, 41, 51, 61];
let position = 3;

process.stdout.write("Antes de la eliminación, el array es: \n");
for (let j = 0; j < inputArr.length; j++) {
    process.stdout.write(inputArr[j] + " ");
    process.stdout.write("\nDespués de la eliminación, el array es: \n");
    for (let k = 0; k < inputArr.length; k++) {
        process.stdout.write(inputArr[k] + " ");
    }
}