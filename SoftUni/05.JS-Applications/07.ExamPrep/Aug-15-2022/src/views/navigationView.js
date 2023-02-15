import { html } from '../../node_modules/lit-html/lit-html.js';

const navigationTemplate = (ctx) => html`
 <a id="logo" href="/"
          ><img id="logo-img" src="./images/logo.png" alt=""
        /></a>

        <nav>
          <div>
            <a href="/dashboard">Dashboard</a>
            <a href="/search">Search</a>
          </div>

          ${ctx.user
        ? html`<div class="user">
            <a href="/create">Add Pair</a>
            <a href="/logout">Logout</a>
          </div>`
        : html`<div class="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
          </div>
        </nav>`
        }`
          

export function navigationView(ctx){
    return navigationTemplate(ctx);
}