function solve() {
    let hireButton = document.getElementById('add-worker');
    let firstNameElement = document.getElementById('fname');
    let lastNameElement = document.getElementById('lname');
    let emailElement = document.getElementById('email');
    let birthDateElement = document.getElementById('birth');
    let positionElement = document.getElementById('position');
    let salaryElement = document.getElementById('salary');
    let salarySum = document.getElementById('sum');
    let tableBodyElement = document.getElementById('tbody');

    let allInputs = [firstNameElement, lastNameElement, emailElement, birthDateElement, positionElement, salaryElement];

    hireButton.addEventListener('click', (e) => {
        e.preventDefault();
        
        for (const input of allInputs) {
            if (input.value == '') {
                return;
            }
        }

        let trElement = document.createElement('tr');
        let editContent = []

        for (const input of allInputs) {
            let newTd = document.createElement('td')
            editContent.push(input.value);
            newTd.textContent = input.value;
            trElement.appendChild(newTd);
        }

        let buttonsTd = document.createElement('td');
        let firedBtn = document.createElement('button');
        let editBtn = document.createElement('button');

        firedBtn.classList = 'fired';
        firedBtn.textContent = 'Fired';
        editBtn.classList = 'edit';
        editBtn.textContent = 'Edit';

        buttonsTd.appendChild(firedBtn);
        buttonsTd.appendChild(editBtn);
        trElement.appendChild(buttonsTd);

        tableBodyElement.appendChild(trElement);

        

        let currentSalary = (Number(salarySum.textContent) + Number(allInputs[5].value)).toFixed(2);
        salarySum.textContent = currentSalary;

        for (const input of allInputs) {
            input.value = '';
        }


        editBtn.addEventListener('click', (e)=>{

            for (let i = 0; i< allInputs.length; i++) {
                allInputs[i].value = editContent[i];
            }

            currentSalary =(Number(salarySum.textContent) - Number(editContent[5])).toFixed(2);
            salarySum.textContent = currentSalary;
            e.target.parentNode.parentNode.remove();
        });
        firedBtn.addEventListener('click', (e)=>{
            currentSalary =(Number(salarySum.textContent) - Number(editContent[5])).toFixed(2);
            salarySum.textContent = currentSalary;
            e.target.parentNode.parentNode.remove();
        });


    });
}
solve()