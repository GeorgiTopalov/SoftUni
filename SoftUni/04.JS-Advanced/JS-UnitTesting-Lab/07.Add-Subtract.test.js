const expect = require('chai').expect;
const createCalculator = require('./07.Add-Subtract');

describe('Testing for createCalculator function', () => {
    let calc;

    beforeEach(function () {
        calc = createCalculator();
    });

    it('Initial value should be 0', () => {
        let value = calc.get();
        expect(value).to.equal(0);
    });

    it('Should add numbers with the add prop and keep value in closure', () => {
        calc.add(2);
        calc.add(3);
        let value = calc.get();
        expect(value).to.equal(5);
    });

    it('Should subtract numbers with the subtract prop and keep value in closure', () => {
        calc.subtract(2);
        calc.subtract(3);
        let value = calc.get();
        expect(value).to.equal(-5);
    });

    it('Should work with strings as parameter if they can be parsed to numbers', () => {
        calc.subtract(2);
        calc.subtract('3');
        let value = calc.get();
        expect(value).to.equal(-5);
    });

    it('Should work with floating numbers as parameter if they can be parsed to numbers', () => {
        calc.add(6.7)
        calc.subtract(2.2);
        calc.subtract(3.5);
        let value = calc.get();
        expect(value).to.equal(1);
    });

    it('Should be able to use both add and subtract', () => {
        calc.add(2);
        calc.subtract(3);
        let value = calc.get();
        expect(value).to.equal(-1);
    });

    it('Should return NaN with get function if parameter is not a number or can not be parsed', () => {
        calc.add('asd');
        let value = calc.get();
        expect(value).to.be.NaN;
        calc.subtract('asd');
        expect(value).to.be.NaN;

    });

});