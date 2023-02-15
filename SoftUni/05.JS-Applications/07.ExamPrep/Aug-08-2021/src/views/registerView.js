import { html } from '../../node_modules/lit-html/lit-html.js';
import * as user from '../api/user.js';

const registerTemplate = (onSubmit) => html`
<section id="register-page" class="register">
    <form @submit=${onSubmit} id="register-form" action="" method="">
        <fieldset>
            <legend>Register Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <p class="field">
                <label for="repeat-pass">Repeat Password</label>
                <span class="input">
                    <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Register">
        </fieldset>
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