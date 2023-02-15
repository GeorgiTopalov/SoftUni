function solution(arrayOfNums){

    let outputArray = [];
    arrayOfNums.sort((a,b) => a - b);
    let length = arrayOfNums.length;
    let biggestNum;
    let smallestNum;
    for (i = 0; i < length; i++){
        
        if (i === 0 || i % 2 == 0){
            smallestNum = arrayOfNums.shift();
            outputArray.push(smallestNum);
        }else{
            biggestNum = arrayOfNums.pop()
            outputArray.push(biggestNum);
        }
    }

    return outputArray;
}

console.log(solution([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));