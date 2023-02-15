function solution(arrayOfNames){
let counter = 1;
arrayOfNames.sort( function (a,b) {
    return a.toLowerCase().localeCompare(b.toLowerCase());
})
    for (item of arrayOfNames){
        console.log(`${counter}.${item}`);
        counter++;
    }
}

solution(["John", "bob", "Christina", "Ema"]);