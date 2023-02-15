function solution(input){

    let cities = {};

    for (const city of input) {
        const cityProps = city.split(" <-> ");
        let cityName = cityProps[0];
        let population = Number(cityProps[1]);

        if (!cities[cityName]){
            cities[cityName] = 0;
        }
        
        cities[cityName] += population;
    }

    Object.entries(cities).forEach(x => {
        const[cityName, population] = x;
        console.log(`${cityName} : ${population}`);
    });
}

solution(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']);