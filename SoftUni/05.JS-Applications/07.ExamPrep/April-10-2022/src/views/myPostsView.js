import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';

const myPostsTemplate = (ownerPosts) => html`
<section id="my-posts-page">
    <h1 class="title">My Posts</h1>
    ${ownerPosts.length == 0
            ? html`
            <h1 class="title no-posts-title">You have no posts yet!</h1>`
            : html`
            ${ownerPosts.map(p => postTemplate(p))}`
        }
</section>`;

const postTemplate = (post) => html
    `<div class="my-posts">
        <div class="post">
            <h2 class="post-title">${post.title}</h2>
            <img class="post-image" src=${post.imageUrl} alt="Material Image">
            <div class="btn-wrapper">
                <a href="/details/${post._id}" class="details-btn btn">Details</a>
            </div>
        </div>
    </div>`;
  


export async function myPostsPage(ctx) {
    const userId = ctx.user._id;
    const myPosts = await data.getMyPosts(userId);

    ctx.render(myPostsTemplate(myPosts));
}