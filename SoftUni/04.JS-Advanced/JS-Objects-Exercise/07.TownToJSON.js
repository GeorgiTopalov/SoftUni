function solve(input){

    let tables = [];
    

    for (let i = 1; i < input.length; i++){

            let array = input[i].split('|');
            let town = array[1].trim();
            let lat = Number(array[2].trim()).toFixed(2)
            let long = Number(array[3].trim()).toFixed(2)
            let newTable = {
                Town: town,
                Latitude: lat,
                Longitude: long,
            };

            let tablesToJSON = JSON.stringify(newTable, function (key, value){
                if (key == 'Latitude'){
                    return Number(value);
                }else if (key == 'longtitude'){
                    return Number(value);
                }else{
                    return value;
                }
            });
            tables.push(tablesToJSON);
    }

    console.log('[' + tables.join(', ') + ']');
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']);