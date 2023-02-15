window.addEventListener('DOMContentLoaded', () => {
    const loginForm = document.querySelector('form');
    loginForm.addEventListener('submit', login);
});

async function login(e) {
    e.preventDefault();
    const formData = new FormData(e.target);

    const email = formData.get('email');
    const password = formData.get('password');
try{
   const resp = fetch('http://localhost:3030/users/login', {
        method: 'POST',
        headers: {
            'Content-Type': "application/json"
        },
        body: JSON.stringify({email, password}),
    });

    if(resp.ok != true){
        const error = await resp.json();
        throw new Error(error.message);
    }

    const data = await resp.json();
    const userData ={
        email: data.email,
        id: data._id,
        token: data.accessToken,
    };

    sessionStorage.setItem('userData', JSON.stringify(userData));
    window.location = ('/src/index.html');
} catch (err){
    alert(err.message);
}
}
