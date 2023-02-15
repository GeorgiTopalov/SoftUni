function solution(n, k) {
    let array = [1];
    let sumArray;
    let currentNum = 0;
    for (i = 1; i < n; i++) {
        sumArray = array.slice(-k);
        currentNum = sumArray.reduce((a,b) => a+b, 0);
        array.push(currentNum);
    }

    return array;
}

