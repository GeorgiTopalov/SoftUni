import { html } from '../../node_modules/lit-html/lit-html.js';
import * as user from '../api/user.js';

const registerTemplate = (onSubmit) => html`
<section id="registerPage">
    <form @submit=${onSubmit} class="registerForm">
        <img src="./images/logo.png" alt="logo" />
        <h2>Register</h2>
        <div class="on-dark">
            <label for="email">Email:</label>
            <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
        </div>

        <div class="on-dark">
            <label for="password">Password:</label>
            <input id="password" name="password" type="password" placeholder="********" value="">
        </div>

        <div class="on-dark">
            <label for="repeatPassword">Repeat Password:</label>
            <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
        </div>

        <button class="btn" type="submit">Register</button>

        <p class="field">
            <span>If you have profile click <a href="/login">here</a></span>
        </p>
    </form>
</section>`

export function registerPage(ctx) {
const onSubmit = async (e) => {
e.preventDefault();

const formData = Object.values(Object.fromEntries(new FormData(e.currentTarget)));
const email = formData[0];
const password = formData[1];
const repeatPassword = formData[2];



if (email == '' || password == '') {
alert('All fields required!');
return;
}

if (password != repeatPassword) {
alert('Password doesnt match');
return;
}
await user.register(email, password);
ctx.page.redirect('/dashboard');
}
ctx.render(registerTemplate(onSubmit));
}