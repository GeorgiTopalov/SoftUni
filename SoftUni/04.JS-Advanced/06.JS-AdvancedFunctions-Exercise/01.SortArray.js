function solution(array, sortType){
    if (sortType === 'asc'){
        return array.sort((a,b) => a-b);
    }else{
        return array.sort((a,b) => b-a);
    }

}

console.log(solution([14, 7, 17, 6, 8], 'asc'));