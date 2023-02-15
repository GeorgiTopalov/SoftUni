function solution(arrayOfStr) {
    arrayOfStr.sort((a, b) => {
       if (a.length === b.length){
        return a.localeCompare(b);
       }
       return a.length - b.length;
    });

    for (str of arrayOfStr){
        console.log(str);
    }
}

solution(['test', 
'Deny', 
'omen', 
'Default']
);

