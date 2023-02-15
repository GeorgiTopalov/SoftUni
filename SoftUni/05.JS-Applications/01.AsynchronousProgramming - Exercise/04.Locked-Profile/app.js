 async function lockedProfile() {
    const mainDiv = document.getElementById('main');
    mainDiv.innerHTML = '';

    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    const response = await fetch(url);
    const data = await response.json();
    let currentUser = 1;

    Object.values(data).forEach(p => {
        createProfile(p);
        currentUser++;
    });

    function createProfile(profileInfo) {

        const profileDiv = document.createElement('div');
        profileDiv.classList = 'profile';

        const img = document.createElement('img');
        img.src = './iconProfile2.png';
        img.classList = 'userIcon';

        const lock = document.createElement('label');
        lock.textContent = 'Lock';
        const radio = document.createElement('input');
        radio.setAttribute('type', 'radio');
        radio.setAttribute('name', `user${currentUser}Locked`);
        radio.setAttribute('value', 'lock');
        radio.setAttribute('checked', '');

        const unlock = document.createElement('label');
        unlock.textContent = 'Unlock';
        const radio2 = document.createElement('input');
        radio2.setAttribute('type', 'radio');
        radio2.setAttribute('name', `user${currentUser}Locked`);
        radio2.setAttribute('value', 'unlock');

        const br = document.createElement('br');
        const hr1 = document.createElement('hr');

        const username = document.createElement('label');
        username.textContent = 'Username'

        const usernameInput = document.createElement('input');
        usernameInput.setAttribute('type', 'text');
        usernameInput.setAttribute('name', `user${currentUser}Username`);
        usernameInput.value = `${profileInfo.username}`;
        usernameInput.setAttribute('disabled', '');
        usernameInput.setAttribute('readonly', '');

        const hiddenDiv = document.createElement('div');
        hiddenDiv.id = `user${currentUser}HiddenFields`;
        hiddenDiv.style.display = 'none';
        const hr2 = document.createElement('hr');
        const email = document.createElement('label');

        email.textContent = 'Email:';
        const emailInput = document.createElement('input');
        emailInput.type = 'email';
        emailInput.name = `user${currentUser}Email`;
        emailInput.value = `${profileInfo.email}`;
        emailInput.setAttribute('disabled', '');
        emailInput.setAttribute('readonly', '');

        const age = document.createElement('label');
        age.textContent = 'Age:';
        const ageInput = document.createElement('input');
        ageInput.type = 'age';
        ageInput.name = `user${currentUser}Age`;
        ageInput.value = `${profileInfo.age}`;
        ageInput.setAttribute('disabled', '');
        ageInput.setAttribute('readonly', '');

        const showMoreBtn = document.createElement('button');
        showMoreBtn.textContent = 'Show more';

        showMoreBtn.addEventListener('click', (e) => {
            let unlocked = e.target.parentNode.querySelector('input[value="lock"]')

            if (unlocked.checked == true){
                if (e.target.textContent === 'Show more') {
                    e.target.previousSibling.style.display = 'block';
                    e.target.textContent = 'Hide it';
                } else {
                    e.target.previousSibling.style.display = 'none';
                    e.target.textContent = 'Show more';
                }
            }
        });

        hiddenDiv.appendChild(hr2);
        hiddenDiv.appendChild(email);
        hiddenDiv.appendChild(emailInput);
        hiddenDiv.appendChild(age);
        hiddenDiv.appendChild(ageInput);

        profileDiv.appendChild(img);
        profileDiv.appendChild(lock);
        profileDiv.appendChild(radio);
        profileDiv.appendChild(unlock);
        profileDiv.appendChild(radio2);
        profileDiv.appendChild(br);
        profileDiv.appendChild(hr1);
        profileDiv.appendChild(username);
        profileDiv.appendChild(usernameInput);
        profileDiv.appendChild(hiddenDiv);
        profileDiv.appendChild(showMoreBtn);

        mainDiv.appendChild(profileDiv);
        
    }


}

