const library = require('./library.js');
const expect = require('chai').expect;

describe("Tests Library", function() {
    describe("calcPriceOfBook", function() {
        it("Should return correct price", function() {
            expect(library.calcPriceOfBook('Some Book', 1999)).to.equal(`Price of Some Book is 20.00`);
        });
        it("Should return price with discount when year is 1980 or below", function() {
            expect(library.calcPriceOfBook('Some Book', 1980)).to.equal(`Price of Some Book is 10.00`);
            expect(library.calcPriceOfBook('Some Book', 1880)).to.equal(`Price of Some Book is 10.00`);
        });
        it("Should throw error when input is invalid", function() {
            expect(()=>library.calcPriceOfBook(20, 1980)).to.throw(`Invalid input`);
            expect(()=>library.calcPriceOfBook('20', 1980.5)).to.throw(`Invalid input`);
            expect(()=>library.calcPriceOfBook(undefined, 1980)).to.throw(`Invalid input`);
            expect(()=>library.calcPriceOfBook('20', '1980')).to.throw(`Invalid input`);
        });
     });
     describe("findBook", function() {
        it("Should find book in a given array", function() {
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Troy')).to.equal(`We found the book you want.`);
        });
        it("Should throw error if array input is empty", function() {
            expect(() => library.findBook([]), 'Troy').to.throw(`No books currently available`);
        });
        it("Should return message if book is not found", function() {
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Code Complete 2nd Edition')).to.equal(`The book you are looking for is not here!`);
        });
     });
     describe("arrangeTheBooks", function() {
        it("Should return message if book count is within bounds", function() {
            expect(library.arrangeTheBooks(40)).to.equal(`Great job, the books are arranged.`);
            expect(library.arrangeTheBooks(0)).to.equal(`Great job, the books are arranged.`);
            expect(library.arrangeTheBooks(10)).to.equal(`Great job, the books are arranged.`);
        });
        it("Should throw error when input is invalid", function() {
            expect(() => library.arrangeTheBooks(-1)).to.throw(`Invalid input`);
            expect(() => library.arrangeTheBooks('1')).to.throw(`Invalid input`);
            expect(() => library.arrangeTheBooks(4.5)).to.throw(`Invalid input`);
        });
        it("Should return proper message if space isn't enough", function() {
            expect(library.arrangeTheBooks(41)).to.equal(`Insufficient space, more shelves need to be purchased.`);
        });
     });
     
});
