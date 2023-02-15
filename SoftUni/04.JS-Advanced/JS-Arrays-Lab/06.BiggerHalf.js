function solution(input){
let newArr = [];
input.sort((a,b) => a - b);
newArr = input.slice(input.length / 2);

return newArr;
}


