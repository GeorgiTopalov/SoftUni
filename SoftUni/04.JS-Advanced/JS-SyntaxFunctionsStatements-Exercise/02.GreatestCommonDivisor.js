function solution(numOne, numTwo){
    let divisor;
    let smallerNum;

    if (numOne < numTwo){
        smallerNum = numOne;
    }else{
        smallerNum = numTwo;
    }

    for(i = smallerNum; i > 0; i--){
        if (numOne % i == 0 && numTwo % i == 0){
            divisor = i;
            break;
        }
    }
    console.log(divisor);
}

