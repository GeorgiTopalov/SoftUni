import { html } from '../../node_modules/lit-html/lit-html.js';

const navigationTemplate = (ctx) => html`
    <a href="/memes">All Memes</a>
      ${ctx.user
      ? html`
            <div class="user">
            <a href="/create">Create Meme</a>
            <div class="profile">
                <span>Welcome, ${ctx.user.username}</span>
                <a href="/profile">My Profile</a>
                <a href="/logout">Logout</a>
            </div>
        </div>`
      : html`
          <div class="guest">
          <div class="profile">
              <a href="/login">Login</a>
              <a href="/register">Register</a>
          </div>
          <a href="/">Home Page</a>
      </div>`}` 
      

export function navigationView(ctx){
    return navigationTemplate(ctx);
}