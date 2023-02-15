const rentCar = require('./rentCar.js');
const expect = require('chai').expect;

describe("Tests rentCar", () =>{
    describe("SearchCar function", ()=> {
        it("Should throw error if input is invalid", ()=> {
            expect(()=> rentCar.searchCar("Audi", "Audi")).to.throw("Invalid input!");
            expect(()=> rentCar.searchCar(["Volkswagen", "BMW", "Audi"], 6)).to.throw("Invalid input!");
        });
        it("Should throw error if input is valid but no model is available", ()=> {
            expect(()=> rentCar.searchCar(["Volkswagen", "BMW", "Audi"], "Moskvich")).to.throw("There are no such models in the catalog!");
        });
        it("Should work with valid inputs", ()=>{
            expect(rentCar.searchCar(["Volkswagen", "BMW", "Audi"], "Audi")).to.equal("There is 1 car of model Audi in the catalog!");
            expect(rentCar.searchCar(["Volkswagen", "BMW", "Audi", "Audi"], "Audi")).to.equal("There is 2 car of model Audi in the catalog!");
        });
     });
      describe("CalculatePriceOfCar Function", ()=> {
        it("Should throw error if input is invalid", () =>{
            expect(()=> rentCar.calculatePriceOfCar(["Audi"], 5)).to.throw("Invalid input!");
            expect(()=> rentCar.calculatePriceOfCar("Audi", 5.5)).to.throw("Invalid input!");
            expect(()=> rentCar.calculatePriceOfCar("Audi", "5")).to.throw("Invalid input!");
        });
        it("Should throw error if input is valid but no model is available", () =>{
            expect(()=> rentCar.calculatePriceOfCar("Moskvich", 5)).to.throw("No such model in the catalog!");
        });
        it("Should work with valid inputs", ()=>{
            expect(rentCar.calculatePriceOfCar("Audi", 5)).to.equal("You choose Audi and it will cost $180!");
            expect(rentCar.calculatePriceOfCar("Toyota", 5)).to.equal("You choose Toyota and it will cost $200!");
        });

     });
     describe("CheckBudget function", ()=> {
        it("Should throw error if input is invalid", () =>{
            expect(()=> rentCar.checkBudget(40, 5, 2.2)).to.throw("Invalid input!");
            expect(()=> rentCar.checkBudget(40.5, 5, 200)).to.throw("Invalid input!");
            expect(()=> rentCar.checkBudget(40, 5.5, 200)).to.throw("Invalid input!");
            expect(()=> rentCar.checkBudget('40', 5, 200)).to.throw("Invalid input!");
            expect(()=> rentCar.checkBudget(40, '5', 200)).to.throw("Invalid input!");
            expect(()=> rentCar.checkBudget(40, 5, '200')).to.throw("Invalid input!");
            expect(()=> rentCar.checkBudget(40, 5, NaN)).to.throw("Invalid input!");
            expect(()=> rentCar.checkBudget(null, 5, 200)).to.throw("Invalid input!");
            expect(()=> rentCar.checkBudget(undefined, 5, 200)).to.throw("Invalid input!");
        });
        it("Should return message if budget isn't enough", () =>{
            expect(rentCar.checkBudget(40, 5, 150)).to.equal("You need a bigger budget!");
            expect(rentCar.checkBudget(40, 5, 0)).to.equal("You need a bigger budget!");
            expect(rentCar.checkBudget(40, 5, -150)).to.equal("You need a bigger budget!");
        });
        it("Should return succesfull purchase message if budget is enough", () =>{
            expect(rentCar.checkBudget(40, 5, 200)).to.equal("You rent a car!");
            expect(rentCar.checkBudget(40, 5, 250)).to.equal("You rent a car!");
            expect(rentCar.checkBudget(0, 5, 250)).to.equal("You rent a car!");
            expect(rentCar.checkBudget(50, 0, 250)).to.equal("You rent a car!");
        });
     }); 
});

