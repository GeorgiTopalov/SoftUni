function solution(array, startIndex, endIndex) {
    if (!Array.isArray(array)) {
        return NaN;
    }
    let start = Math.max(startIndex, 0);
    let end = Math.min(endIndex, array.length - 1);

    let subSum = array
    .slice(start, end + 1)
    .map(Number)
    .reduce((a, b) => a + b, 0);

    return subSum;
}

console.log(solution([10, 20, 30, 40, 50, 60], 3, 300));