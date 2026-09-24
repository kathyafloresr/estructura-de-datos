function findEle(inputArr, s, targetEle) {
    for (let j = 0; j < s; j++) {
        if (inputArr[j] === targetEle) {
            return j;
        }
    }
    return -1;
}

const inputArr = [12, 34, 10, 6, 40, 89, 57, 19, 69];
const targetElement = 40;
const s = inputArr.length;
const idx = findEle(inputArr, s, targetElement);

if (idx !== -1) {
    console.log("El elemento se encuentra en la posición: " + (idx + 1));
} else {
    console.log("No se encuentra el elemento.");
}