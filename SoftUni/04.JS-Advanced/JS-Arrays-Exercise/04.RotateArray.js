function solution(array, numberOfShifts){
let currentElement = '';

for(let i = 0; i < numberOfShifts; i++){
    currentElement = array.pop();
    array.unshift(currentElement);
}

console.log(array.join(' '));
}

solution(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15);