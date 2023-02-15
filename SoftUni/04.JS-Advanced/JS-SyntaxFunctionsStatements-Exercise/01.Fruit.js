function solution(item, weight, price){
let weightInKg = weight/1000;
let totalPrice = price * weightInKg;

console.log('I need $' + totalPrice.toFixed(2) + ' to buy ' + weightInKg.toFixed(2) + ' kilograms ' + item + '.');
}
