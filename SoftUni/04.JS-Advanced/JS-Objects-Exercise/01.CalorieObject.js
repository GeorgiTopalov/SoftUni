function solve(input){
let allFood = {};

for (let i = 0; i < input.length; i+=2){
    allFood[input[i]] = Number(input[i+1]);
}

console.log(allFood);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);