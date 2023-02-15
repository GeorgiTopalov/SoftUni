function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/phonebook';
    const phoneBook = document.getElementById('phonebook');

    const loadBtn = document.getElementById('btnLoad').addEventListener('click', loadAllContacts);
    const createBtn = document.getElementById('btnCreate').addEventListener('click', createContact);

    const person = document.getElementById('person');
    const phone = document.getElementById('phone');


    async function loadAllContacts() {

        phoneBook.innerHTML = '';

        const resp = await fetch(url);
        const data = await resp.json();

        Object.values(data).forEach(x => {
            const li = document.createElement('li');
            li.textContent = `${x.person}: ${x.phone}`
            li.id = x._id;

            const deleteBtn = document.createElement('button');
            deleteBtn.addEventListener('click', deletePhone);
            deleteBtn.textContent = 'Delete';
            deleteBtn.id = 'btnDelete';


            li.appendChild(deleteBtn);
            phoneBook.appendChild(li);


        });
    }

    async function createContact() {

        if (person.value !== '' && phone.value !== '') {
            const resp = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ person: person.value, phone: phone.value }),
            });

            loadAllContacts();
            phone.value = '';
            person.value = '';
        }

    }

    async function deletePhone(e) {
        const id = e.target.parentNode.id;
        console.log(id);
      //  e.target.parentNode.remove();

       // const deleteUrl = `http://localhost:3030/jsonstore/phonebook/${id}`;

        /* const resp = await fetch(deleteUrl, {
            method: "DELETE",
        }); */
    }

}

attachEvents();