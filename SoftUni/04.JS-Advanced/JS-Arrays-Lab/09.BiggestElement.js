function solution(array){
let biggestElement;

for (let i = 0; i < array.length; i++){

    for (let j = 0; j <array[i].length; j++){
        if (biggestElement === undefined || biggestElement < array[i][j]){
            biggestElement = array[i][j];
        }
    }
}

return biggestElement;
}
