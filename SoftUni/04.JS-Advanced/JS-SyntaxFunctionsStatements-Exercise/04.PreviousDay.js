function solution(year, month, day){
const date = new Date(year, month, day);
date.setDate(date.getDate()-1);
console.log(`${date.getFullYear()}-${date.getMonth()+1}-${date.getDate()}`);
}

