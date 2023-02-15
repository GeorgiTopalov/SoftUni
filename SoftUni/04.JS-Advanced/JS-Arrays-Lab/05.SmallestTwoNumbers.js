function solution(input) {
    
    let firstNum = Math.min(...input);
    const index = input.indexOf(firstNum);
    input.splice(index, 1);
    let secondNum = Math.min(...input);
   
    console.log(`${firstNum} ${secondNum}`);
}
