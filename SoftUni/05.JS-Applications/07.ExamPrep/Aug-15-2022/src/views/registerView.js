import { html } from '../../node_modules/lit-html/lit-html.js';
import * as user from '../api/user.js';

const registerTemplate = (onSubmit) => html`
<section id="register">
    <div class="form">
        <h2>Register</h2>
        <form @submit=${onSubmit} class="login-form">
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">register</button>
            <p class="message">Already registered? <a href="/login">Login</a></p>
        </form>
    </div>
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
        ctx.page.redirect('/dashboard');
    }
    ctx.render(registerTemplate(onSubmit));
}