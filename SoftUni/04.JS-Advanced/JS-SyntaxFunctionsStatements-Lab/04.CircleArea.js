function solution(input){
if (typeof(input) != 'number'){
    console.log('We can not calculate the circle area, because we receive a ' + typeof(input) + '.');
}else{
    let area = (input ** 2) * Math.PI;
console.log(area.toFixed(2));
}
}
