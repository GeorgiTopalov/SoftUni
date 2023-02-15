function solution() {
    
    let microelements = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0,
    };

    const recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
    };

    function restock(element, quantity) {
        microelements[element] += Number(quantity);
        return 'Success';
    }

    function prepare(recipe, quantity) {

        let remainingIngredients = {};

        for (const ingredient in recipes[recipe]) {
            let remaining = microelements[ingredient] - recipes[recipe][ingredient] * Number(quantity);

            if (remaining < 0) {
                return `Error: not enough ${ingredient} in stock`
            }

            remainingIngredients[ingredient] = remaining;
        }

        Object.assign(microelements, remainingIngredients);
        return 'Success';
    }

    function report() {
        return `protein=${microelements[protein]} carbohydrates=${microelements[carbohydrate]} fat=${microelements[fat]} flavour=${microelements[flavour]}`;
    }

    return commandExecution = (input) => {
        let [command, element, quantity] = input.split(' ');
        
        if (command == 'restock') {
            return restock(element, quantity);
        } else if (command == 'prepare') {
            return prepare(element, quantity);
        } else {
            return report();
        }
    }

}


let manager = solution();
console.log(manager('restock flavour 50 '));
console.log(manager('prepare lemonade 4 '));
console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));