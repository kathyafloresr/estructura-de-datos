function findEle(inputArr, s, targetEle) {
    for (let j = 0; j < s; j++) {
        if (inputArr[j] === targetEle) {
            return j;
        }
    }

    return -1;
}

let inputArr = [12, 34, 10, 6, 40, 89, 57, 19, 69];
let targetElement = 40;

let s = inputArr.length;

let idx = findEle(inputArr, s, targetElement);

if (idx !== -1) {
    console.log(
        "El elemento se encuentra en la posicion: " + (idx + 1)
    );
} else {
    console.log("No se encuentra el elemento.");
}