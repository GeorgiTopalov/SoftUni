const carService = require('./03.CarService.js');
const {expect} = require('chai');
const {assert} = require('chai');

describe("Tests CarService", () =>{
    describe("Test isItExpensive ", () => {


        it("Should return higher cost message when input is Engine or Transmission", () => {
            expect(carService.isItExpensive('Engine')).to.equal(`The issue with the car is more severe and it will cost more money`);
            expect(carService.isItExpensive('Transmission')).to.equal(`The issue with the car is more severe and it will cost more money`);
        });

        it("Should return lower cost message when input is not Engine or Transmission", () => {
            expect(carService.isItExpensive('Anything')).to.equal(`The overall price will be a bit cheaper`);
            expect(carService.isItExpensive('part')).to.equal(`The overall price will be a bit cheaper`);
        });
    });

    describe("Test discount", () =>{
        it("Should throw error if input is not valid", () =>{
            expect(() =>carService.discount("3",20).to.equal(`Invalid input`));
            expect(() =>carService.discount(3,"20").to.equal(`Invalid input`));
            expect(() =>carService.discount("3","20").to.equal(`Invalid input`));
            expect(() =>carService.discount(NaN, 20).to.equal(`Invalid input`));
            expect(() =>carService.discount(null, 20).to.equal(`Invalid input`));
            expect(() =>carService.discount(undefined, 20).to.equal(`Invalid input`));
            expect(() =>carService.discount({a: 2, b: 3}, 20).to.equal(`Invalid input`));
        });
        it("Should not give discount if parts are 2 or less", () =>{
            assert.equal(carService.discount(1, 20),`You cannot apply a discount`);
            assert.equal(carService.discount(2, 20),`You cannot apply a discount`);
        });
        it("Should give 15% discount if items are between 3 and 7", ()=>{
            assert.equal(carService.discount(3, 20),`Discount applied! You saved 3$`);
            assert.equal(carService.discount(6, 20),`Discount applied! You saved 3$`);
            assert.equal(carService.discount(7, 20),`Discount applied! You saved 3$`);
        });
        it("Should give 30% discount if items are more than 7", ()=>{
            assert.equal(carService.discount(8, 20),`Discount applied! You saved 6$`);
            assert.equal(carService.discount(100, 20),`Discount applied! You saved 6$`);
        });
    });

    describe("Test partsToBuy", ()=>{
        it("Should throw error if input is not an array", ()=>{
            expect(()=> carService.partsToBuy("test", ["blowoff valve"]).to.throw(`Invalid input`));
            expect(()=> carService.partsToBuy({}, ["blowoff valve"]).to.throw(`Invalid input`));
            expect(()=> carService.partsToBuy(3, ["blowoff valve"]).to.throw(`Invalid input`));
            expect(()=> carService.partsToBuy(undefined, ["blowoff valve"]).to.throw(`Invalid input`));
            expect(()=> carService.partsToBuy(null, ["blowoff valve"]).to.throw(`Invalid input`));
            expect(()=> carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 } ], 3).to.throw(`Invalid input`));
            expect(()=> carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 } ], {}).to.throw(`Invalid input`));
            expect(()=> carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 } ], null).to.throw(`Invalid input`));
            expect(()=> carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 } ], undefined).to.throw(`Invalid input`));
            expect(()=> carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 } ], "undefined").to.throw(`Invalid input`));
        });

        it("Should return 0 if neededParts is empty", ()=> {
            expect(carService.partsToBuy([{part: "blowoff", price: 100}],[])).to.equal(0);
        });

        it("Should return 0 if partsCatalog is empty", ()=> {
            expect(carService.partsToBuy([],["blowoff"])).to.equal(0);
        });

        it("Should return the right price calculated for all parts needed", ()=>{
        
            expect(()=> carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 } ], ["blowoff valve"]).to.equal(`145`));
            expect(()=> carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 } ], ["blowoff valve", "coil springs"]).to.equal(`375`));
            expect(()=> carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 } ], ["blowoff valve", "injectors"]).to.equal(`145`));
            
        });

    });

});
