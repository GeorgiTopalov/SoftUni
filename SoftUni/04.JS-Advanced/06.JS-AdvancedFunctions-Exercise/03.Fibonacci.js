function getFibonator() {
    let numberOne = 0;
    let numberTwo = 1;

    return () => {
        
        let outputNum = numberOne + numberTwo;
        numberOne = numberTwo;
        numberTwo = outputNum;

        return numberOne;
    };

}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
