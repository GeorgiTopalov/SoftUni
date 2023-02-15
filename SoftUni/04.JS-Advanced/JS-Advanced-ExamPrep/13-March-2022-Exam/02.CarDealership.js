class CarDealership {
    constructor(name){
        this.name = name;
        this.availableCars = [];
        this.soldCars = [];
        this.totalIncome = 0;
    }

    addCar(model, horsepower, price, mileage){
        if (model == '' || !Number.isInteger(horsepower) || horsepower < 0 || price < 0 || mileage < 0){
            throw new Error('Invalid input!');
        }

        this.availableCars.push({model, horsepower, price, mileage});

        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`
    }

    sellCar(model, desiredMileage){
        let desiredCar = this.availableCars.find(x => x.model == model);

        if(!desiredCar){
            throw new Error(`${model} was not found!`);
        }

        let mileageDifference = desiredCar.mileage - desiredMileage;

        let soldPrice = desiredCar.price;
        let horsepower = desiredCar.horsepower;

        if(mileageDifference > 0 && mileageDifference <= 40.000){
            soldPrice *= 0.95;
        }else if (mileageDifference > 40.000){
            soldPrice *= 0.90;
        }

        this.soldCars.push({model,horsepower,soldPrice});

        let indexOfCar = this.availableCars.indexOf(desiredCar);
        this.availableCars.splice(indexOfCar, 1);

        this.totalIncome+= soldPrice;

        return `${model} was sold for ${soldPrice.toFixed(2)}$`
    }

    currentCar(){
        if (this.availableCars.length == 0){
            return `There are no available cars`;
        }

        let message = "-Available cars:\n"

        for (const car of this.availableCars) {
            message += `---${car.model} - ${car.horsepower} HP - ${car.mileage.toFixed(2)} km - ${car.price.toFixed(2)}$\n`
        }

        return message.trimEnd();
    }

    salesReport(criteria){
        if(criteria != 'horsepower' && criteria != 'model'){
            throw new Error("Invalid criteria!");
        }

        if (criteria == 'horsepower'){
            this.soldCars.sort((a,b) => b.horsepower - a.horsepower);
        }else if (criteria == 'model'){
            this.soldCars.sort((a,b) => a.model.localeCompare(b.model));
        }

        let report = `-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$\n-${this.soldCars.length} cars sold:\n`;

        for (const car of this.soldCars) {
            report += `---${car.model} - ${car.horsepower} HP - ${car.soldPrice.toFixed(2)}$\n`
        }

        return report.trimEnd();
    }
}

let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
dealership.sellCar('Toyota Corolla', 230000);
dealership.sellCar('Mercedes C63', 110000);
dealership.sellCar('Audi A3', 240000);
console.log(dealership.currentCar());
console.log(dealership.salesReport('model'));



