function solution(commands){

    let arrayOfNums = [];

    for(let i = 0; i < commands.length; i++){
        if (commands[i] === 'add'){
        arrayOfNums.push(i+1);
        }else{
        arrayOfNums.pop();        
        }
    }

    if (arrayOfNums.length > 0){
        arrayOfNums.forEach(x => console.log(x));
    }else{
        console.log('Empty');
    }
}

