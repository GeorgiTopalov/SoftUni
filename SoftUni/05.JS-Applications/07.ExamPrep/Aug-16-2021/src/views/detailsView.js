import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { createSubmitHandler, getUserData } from '../util.js';

const detailsTemplate = (game, isOwner, onDelete, comments, isLoggedIn, postComment) => html`
<section id="details">
    <section id="game-details">
        <h1>Game Details</h1>
        <div class="info-section">

            <div class="game-header">
                <img class="game-img" src=${game.imageUrl} />
                <h1>${game.title}</h1>
                <span class="levels">MaxLevel: ${game.maxLevel}</span>
                <p class="type">${game.category}</p>
            </div>

            <p class="text">
                ${game.summary}
            </p>
            <div id="action-buttons">
                ${buttonsControlsTemplate(isOwner, onDelete, game._id)}
            </div>
            <div class="details-comments">
                <h2>Comments:</h2>
                ${comments.length > 0
                ? html`
                <ul>
                    ${comments.map(commentTemplate)}
                </ul>`
                : html`<p class="no-comment">No comments.</p>`
                 }
            </div>
            ${addCommentTemplate(isOwner, isLoggedIn, postComment)}
    </section>`;

const buttonsControlsTemplate = (isOwner, onDelete, id) => {
    if (isOwner) {
        return html`
                <div class="buttons">
                     <a class="button" href="/edit/${id}">Edit</a>
                     <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>
                </div>
            `;
    } else {
        return null;
    }
};

const commentTemplate = (comment) => html`
<li class="comment">
    <p>Content: ${comment.comment}</p>
</li>`

const addCommentTemplate = (isOwner, isLoggedIn, postComment) => {
    if (isLoggedIn && !isOwner){
        return html`
        <article class="create-comment">
            <label>Add new comment:</label>
            <form @submit=${postComment} class="form">
                <textarea name="comment" placeholder="Comment......"></textarea>
                <input class="btn submit" type="submit" value="Add Comment">
            </form>
        </article>`
    }
}

export async function detailsPage(ctx) {
    const gameId = ctx.params.id;
    const userData = getUserData();

    const game = await data.getById(gameId);
    const comments = await data.getAllComments(gameId);

    const isOwner = userData && (userData._id == game._ownerId);
    const isLoggedIn = userData !== null;

    ctx.render(detailsTemplate(game, isOwner, onDelete, comments, isLoggedIn, createSubmitHandler(ctx, postComment)));

    async function onDelete() {
        const result = confirm("Do you really want to delete this play?");

        if (result) {
            await data.removeById(gameId);
            ctx.page.redirect('/');
        }
    }

    async function postComment(ctx, details, event){
        if (Object.values(details).some(s => s.trim() == '')) {
            alert('Cannot post an empty comment');
            return;
        } 
        const commentContent = {
            gameId,
            comment: Object.values(details)[0],
        }

        
       await data.postComment(commentContent);

        event.target.reset();
        ctx.page.redirect(`/details/${gameId}`);
    }

}


