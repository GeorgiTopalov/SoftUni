function solution(){
    let stringToModify = '';

    return {
           append(str){
            stringToModify += str;
           },
           removeStart(num){
            stringToModify = stringToModify.substring(num);
           },
           removeEnd(num){
            stringToModify = stringToModify.substring(0,stringToModify.length - num);
           },
           print(){
            console.log(stringToModify);
           },
    };
}



let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();