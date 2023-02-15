function solve(input) {

    let groupLetter;
    for (const product of input.sort((a, b) => a.localeCompare(b))) {

        let [productName, price] = product.split(' : ');
        
        if (product[0] != groupLetter) {
            groupLetter = product[0].toUpperCase();
            console.log(groupLetter);
        } 

        console.log(`  ${productName}: ${price}`);
    }
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']);
