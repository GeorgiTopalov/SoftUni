import { html } from '../../node_modules/lit-html/lit-html.js';
import * as user from '../api/user.js';

const registerTemplate = (onSubmit) => html`
<section id="register">
    <form @submit=${onSubmit} id="register-form">
        <div class="container">
            <h1>Register</h1>
            <label for="username">Username</label>
            <input id="username" type="text" placeholder="Enter Username" name="username">
            <label for="email">Email</label>
            <input id="email" type="text" placeholder="Enter Email" name="email">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <label for="repeatPass">Repeat Password</label>
            <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
            <div class="gender">
                <input type="radio" name="gender" id="female" value="female">
                <label for="female">Female</label>
                <input type="radio" name="gender" id="male" value="male" checked>
                <label for="male">Male</label>
            </div>
            <input type="submit" class="registerbtn button" value="Register">
            <div class="container signin">
                <p>Already have an account?<a href="/login">Sign in</a>.</p>
            </div>
        </div>
    </form>
</section>`

export function registerPage(ctx) {
    const onSubmit = async (e) => {
        e.preventDefault();

        const formData = Object.values(Object.fromEntries(new FormData(e.currentTarget)));
        const userName = formData[0];
        const email = formData[1];
        const password = formData[2];
        const repeatPassword = formData[3];
        let gender;
        const genderCheck = document.getElementsByName('gender');

        if (genderCheck[0].checked){
            gender = 'female';
        }else{
            gender = 'male';
        }


        if (email == '' || password == '' || userName == '') {
            alert('All fields required!');
            return;
        }

        if (password != repeatPassword) {
            alert('Password doesnt match');
            return;
        }
        await user.register(username, email, password, gender);
        ctx.page.redirect('/memes');
    }
    ctx.render(registerTemplate(onSubmit));
}