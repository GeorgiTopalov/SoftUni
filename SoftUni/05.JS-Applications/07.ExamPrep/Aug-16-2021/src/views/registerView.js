import { html } from '../../node_modules/lit-html/lit-html.js';
import * as user from '../api/user.js';

const registerTemplate = (onSubmit) => html`
<section id="register-page" class="content auth">
    <form @submit=${onSubmit} id="register">
        <div class="container">
            <div class="brand-logo"></div>
            <h1>Register</h1>

            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="maria@email.com">

            <label for="pass">Password:</label>
            <input type="password" name="password" id="register-password">

            <label for="con-pass">Confirm Password:</label>
            <input type="password" name="confirm-password" id="confirm-password">

            <input class="btn submit" type="submit" value="Register">

            <p class="field">
                <span>If you already have profile click <a href="/login">here</a></span>
            </p>
        </div>
    </form>
</section>
`;

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
        ctx.page.redirect('/');
    }
    ctx.render(registerTemplate(onSubmit));
}