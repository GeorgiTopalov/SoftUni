import { html } from '../../node_modules/lit-html/lit-html.js';
import * as user from '../api/user.js';

const registerTemplate = (onSubmit) => html`
<section id="register-page" class="auth">
    <form @submit=${onSubmit} id="register">
        <h1 class="title">Register</h1>

        <article class="input-group">
            <label for="register-email">Email: </label>
            <input type="email" id="register-email" name="email">
        </article>

        <article class="input-group">
            <label for="register-password">Password: </label>
            <input type="password" id="register-password" name="password">
        </article>

        <article class="input-group">
            <label for="repeat-password">Repeat Password: </label>
            <input type="password" id="repeat-password" name="repeatPassword">
        </article>

        <input type="submit" class="btn submit-btn" value="Register">
    </form>
</section>`;

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