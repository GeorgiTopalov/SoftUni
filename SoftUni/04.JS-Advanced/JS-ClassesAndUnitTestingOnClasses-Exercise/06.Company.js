class Company{
    constructor(){
        this.departments = {};
    }

    addEmployee(name, salary, position, department){
        
        let arrayOfParameters = [name, salary, position];
        if (!Object.keys(this.departments).includes(department)){
            this.departments[department] =[];
        }
        if (arrayOfParameters.includes(x => x == '' || x == null || x == undefined)){
            throw new Error ('Invalid input!');
        }
        if (salary < 0){
            throw new Error ('Invalid input!');
        }

        let newEmployee = {name: name, salary: salary, position: position};
        this.departments[department].push(newEmployee);
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment(){

        let averageSalaries = new Map();
        
        for (const department in this.departments) {
            let currentAvgSalary = 0;
            for (const employee of this.departments[department]) {
                currentAvgSalary += employee.salary;
            }
            averageSalaries.set(department, currentAvgSalary / this.departments[department].length);
        }

        const sortedAvgSalaries = new Map([...averageSalaries.entries()].sort((a,b)=> b[1] - a[1]));

        const [firstKey] = sortedAvgSalaries.keys();
        const [firstValue] = sortedAvgSalaries.values();

        let sortedEmployees = this.departments[firstKey].sort((a,b) => (b.salary - a.salary || a.name.localeCompare(b.name)));

        let finalOutput = [];

        for (const employee of sortedEmployees) {
            let str = '';
            str += `${employee.name} `;
            str += `${employee.salary} `;
            str += `${employee.position}`;

            finalOutput.push(str);
        }

        return `Best Department is: ${firstKey}\nAverage salary: ${firstValue.toFixed(2)}\n${finalOutput.join('\n')}`
    }
}

let c = new Company();
let actual1 = c.addEmployee("Stanimir", 2000, "engineer", "Human resources");

c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");

let act = c.bestDepartment();
console.log(act);
