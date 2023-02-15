function solution(input){
let newArray = [];

for (element of input){
    if (element < 0){
        newArray.unshift(element);
    }
    else{
        newArray.push(element);
    }
}

for (number of newArray){
    console.log(number);
}
}


