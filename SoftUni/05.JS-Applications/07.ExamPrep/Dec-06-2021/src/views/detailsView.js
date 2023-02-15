import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { getUserData } from '../util.js';

const detailsTemplate = (album, isOwner, onDelete) => html`
<section id="detailsPage">
            <div class="wrapper">
                <div class="albumCover">
                    <img src="./images/Lorde.jpg">
                </div>
                <div class="albumInfo">
                    <div class="albumText">

                        <h1>Name: ${album.name}</h1>
                        <h3>Artist: ${album.artist}</h3>
                        <h4>Genre: ${album.genre}</h4>
                        <h4>Price: ${album.price}</h4>
                        <h4>Date: ${album.date}</h4>
                        <p>Description: ${album.description}</p>
                    </div>
            ${buttonsControlsTemplate(isOwner, onDelete, album._id)}
        </div>
    </div>
</section>`;

const buttonsControlsTemplate = (isOwner, onDelete, id) => {
    if (isOwner) {
        return html`
            <div class="actionBtn">
            <a class="edit" href="/edit/${id}">Edit</a>
            <a @click=${onDelete} class="remove" href="javascript:void(0)">Delete</a>
            </div>`;
    } else {
            return null;
    }
};


export async function detailsPage(ctx) {
    const albumId = ctx.params.id;
    const userData = getUserData();

    const album = await data.getById(albumId);


    const isOwner = userData && (userData._id == album._ownerId);

    ctx.render(detailsTemplate(album, isOwner, onDelete));

    async function onDelete() {
        const result = confirm("Do you really want to delete this book?");

        if (result) {
            await data.removeById(albumId);
            ctx.page.redirect('/catalog');
        }
    }
}


