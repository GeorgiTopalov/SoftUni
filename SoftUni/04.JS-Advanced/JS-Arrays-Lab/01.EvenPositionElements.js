function solution(array) {
    let result = '';
    for (i = 0; i < array.length; i+=2) {
        result += array[i] + ' ';
    }
    console.log(result);
}
