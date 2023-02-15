const lookupChar = require('./03.CharLookup.js');
const expect = require('chai').expect;

describe('Test if function returns a character from given string', () => {

    it('Should return undefined when first input is not a string', () =>{
        expect(lookupChar(2,2)).to.equal(undefined);
        expect(lookupChar([1,2,3],2)).to.equal(undefined);
        expect(lookupChar(null, 2)).to.equal(undefined);
        expect(lookupChar(undefined, 2)).to.equal(undefined);
    });
    it('Should return undefined when second input is not a number', () =>{
        expect(lookupChar('assd','asd')).to.equal(undefined);
        expect(lookupChar('assd',null)).to.equal(undefined);
        expect(lookupChar('assd',undefined)).to.equal(undefined);
        expect(lookupChar('assd',[1,2,3])).to.equal(undefined);
    });
    it('Should return error message when index is out of range', () =>{
        expect(lookupChar('Hello', -1)).to.equal('Incorrect index');
        expect(lookupChar('Hello', 6)).to.equal('Incorrect index');
    });

    it('Should return undefined when index floating point number', () =>{
        expect(lookupChar('Hello', 1.2)).to.equal(undefined);
    });

     it('Should return the right indexed character from a string on execution', () => {
        expect(lookupChar('Hello', 2)).to.equal('l');
        expect(lookupChar('Hello', 0)).to.equal('H');
        expect(lookupChar('Hello', 4)).to.equal('o');
    }); 

});