const chooseYourCar = require('./problem.js');
const expect = require('chai').expect;

describe("Tests chooseYourCar", function() {
    describe("choosingType", function() {
        it("Should return message when car is too old", function() {
            expect(chooseYourCar.choosingType('Sedan','blue', 1990)).to.equal(`This Sedan is too old for you, especially with that blue color.`);
        });
        it("Should return message when sedan is new", function() {
            expect(chooseYourCar.choosingType('Sedan','blue', 2020)).to.equal(`This blue Sedan meets the requirements, that you have.`);
            expect(chooseYourCar.choosingType('Sedan','blue', 2010)).to.equal(`This blue Sedan meets the requirements, that you have.`);
        });
        it("Should throw error when year is invalid", function() {
            expect(()=>chooseYourCar.choosingType('Sedan','blue', 1890)).to.throw(`Invalid Year!`);
            expect(()=>chooseYourCar.choosingType('Sedan','blue', 2023)).to.throw(`Invalid Year!`);
            expect(()=>chooseYourCar.choosingType('Sedan','blue', -1980)).to.throw(`Invalid Year!`);
        });
        it("Should throw error when type is not sedan", function() {
            expect(()=>chooseYourCar.choosingType('Coupe','blue', 2000)).to.throw(`This type of car is not what you are looking for.`);
            expect(()=>chooseYourCar.choosingType(20,'blue', 2013)).to.throw(`This type of car is not what you are looking for.`);
        });
     });
     describe("brandName", function() {
        it("Should throw error if input is invalid", function() {
            expect(() => chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], '1')).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.brandName("Toyota", 1)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.brandName(5, 1)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.brandName(undefined, 1)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.brandName(null, 1)).to.throw(`Invalid Information!`);
        });
        it("Should throw error if index is out of bounds", function() {
            expect(() => chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], -1)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 5)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 3)).to.throw(`Invalid Information!`);
            
        });
        it("Should remove the indexed car and return the new array", function() {
            expect(chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 1)).to.equal(`BMW, Peugeot`);
            expect(chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 0)).to.equal(`Toyota, Peugeot`);
        });
     });
     describe("carFuelConsumption", function() {
        it("Should return message if too much consumption", function() {
            expect(chooseYourCar.carFuelConsumption(90, 10)).to.equal(`The car burns too much fuel - 11.11 liters!`);
            
        });
        it("Should throw error when input is invalid", function() {
            expect(() => chooseYourCar.carFuelConsumption('2', 3)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.carFuelConsumption([1, 2, 3], 3)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.carFuelConsumption(1000, '2')).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.carFuelConsumption(null, 20)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.carFuelConsumption(undefined, -20)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.carFuelConsumption(10, {a: 1, b: 2})).to.throw(`Invalid Information!`);
        });
        it("Should throw error when input is zero or bellow", function() {
           
           expect(() => chooseYourCar.carFuelConsumption(-1000, 2)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.carFuelConsumption(1000, 0)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.carFuelConsumption(0, 20)).to.throw(`Invalid Information!`);
            expect(() => chooseYourCar.carFuelConsumption(10, -20)).to.throw(`Invalid Information!`);
          
        });
        it("Should return proper message if space isn't enoughwhen car is efficient", function() {
            expect(chooseYourCar.carFuelConsumption(180, 10)).to.equal(`The car is efficient enough, it burns 5.56 liters/100 km.`);
            expect(chooseYourCar.carFuelConsumption(142.9, 10)).to.equal(`The car is efficient enough, it burns 7.00 liters/100 km.`);
            
        });
     });
});
