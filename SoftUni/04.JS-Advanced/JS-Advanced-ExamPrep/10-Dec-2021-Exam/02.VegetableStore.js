class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {

        let arrayOfAddedVeggies = [];

        for (const vegetableInfo of vegetables) {
            let type = vegetableInfo.split(' ')[0];
            let quantity = Number(vegetableInfo.split(' ')[1]);
            let price = Number(vegetableInfo.split(' ')[2]);

            let vegetable = this.availableProducts.find(x => x.type == type)

            if (!vegetable) {
                this.availableProducts.push({ type, quantity, price });
            } else {
                vegetable.quantity += quantity;
                if (vegetable.price < price) {
                    vegetable.price = price;
                }

            }
            if (!arrayOfAddedVeggies.includes(type)) {
                arrayOfAddedVeggies.push(type);
            }
        }

        return `Successfully added ${arrayOfAddedVeggies.join(', ')}`;
    }

    buyingVegetables (selectedProducts){

        let totalPrice = 0;

        for (const product of selectedProducts) {
            let type = product.split(' ')[0];
            let quantity = Number(product.split(' ')[1]);
            let vegetable = this.availableProducts.find(x => x.type == type);

            if (!vegetable){
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }else if (vegetable.quantity < quantity){
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            let currentCost = vegetable.price * quantity;
            totalPrice += currentCost;
            vegetable.quantity -= quantity;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }

    rottingVegetable (type, quantity){
        let vegetable = this.availableProducts.find(x => x.type == type);

        if(!vegetable){
            throw new Error(`${type} is not available in the store.`);
        }
        if (Number(quantity) > vegetable.quantity){
           vegetable.quantity = 0;
           return `The entire quantity of the ${type} has been removed.`
        }
        
        vegetable.quantity -= quantity;

        return `Some quantity of the ${type} has been removed.`
    }

    revision(){
        let message = 'Available vegetables:\n';

        for (const product of this.availableProducts.sort((a,b) => a.price - b.price)) {
            message += `${product.type}-${product.quantity}-$${product.price}\n`
        }

        message.trimEnd();
        message += `The owner of the store is ${this.owner}, and the location is ${this.location}.`

        return message;
    }
}

let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());


