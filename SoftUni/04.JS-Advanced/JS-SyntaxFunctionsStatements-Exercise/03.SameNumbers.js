function solution(input){

    let inputNum = input.toString();
    let areSame = true;
    let sum = 0;
    let currentDigit = inputNum[0];

    for(let i = 0; i < inputNum.length; i++){
        if (inputNum[i] !== currentDigit){
            areSame = false;
        }
        sum += Number(inputNum[i]);
    }
    console.log(areSame);
    console.log(sum);
}

