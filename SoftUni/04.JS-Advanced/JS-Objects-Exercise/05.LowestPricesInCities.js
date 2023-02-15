function solve(input) {

    let products = [];

    while (input.length > 0) {
       
        let[town, product, price] = input.shift().split(' | ');
       
        if (products.filter(x => x.product == product).length > 0){

            let newProduct = products.find(x => x.product == product);

            if(newProduct.price > Number(price)){
                newProduct.price = Number(price);
                newProduct.town = town;
            }
        }else{
            let newProduct = {product, town, price:Number(price)};
            products.push(newProduct);
        }
    }

    for (let item of products) {
        console.log(`${item.product} -> ${item.price} (${item.town})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);