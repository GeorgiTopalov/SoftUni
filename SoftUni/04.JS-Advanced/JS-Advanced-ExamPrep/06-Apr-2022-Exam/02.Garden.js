class Garden{
    constructor(spaceAvailable){
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired){
        if (spaceRequired > this.spaceAvailable){
            throw new Error("Not enough space in the garden.");
        }

        this.plants.push({plantName, spaceRequired, ripe: false, quantity: 0});
        this.spaceAvailable -= spaceRequired;

        return `The ${plantName} has been successfully planted in the garden.`
    }

    ripenPlant(plantName, quantity){
        let currentPlant = this.plants.find(x => x.plantName == plantName);
        if (currentPlant == undefined){
           throw new Error(`There is no ${plantName} in the garden.`);
        }
        if (currentPlant.ripe == true){
            throw new Error(`The ${plantName} is already ripe.`);
        }
        if (quantity <= 0){
            throw new Error("The quantity cannot be zero or negative.");
        }

        currentPlant.ripe = true;
        currentPlant.quantity += quantity;

        if (quantity == 1){
            return `${quantity} ${plantName} has successfully ripened.`;
        }else{
            return `${quantity} ${plantName}s have successfully ripened.`;
        }
    }

    harvestPlant(plantName){
        let currentPlant = this.plants.find(x => x.plantName == plantName);

        if(currentPlant == undefined){
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        if (currentPlant.ripe == false){
            throw new Error (`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.storage.push(`${currentPlant.plantName} (${currentPlant.quantity})`);

        this.spaceAvailable += currentPlant.spaceRequired;
        const plantIndex = this.plants.indexOf(currentPlant);
        this.plants.splice(plantIndex, 1);

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport(){
        let information = `The garden has ${this.spaceAvailable} free space left.\n`;
        let allPlants = this.plants.map(x => x.plantName).join(', ');
        information += `Plants in the garden: ${allPlants}\n`;
        if (this.storage.length == 0){
            information += "Plants in storage: The storage is empty.";
        }else{
            information += `Plants in storage: ${this.storage.join(', ')}`;
        }

        return information;
    }
}class Garden{
    constructor(spaceAvailable){
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired){
        if (spaceRequired > this.spaceAvailable){
            throw new Error("Not enough space in the garden.");
        }

        this.plants.push({plantName, spaceRequired, ripe: false, quantity: 0});
        this.spaceAvailable -= spaceRequired;

        return `The ${plantName} has been successfully planted in the garden.`
    }

    ripenPlant(plantName, quantity){
        let currentPlant = this.plants.find(x => x.plantName == plantName);
        if (currentPlant == undefined){
           throw new Error(`There is no ${plantName} in the garden`);
        }
        if (currentPlant.ripe == true){
            throw new Error(`The ${plantName} is already ripe`);
        }
        if (quantity <= 0){
            throw new Error("The quantity cannot be zero or negative.");
        }

        currentPlant.ripe = true;
        currentPlant.quantity += quantity;

        if (quantity == 1){
            return `${quantity} ${plantName} has successfully ripened.`;
        }else{
            return `${quantity} ${plantName}s have successfully ripened.`;
        }
    }

    harvestPlant(plantName){
        let currentPlant = this.plants.find(x => x.plantName == plantName);

        if(currentPlant == undefined){
            throw new Error(`There is no ${plantName} in the garden`);
        }
        if (currentPlant.ripe == false){
            throw new Error (`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.storage.push(`${currentPlant.plantName} (${currentPlant.quantity})`);

        this.spaceAvailable += currentPlant.spaceRequired;
        const plantIndex = this.plants.indexOf(currentPlant);
        this.plants.splice(plantIndex, 1);

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport(){
        let information = `The garden has ${this.spaceAvailable} free space left.\n`;
        let allPlants = this.plants.map(x => x.plantName).join(', ');
        information += `Plants in the garden: ${allPlants}\n`;
        if (this.storage.length == 0){
            information += "Plants in storage: The storage is empty.";
        }else{
            information += `Plants in storage: ${this.storage.join(', ')}`;
        }

        return information;
    }
}

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());



