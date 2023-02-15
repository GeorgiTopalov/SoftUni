//Improve the HTML - add hrefs for nav bar, add ids or classes to be able to hide and show pages if needed
//create placeholder modules for every view
//create functionality for hiding all pages and showing pages on events
//connect the navigation bar to the show page functionality
//load all movies from the server and add them to catalog
//add login functionality and adjust nav bar when there is a user logged or not
//add register functionality 
//change the welcome, guest input when there's someone logged in and hide it when there isn't anyone
//Add Movie - take the inputs from the form and create two elements - one to the movie list and one for movie description - add event listener to movie list icon
//

import { showHome } from './home.js';
import { showLogin } from './login.js';
import { showRegister } from './register.js';

const views = {
    'home-link': showHome,
    'login-link': showLogin,
    'register-link': showRegister,
}
const nav = document.querySelector('nav');

document.getElementById('logout-btn').addEventListener('click', onLogout);
nav.addEventListener('click', (ev) => {
    const view = views[ev.target.id];
    if (typeof view == 'function') {
        ev.preventDefault();
        view();
    }
});

export function updateNav() {
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    if (userData != null) {
        nav.querySelector('#welcome-msg').textContent = `Welcome, ${userData.email}`;

        [...nav.querySelectorAll('.user')].forEach(e => e.style.display = 'block');
        [...nav.querySelectorAll('.guest')].forEach(e => e.style.display = 'none');
    } else {
        [...nav.querySelectorAll('.user')].forEach(e => e.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(e => e.style.display = 'block');
    }
}

async function onLogout(ev){
    ev.preventDefault();
    ev.stopImmediatePropagation();

    const {token} = JSON.parse(sessionStorage.getItem('userData'));
    
    await fetch ('http://localhost:3030/users/logout',{
        headers:{
            'X-Authorization': token
        }
    })

    sessionStorage.removeItem('userData');
    updateNav();
    showLogin();
}
showHome();
updateNav();

window.showHome = showHome;