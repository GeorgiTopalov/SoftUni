import { showHome } from './home.js';
import { showView } from './utils.js';
import { updateNav } from './app.js';

const section = document.getElementById('form-sign-up');
const form = section.querySelector('form');
form.addEventListener('submit', onRegister);

section.remove();

export function showRegister(){
    showView(section);
}


async function onRegister(ev){
    ev.preventDefault();
    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();
    const repeatPassword = formData.get('repeatPassword').trim();
    
    if (email == '' || password == '') {
        return alert('All fields are required!');
    }
    if (password != repeatPassword){
        return ('Password input does not match!');
    }
    
    try{
        const res = await fetch('http://localhost:3030/users/login',{
            method: 'POST',
            headers:{
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({email, password})
        });

        if (res.ok == false){
            const error = await res.json();
            throw new Error (error.message);
        }

        const data = await res.json();
        sessionStorage.setItem('userData', JSON.stringify({
            email: data.email,
            id: data._id,
            token: data.accessToken
        }));
        form.reset();
        showHome();
        updateNav();
    }catch(err){
        alert(err.message);
    }
}