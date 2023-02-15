function solution(array, firstFlavor, secondFlavor){

let startIndex = array.indexOf(firstFlavor);
let endIndex = array.indexOf(secondFlavor);

let outputArray = array.slice(startIndex, endIndex + 1);

return outputArray;
}

