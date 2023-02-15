function solution(input){
    let output;
if (input == 'Monday'){
    output = 1;
}else if (input == "Tuesday"){
    output = 2;
}else if (input == "Wednesday"){
    output = 3;
}else if (input == "Thursday"){
    output = 4;
}else if (input == "Friday"){
    output = 5;
}else if (input == "Saturday"){
    output = 6;
}else if (input == "Sunday"){
    output = 7;
}else{
    output = 'error';
} 
console.log(output);
}
