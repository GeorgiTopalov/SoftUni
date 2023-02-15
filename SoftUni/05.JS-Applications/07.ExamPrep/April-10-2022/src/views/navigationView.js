import { html } from '../../node_modules/lit-html/lit-html.js';

const navigationTemplate = (ctx) => html`
 <h1><a href="/">Orphelp</a></h1>
<nav>
    <a href="/">Dashboard</a>
          ${ctx.user
        ? html`<div id="user">
            <a href="/myPosts">My Posts</a>
            <a href="/create">Create Post</a>
            <a href="/logout">Logout</a>
          </div>`
        : html`<div id="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
          </div>
        </nav>`
        }`
          

export function navigationView(ctx){
    return navigationTemplate(ctx);
}
