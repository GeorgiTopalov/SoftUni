import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { getUserData } from '../util.js';

const detailsTemplate = (book, isOwner, onDelete, hasLiked, totalLikes, onApply, isLoggedIn) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <div class="actions">
            ${buttonsControlsTemplate(isOwner, onDelete, book._id)}
            ${applicationControlsTemplate(isOwner, hasLiked , onApply, isLoggedIn)}
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${totalLikes}</span>
            </div>
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}/p>
    </div>
</section>`;

const buttonsControlsTemplate = (isOwner, onDelete, id) => {
    if (isOwner) {
        return html`
                <a class="button" href="/edit/${id}">Edit</a>
                <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>
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
        <a @click=${onApply} href="javascript:void(0)" class="button">Like</a>`;
    }
}



export async function detailsPage(ctx) {
    const bookId = ctx.params.id;
    const userData = getUserData();

    const book = await data.getById(bookId);

    let hasLiked;
    let totalLikes = await data.getAllLikes(bookId);

    if (userData) {
        hasLiked = await data.getMyLikes(bookId, userData._id);
    }

    const isOwner = userData && (userData._id == book._ownerId);
    const isLoggedIn = userData !== null;

    ctx.render(detailsTemplate(book, isOwner, onDelete, hasLiked, totalLikes, onApply, isLoggedIn));

    async function onDelete() {
        const result = confirm("Do you really want to delete this book?");

        if (result) {
            await data.removeById(bookId);
            ctx.page.redirect('/');
        }
    }

    async function onApply(ev) {
        const application = {
            bookId,
        };
        await data.addLike(application);

        totalLikes = await data.getAllLikes(bookId);
        hasLiked = await data.getMyLikes(bookId, userData._id);
        ctx.render(detailsTemplate(book, isOwner, onDelete, hasLiked, totalLikes, onApply, isLoggedIn));
    }
}


