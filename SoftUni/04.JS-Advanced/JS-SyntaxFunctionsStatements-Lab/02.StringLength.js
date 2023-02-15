function solution(stringOne, stringTwo, stringThree){
    let firstLength = stringOne.length;
    let secondLength = stringTwo.length;
    let thirdLength = stringThree.length;
    let sum = firstLength + secondLength + thirdLength;
    console.log(sum);
    let average = Math.floor(sum / 3);
    console.log(average);
}

