const isOddOrEven = require('./02.EvenOrOdd');
const expect = require('chai').expect;

describe('Tests if the length of an array of strings is odd or even', ()=>{

    it('Should return even when the parameters length is even', () =>{
        expect(isOddOrEven('George')).to.equal('even');
    });

    it('Should return odd when the parameters length is odd', () =>{
        expect(isOddOrEven('Hello')).to.equal('odd');
    });

    it('Should return odd when the parameters length is one', () =>{
        expect(isOddOrEven('a')).to.equal('odd');
    });

    it('Should return even when the parameters length is 0', () =>{
        expect(isOddOrEven('')).to.equal('even');
    });

    it('Should return undefined when the parameters is not a string', () =>{
        expect(isOddOrEven(2)).to.equal(undefined);
        expect(isOddOrEven([1, 2 ,3])).to.equal(undefined);
        expect(isOddOrEven({a: 2, b: 4})).to.equal(undefined);
    });
    
});