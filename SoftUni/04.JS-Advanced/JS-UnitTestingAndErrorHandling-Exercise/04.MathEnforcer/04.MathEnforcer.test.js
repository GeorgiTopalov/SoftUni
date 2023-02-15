const mathEnforcer = require('./04.MathEnforcer.js');
const expect = require('chai').expect;

describe('Test if function returns a character from given string', () => {

    it('Should return a number with value of plus 5 when addFive function is called', () => {
        expect(mathEnforcer.addFive(5)).to.equal(10);
        expect(mathEnforcer.addFive(0)).to.equal(5);
        expect(mathEnforcer.addFive(-5)).to.equal(0);
    });
    if ('Should return zero when both inputs are zero for add function', ()=>{
        expect(mathEnforcer.sum(0, 0)).to.equal(0);
    });

    it('Should return a number with value of minus 10 when subtractTen function is called', () => {
        expect(mathEnforcer.subtractTen(5)).to.equal(-5);
        expect(mathEnforcer.subtractTen(0)).to.equal(-10);
        expect(mathEnforcer.subtractTen(15)).to.equal(5);
        expect(mathEnforcer.subtractTen(-15)).to.equal(-25);
    });

    it('Should return the sum of the two parameters when sum function is called', () => {
        expect(mathEnforcer.sum(5, 5)).to.equal(10);
        expect(mathEnforcer.sum(0, 5)).to.equal(5);
        expect(mathEnforcer.sum(5, 0)).to.equal(5);
    });

    it('Should work when sum function parameter is floating point number', () => {
        expect(mathEnforcer.sum(1.5, 5)).to.be.closeTo(6.5,0.1);
        expect(mathEnforcer.sum(5, 1.5)).to.be.closeTo(6.5,0.1);
        expect(mathEnforcer.sum(-1.5, 5)).to.be.closeTo(3.5,0.1);
    });

    it('Should work when addFive function parameter is floating point number', () => {
        expect(mathEnforcer.addFive(1.5)).to.be.closeTo(6.5,0.1);
        expect(mathEnforcer.addFive(-1.5)).to.be.closeTo(3.5,0.1);
    });

    it('Should work when subtractTen function parameter is floating point number', () => {
        expect(mathEnforcer.subtractTen(1.5)).to.be.closeTo(-8.5,0.1);
        expect(mathEnforcer.subtractTen(-1.5)).to.be.closeTo(-11.5,0.1);
        expect(mathEnforcer.subtractTen(10.5)).to.be.closeTo(0.5,0.1);
    });

    // negative tests

    it('Should return undefined when addFive function takes a parameter that isnt a number', () => {
        expect(mathEnforcer.addFive('1')).to.equal(undefined);
        expect(mathEnforcer.addFive(null)).to.equal(undefined);
        expect(mathEnforcer.addFive([1, 2, 3, 4])).to.equal(undefined);
        expect(mathEnforcer.addFive(undefined)).to.equal(undefined);
        expect(mathEnforcer.addFive({ a: 2, b: 3 })).to.equal(undefined);
    });

    it('Should return undefined when subtractTen function takes a parameter that isnt a number', () => {
        expect(mathEnforcer.subtractTen('1')).to.equal(undefined);
        expect(mathEnforcer.subtractTen(null)).to.equal(undefined);
        expect(mathEnforcer.subtractTen([1, 2, 3, 4])).to.equal(undefined);
        expect(mathEnforcer.subtractTen(undefined)).to.equal(undefined);
        expect(mathEnforcer.subtractTen({ a: 2, b: 3 })).to.equal(undefined);
    });

    it('Should return undefined when sum function takes a parameter that isnt a number', () => {
        expect(mathEnforcer.sum('1', 2)).to.equal(undefined);
        expect(mathEnforcer.sum(null, 2)).to.equal(undefined);
        expect(mathEnforcer.sum([1, 2, 3, 4], 2)).to.equal(undefined);
        expect(mathEnforcer.sum(undefined, 2)).to.equal(undefined);
        expect(mathEnforcer.sum({ a: 2, b: 3 }, 2)).to.equal(undefined);
        expect(mathEnforcer.sum(2, '2')).to.equal(undefined);
        expect(mathEnforcer.sum(2, null)).to.equal(undefined);
        expect(mathEnforcer.sum(2, [1, 2, 3, 4])).to.equal(undefined);
        expect(mathEnforcer.sum(2, { a: 2, b: 3 })).to.equal(undefined);

    });
});