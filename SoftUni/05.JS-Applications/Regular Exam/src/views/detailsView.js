import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { getUserData } from '../util.js';

const detailsTemplate = (item, isOwner, onDelete, hasLiked, totalLikes, onApply, isLoggedIn) => html`
<section id="details">
    <div id="details-wrapper">
        <p id="details-title">Album Details</p>
        <div id="img-wrapper">
            <img src=${item.imageUrl} alt="example1" />
        </div>
        <div id="info-wrapper">
            <p><strong>Band:</strong><span id="details-singer">${item.singer}</span></p>
            <p>
                <strong>Album name:</strong><span id="details-album">${item.album}</span>
            </p>
            <p><strong>Release date:</strong><span id="details-release">${item.release}</span></p>
            <p><strong>Label:</strong><span id="details-label">${item.label}</span></p>
            <p><strong>Sales:</strong><span id="details-sales">${item.sales}</span></p>
        </div>
        <div id="likes">Likes: <span id="likes-count">${totalLikes}</span></div>
        <div id="action-buttons">
            ${buttonsControlsTemplate(isOwner, onDelete, item._id)}
            ${applicationControlsTemplate(isOwner, hasLiked , onApply, isLoggedIn)}
        </div>
    </div>
</section>`;

const buttonsControlsTemplate = (isOwner, onDelete, id) => {
    if (isOwner) {
        return html`
                <a id="edit-btn" href="/edit/${id}">Edit</a>
                <a @click=${onDelete} id="delete-btn" href="javascript:void(0)">Delete</a>
            `;
    } else {
        return null;
    }
};

const applicationControlsTemplate = (isOwner, hasLiked , onApply, isLoggedIn) => {
    if (hasLiked !== 0 || !isLoggedIn || isOwner ) {
        return null;
    } else {
        return html`
        <a @click=${onApply} href="javascript:void(0)" id="like-btn">Like</a>`;
    }
} 

export async function detailsPage(ctx) {
    const itemId = ctx.params.id;
    const userData = getUserData();
    const item = await data.getById(itemId);

    let hasLiked;
    let totalLikes = await data.getAllLikes(itemId);

    console.log(totalLikes);
    const isOwner = userData && (userData._id == item._ownerId);
    if (userData) {
        hasLiked = await data.getMyLikes(itemId, userData._id);
    }
    const isLoggedIn = userData !== null;

    ctx.render(detailsTemplate(item, isOwner, onDelete, hasLiked, totalLikes, onApply, isLoggedIn));

    async function onDelete() {
        const result = confirm("Do you really want to delete this book?");

        if (result) {
            await data.removeById(itemId);
            ctx.page.redirect('/');
        }
    }

    async function onApply(ev) {
        const application = {
            albumId: itemId,
        };
        await data.addLike(application);
    
        totalLikes = await data.getAllLikes(itemId);
        hasLiked = await data.getMyLikes(itemId, userData._id);
        ctx.render(detailsTemplate(item, isOwner, onDelete, hasLiked, totalLikes, onApply, isLoggedIn));
    }

}


