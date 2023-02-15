function solution(matrix){
   let isMagical = true;
   let colSum;
   let rowSum;

   for (let i = 0; i < matrix.length; i++){
     let currentRowSum = matrix[i].reduce((a,b) => a + b);
     if (rowSum !== undefined && rowSum !== currentRowSum){
        isMagical = false;
        break;
     }
     let currentColSum = 0;
     for (let j = 0; j < matrix.length; j++){

        currentColSum += matrix[j][i]
     }
     if (colSum !== undefined && colSum !== currentColSum){
        isMagical = false;
        break;
     }

     rowSum = currentRowSum;
     colSum = currentColSum;
   }

   return isMagical;
}

console.log(solution([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]));
