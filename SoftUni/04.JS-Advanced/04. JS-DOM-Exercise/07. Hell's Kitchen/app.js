function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let inputElements = JSON.parse(document.querySelector('#inputs textarea').value);
      let bestRestaurant = '';
      let bestAverageSalary = 0;
      let bestSalary = 0;
      let restaurants = {};

      for (let restaurant of inputElements) {
         let restaurantArgs = restaurant.split(' - ');
         let restaurantName = restaurantArgs[0];
         let restaurantEmployees = restaurantArgs[1].split(', ');

         for (let employee of restaurantEmployees) {
            let employeeInfo = employee.split(' ');
            let employeeName = employeeInfo[0];
            let employeeSalary = employeeInfo[1];

            if (!restaurants.hasOwnProperty(restaurantName)) {
               restaurants[restaurantName] = {};
            }
            restaurants[restaurantName][employeeName] = Number(employeeSalary);
         }
      }

      for (let [restaurant, employees] of Object.entries(restaurants)) {


         let totalSalary = 0;
         let employeeCount = 0;
         let currentBestSalary = 0;

         for (let [name, salary] of Object.entries(employees)) {
            totalSalary += salary;
            employeeCount++;

            if (salary > currentBestSalary) {
               currentBestSalary = salary;
            }
         }

         let currentAverageSalary = totalSalary / employeeCount;

         if (currentAverageSalary > bestAverageSalary) {
            bestAverageSalary = currentAverageSalary.toFixed(2);
            bestSalary = currentBestSalary.toFixed(2);
            bestRestaurant = restaurant;
         }
      }


      let outputRestaurant = document.querySelector('#bestRestaurant p');
      outputRestaurant.textContent = `Name: ${bestRestaurant} Average Salary: ${bestAverageSalary} Best Salary: ${bestSalary}`;

      let outputEmployees = document.querySelector('#workers p');



      for (let [key, value] of Object.entries(restaurants[bestRestaurant]).sort((a, b) =>  b[1] - a[1] )) {
         outputEmployees.textContent += `Name: ${key} With Salary: ${value} `;
      }
   }
}