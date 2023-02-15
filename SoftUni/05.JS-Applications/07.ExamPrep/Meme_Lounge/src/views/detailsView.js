import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { getUserData } from '../util.js';

const detailsTemplate = (meme, isOwner, onDelete) => html`
<section id="meme-details">
    <h1>Meme Title: ${meme.title}</h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${meme.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>${meme.description}</p>
            ${buttonsControlsTemplate(isOwner, onDelete, meme)}
        </div>
</section>`;

const buttonsControlsTemplate = (isOwner, onDelete, meme) => {
    if (isOwner) {
        return html`
                <a class="button warning" href="/edit/${meme._id}">Edit</a>
                <a @click=${onDelete} class="button danger" href="javascript:void(0)">Delete</a>`;
    } else {
        return nothing;
    }
};



export async function detailsPage(ctx) {
    console.log(ctx);
    const memeId = ctx.params.id;
    const meme = await data.getById(memeId);
    const userData = getUserData();

   
    const isOwner = userData && (userData._id == meme._ownerId);

    ctx.render(detailsTemplate(meme, isOwner, onDelete))
    async function onDelete() {
        const result = confirm("Do you really want to delete this meme?");

        if (result) {
            await data.removeById(memeId);
            ctx.page.redirect('/memes');
        }
    }

}