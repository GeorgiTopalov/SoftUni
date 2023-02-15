function solution(array){
let firstDiagonalSum = 0;
let secondDiagonalSum = 0;

for (let i = 0; i < array.length; i++){

    firstDiagonalSum += array[i][i];
}
let row = 0;
for (let j = array.length - 1; j >= 0; j--){
    secondDiagonalSum += array[row][j];
    row++;
}

console.log(`${firstDiagonalSum} ${secondDiagonalSum}`);
}

