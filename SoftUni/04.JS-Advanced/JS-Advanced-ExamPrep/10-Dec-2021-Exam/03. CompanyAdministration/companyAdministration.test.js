const companyAdministration = require('./companyAdministration.js');
const expect = require('chai').expect;

describe("Test companyAdministration", () =>{
    describe("hiringEmployee function", ()=> {
        it("Should throw error if position isn't Programmer", () =>{
            expect(()=> companyAdministration.hiringEmployee("Pesho","Plumber",4)).to.throw(`We are not looking for workers for this position.`);
        });
        it("Should approve if experience is 3 years or more", () =>{
            expect(companyAdministration.hiringEmployee("Pesho","Programmer",3)).to.equal(`Pesho was successfully hired for the position Programmer.`);
            expect(companyAdministration.hiringEmployee("Pesho","Programmer",5)).to.equal(`Pesho was successfully hired for the position Programmer.`);
        });
        it("Should approve if experience is less than 3 years", () =>{
            expect(companyAdministration.hiringEmployee("Pesho","Programmer",2)).to.equal(`Pesho is not approved for this position.`);
            expect(companyAdministration.hiringEmployee("Pesho","Programmer",0)).to.equal(`Pesho is not approved for this position.`);
        });
     });
     describe("calculateSalary function", ()=> {
        it("Should throw error if input is invalid", () =>{
            expect(()=> companyAdministration.calculateSalary("4")).to.throw(`Invalid hours`);
            expect(()=> companyAdministration.calculateSalary(null)).to.throw(`Invalid hours`);
            expect(()=> companyAdministration.calculateSalary(undefined)).to.throw(`Invalid hours`);
            expect(()=> companyAdministration.calculateSalary([4])).to.throw(`Invalid hours`);
            expect(()=> companyAdministration.calculateSalary({a: 4})).to.throw(`Invalid hours`);
            expect(()=> companyAdministration.calculateSalary(-1)).to.throw(`Invalid hours`);
        });
        it("Should calculate salary when function is called", () =>{
            expect(companyAdministration.calculateSalary(4)).to.equal(60);
            expect(companyAdministration.calculateSalary(4.2)).to.equal(63);
            expect(companyAdministration.calculateSalary(160)).to.equal(2400);
        });
        it("Should give bonus 1000BGN if hours is more than 160", () =>{
            expect(companyAdministration.calculateSalary(165)).to.equal(3475);

        });
        it("Should calculate salary when input is 0", () =>{
            expect(companyAdministration.calculateSalary(0)).to.equal(0);
        });
     });

     describe("firedEmployee function", ()=> {
        it("Should throw error if employees input is invalid", () =>{
            expect(()=> companyAdministration.firedEmployee("Gosho", 2)).to.throw(`Invalid input`);
            expect(()=> companyAdministration.firedEmployee(undefined, 1)).to.throw(`Invalid input`);
            expect(()=> companyAdministration.firedEmployee(2, 1)).to.throw(`Invalid input`);
        });
        it("Should throw error if index input is invalid", () =>{
            expect(()=> companyAdministration.firedEmployee("Gosho", 2)).to.throw(`Invalid input`);
            expect(()=> companyAdministration.firedEmployee("Gosho", 2.5)).to.throw(`Invalid input`);
            expect(()=> companyAdministration.firedEmployee([], 0)).to.throw(`Invalid input`);
            expect(()=> companyAdministration.firedEmployee(["Gosho", "Pesho"], "2")).to.throw(`Invalid input`);
            expect(()=> companyAdministration.firedEmployee(["Gosho", "Pesho"], -2)).to.throw(`Invalid input`);
            expect(()=> companyAdministration.firedEmployee(["Gosho", "Pesho"], 3)).to.throw(`Invalid input`);
            expect(()=> companyAdministration.firedEmployee(["Gosho", "Pesho"], 2)).to.throw(`Invalid input`);
            expect(()=> companyAdministration.firedEmployee(["Gosho", "Pesho"], 2.5)).to.throw(`Invalid input`);
        });
        it("Should return array with the eployees left", () =>{
            expect(companyAdministration.firedEmployee(["Gosho"], 0)).to.equal('');
            expect(companyAdministration.firedEmployee(["Gosho", "Pesho"], 0)).to.equal("Pesho");
            expect(companyAdministration.firedEmployee(["Gosho", "Tosho", "Pesho", "Ivan"], 1)).to.equal("Gosho, Pesho, Ivan");
        });
        
     });
});
