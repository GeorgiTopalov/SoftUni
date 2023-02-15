const bookSelection = require('./bookSelection.js');
const expect = require('chai').expect;

describe("Tests bookSelection", () => {
    describe("isGenreSuitable", () => {

        it("Should say genre isn't appropriate when age is 12 or less and genre is Thriller or Horror", () => {
            expect(bookSelection.isGenreSuitable('Thriller', 10)).to.equal(`Books with Thriller genre are not suitable for kids at 10 age`);
            expect(bookSelection.isGenreSuitable('Horror', 12)).to.equal(`Books with Horror genre are not suitable for kids at 12 age`);
        });
        it("Should say genre is appropriate if age is above 12", () => {
            expect(bookSelection.isGenreSuitable('Thriller', 13)).to.equal(`Those books are suitable`);
            expect(bookSelection.isGenreSuitable('Horror', 23)).to.equal(`Those books are suitable`);
        });
        it("Should say genre is appropriate if age is bellow or equal to 12 and genre isn't Thriller or Horror", () => {
            expect(bookSelection.isGenreSuitable('Fantasy', 12)).to.equal(`Those books are suitable`);
            expect(bookSelection.isGenreSuitable('Poems', 10)).to.equal(`Those books are suitable`);
        });
    });
    describe("isItAffordable", () => {

        it("Should throw error when input isn't a number", () => {
            expect(() => bookSelection.isItAffordable('1', 20)).to.throw('Invalid input');
            expect(() => bookSelection.isItAffordable(1, '20')).to.throw('Invalid input');
        });
        it("Should return no money message if budget is less than price", ()=>{
            expect(bookSelection.isItAffordable(20, 10)).to.equal("You don't have enough money");
        });
        it("Should work with valid inputs", ()=>{
            expect(bookSelection.isItAffordable(10, 20)).to.equal(`Book bought. You have 10$ left`);
            expect(bookSelection.isItAffordable(10, 10)).to.equal(`Book bought. You have 0$ left`);
        });
    });
    describe("suitableTitles", () => {

        it("Should throw error if inputs aren't valid", () => {
            expect(() => bookSelection.suitableTitles('1', 'Fantasy')).to.throw('Invalid input');
            expect(() => bookSelection.suitableTitles([{ title: "The Da Vinci Code", genre: "Thriller"}], 123)).to.throw('Invalid input');

        });
        it("Should return array with wantedGenre titles", () => {
            expect(bookSelection.suitableTitles([{ title: "The Da Vinci Code", genre: "Thriller"}], "Thriller")).to.deep.equal(["The Da Vinci Code"]);
            expect(bookSelection.suitableTitles([{ title: "The Da Vinci Code", genre: "Thriller"},{ title: "Some Book", genre: "Thriller"}], "Thriller")).to.deep.equal(["The Da Vinci Code", "Some Book"]);
            expect(bookSelection.suitableTitles([{ title: "The Lord Of The Rings", genre: "Fantasy"}], "Thriller")).to.deep.equal([]);
        });
    });

});


