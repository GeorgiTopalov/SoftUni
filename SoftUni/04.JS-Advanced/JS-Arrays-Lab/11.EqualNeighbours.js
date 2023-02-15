function solution(array){

    
    let rightNum = '';
    let bottomNum = '';
    let count = 0;

    for (i = 0; i < array.length; i++){
        
        for (j = 0; j < array[i].length; j++){

        let currentNum = array[i][j];

            if (i+1 < array.length){
                bottomNum = array[i+1][j];
                if (currentNum === bottomNum){
                    count++;
                }
            }
            
            if (j+1 < array[i].length){
                rightNum = array[i][j+1];

                if (currentNum === rightNum){
                    count++;
                }
            }
            
        }
    }
    
    return count;
}

solution([['2', '2', '5', '7', '4'],
         ['4' ,'0', '5' ,'3' ,'4'],
         ['2','5', '5', '4' ,'2']]);
