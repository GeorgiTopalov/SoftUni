function solution(array){

    let currentNum = array[0];
for (let i = 1; i < array.length; i++){

    if (array[i] < currentNum){
        array.splice(i, 1);
        i--;
    }else{
        currentNum = array[i];
    }
}


return array;
}

console.log(solution([1, 
    2, 
    3,
    4]
    ));
