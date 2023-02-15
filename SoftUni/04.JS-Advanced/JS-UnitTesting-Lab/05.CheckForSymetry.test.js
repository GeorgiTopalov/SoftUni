const expect = require('chai').expect;
const check = require('./05.CheckForSymerty');

describe('Checks if an array is symetrical', ()=>{

    it('Should return false if parameter input is not an array', ()=>{
        expect(check('asd')).to.be.false;
        expect(check(1)).to.be.false;
        expect(check({a: 3, b: 4})).to.be.false;
    });

    it('Should return false when numbers are same but negative and positive or string and number', ()=>{
        expect(check([1, 2, -1])).to.be.false;
        expect(check([1, 2, '1'])).to.be.false;
    });

    it('Should return false if array is not symetrical but input is correct', ()=>{
        expect(check([1,2,3,4,5,6])).to.be.false;
        expect(check(['a','b','c'])).to.be.false;
    });

    it('Should return true if array of numbers is symetrical', ()=>{
        expect(check([1,1,2,2,1,1])).to.be.true;
        expect(check([1,2,1])).to.be.true;
    });

    it('Should return true if array of strings is symetrical', ()=>{
        expect(check(['a','b','b','a'])).to.be.true;
        expect(check(['a','b','a'])).to.be.true;
    });
    it('Should return true if a mixed array is symetrical', ()=>{

        expect(check(['a','b','b','a'])).to.be.true;
    });
    it('Should return true if a multi-dimentional array is symetrical', ()=>{

        expect(check([['a','b'],['a'],['a','b']])).to.be.true;
    });
    it('Should return true when input is empty array', ()=>{
        expect(check([new Date(2022,6,12), 'asd', new Date(2022,6,12)])).to.be.true;
    });
    it('Should return true when parameter has 1 item', ()=>{
        expect(check([1])).to.be.true;
    });

});