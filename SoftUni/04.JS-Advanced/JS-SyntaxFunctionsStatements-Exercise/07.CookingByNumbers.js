function solution(input, operationOne, operationTwo, operationThree, operationFour, operationFive){
let number = Number(input);
let operations = [operationOne, operationTwo, operationThree, operationFour, operationFive];

for (i = 0; i < operations.length; i++){
    if (operations[i] == 'chop'){
        number /= 2;
    }else if(operations[i] == 'dice'){
        number = Math.sqrt(number);
    }else if(operations[i] == 'spice'){
        number += 1;
    }else if(operations[i] == 'bake'){
        number *= 3;
    }else{
        number *= 0.80;
    }
    console.log(number);
}
}
