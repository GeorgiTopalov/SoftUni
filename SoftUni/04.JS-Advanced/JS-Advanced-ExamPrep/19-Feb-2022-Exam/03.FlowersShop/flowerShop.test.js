const flowerShop = require('./flowerShop.js');
const expect = require('chai').expect;

describe("Tests flowerShop", () => {
    describe("calcPriceOfFlowers function", () => {
        it("Should calculate price according to quantity and price inputs", () => {
            expect(flowerShop.calcPriceOfFlowers("rose", 2, 9)).to.equal("You need $18.00 to buy rose!");
        });
        it("Should throw error when any inputs are invalid", () => {
            expect(() => flowerShop.calcPriceOfFlowers('rose', 2.2, 9)).to.throw("Invalid input!");
            expect(() => flowerShop.calcPriceOfFlowers(5, 2, 9)).to.throw("Invalid input!");
            expect(() => flowerShop.calcPriceOfFlowers('rose', 2, '9')).to.throw("Invalid input!");
        });
    });
    describe("checkFlowersAvailable function", () => {
        it("Should return message for available flower if flower is in the input array", () => {
            expect(flowerShop.checkFlowersAvailable("Rose",["Rose", "Lily", "Orchid"])).to.equal("The Rose are available!");
        });
        it("Should return message for unavailable flower if there are none of the type", () => {
            expect(flowerShop.checkFlowersAvailable("Weed",["Rose", "Lily", "Orchid"])).to.equal("The Weed are sold! You need to purchase more!");
        });
    });

    describe("sellFlowers function", () => {
        it("Should remove the given flower at index input and return the array as a string", () => {
            expect(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 2)).to.equal("Rose / Lily");
            expect(flowerShop.sellFlowers(["Rose"], 0)).to.equal("");
            expect(flowerShop.sellFlowers(["Rose", "Lily"], 0)).to.equal("Lily");
        });
        it("Should throw error when any inputs are invalid", () => {
            expect(()=> flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 2.2)).to.throw("Invalid input!");
            expect(()=> flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], -1)).to.throw("Invalid input!");
            expect(()=> flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 4)).to.throw("Invalid input!");
            expect(()=> flowerShop.sellFlowers("Rose", 0)).to.throw("Invalid input!");
        });
    });
});
