const expect = require('chai').expect;
const rgbToHexColor = require('./06.RGBtoHex');

describe('RGB to hexColor convertion', () => {
    it('Should return undefined if parameters values are less than 0', () => {
        expect(rgbToHexColor(-1, 10, 15)).to.equal(undefined);
        expect(rgbToHexColor(10, -10, 15)).to.equal(undefined);
        expect(rgbToHexColor(1, 10, -15)).to.equal(undefined);
        expect(rgbToHexColor(360, 10, 15)).to.equal(undefined);
        expect(rgbToHexColor(1, 360, 15)).to.equal(undefined);
        expect(rgbToHexColor(1, 77, 256)).to.equal(undefined);
        
    });

    it('Should return undefined if parameters values are higher than 255', () => {
        expect(rgbToHexColor(360, 10, 15)).to.equal(undefined);
        expect(rgbToHexColor(1, 360, 15)).to.equal(undefined);
        expect(rgbToHexColor(1, 77, 256)).to.equal(undefined);
    });
    
    it('Should return undefined if parameters are not a number',() =>{
        expect(rgbToHexColor('a', 77, 250)).to.equal(undefined);
        expect(rgbToHexColor(1, 'a', 251)).to.equal(undefined);
        expect(rgbToHexColor(1, 77, 'a')).to.equal(undefined);
        expect(rgbToHexColor(1, 77, [1, 2, 3])).to.equal(undefined);
        expect(rgbToHexColor(1, [1, 2, 3], 150)).to.equal(undefined);
        expect(rgbToHexColor([1, 2, 3], 77, 100)).to.equal(undefined);
    });
    
    it('Should return color in hexadecimal format as a string', ()=>{
        expect(rgbToHexColor(10, 10, 15)).to.equal('#0A0A0F');
    });
    it('Should return color in hexadecimal format as a string when parameters are 0', ()=>{
        expect(rgbToHexColor(0, 10, 15)).to.equal('#000A0F');
        expect(rgbToHexColor(10, 0, 15)).to.equal('#0A000F');
        expect(rgbToHexColor(10, 15, 0)).to.equal('#0A0F00');
    });
    it('Should return color in hexadecimal format as a string when parameters value is 255', ()=>{
        expect(rgbToHexColor(0, 10, 255)).to.equal('#000AFF');
        expect(rgbToHexColor(10, 255, 15)).to.equal('#0AFF0F');
        expect(rgbToHexColor(255, 15, 0)).to.equal('#FF0F00');
    });
});