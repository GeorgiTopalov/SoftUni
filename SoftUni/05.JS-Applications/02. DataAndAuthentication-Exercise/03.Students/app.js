function solve() {
    const url = 'http://localhost:3030/jsonstore/collections/students';
    const firstName = document.querySelector('input[name="firstName"]');
    const lastName = document.querySelector('input[name="lastName"]');
    const facultyNumber = document.querySelector('input[name="facultyNumber"]');
    const grade = document.querySelector('input[name="grade"]');

    const tableBody = document.querySelector('#results tbody');

    let allInputs = [firstName, lastName, facultyNumber, grade];

    const submitBtn = document.getElementById('submit').addEventListener('click', addStudentToTable);
    loadStudents();

    async function addStudentToTable(e) {
        e.preventDefault();
        if (!allInputs.some(x => x.value == '')) {
            const resp = await fetch(url, {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ firstName: firstName.value, lastName: lastName.value, facultyNumber: facultyNumber.value, grade: grade.value }),
            });

            allInputs.forEach(x => x.value = '');
        loadStudents();
        }
    }

    function createNewElement(type, text, parent) {
        const element = document.createElement(type);
        element.textContent = text;
        parent.appendChild(element);
    }

    async function loadStudents() {
        tableBody.innerHTML = '';

        const response = await fetch(url);
        const data = await response.json(url);

        Object.values(data).forEach(student => {
            const tr = document.createElement('tr');
            createNewElement('td', `${student.firstName}`, tr);
            createNewElement('td', `${student.lastName}`, tr);
            createNewElement('td', `${student.facultyNumber}`, tr);
            createNewElement('td', `${student.grade}`, tr);

            tableBody.appendChild(tr);
        });
    }
}

solve();