const expect = require('chai').expect;
const sum = require('./04.SumOfNumbers');

describe('Sum Of Nums', () =>{
    it('Should calculate tehe sum of all numbers in the array', () =>{
        let array = [1, 2, 3, 4, 5];
        let expectedSum = 15;

        let arraySum = sum(array);
        expect(expectedSum).to.equal(arraySum);
    
    });
});


