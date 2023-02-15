function solution(array){
    let newArr = [];
    for (i = 1; i < array.length; i+=2){
        newArr.push(array[i]);
    }

    console.log(newArr.map(x => x*2).reverse().join(' '));
}

