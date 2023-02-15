import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { createSubmitHandler } from '../util.js';

const editTemplate = (game, onSubmit) => html`
<section id="edit-page" class="auth">
    <form @submit=${onSubmit} id="edit">
        <div class="container">

            <h1>Edit Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" value=${game.title}>

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" value=${game.category}>

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" value=${game.maxLevel}>

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" value=${game.imageUrl}>

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary">${game.summary}</textarea>
            <input class="btn submit" type="submit" value="Edit Game">

        </div>
    </form>
</section>`;

export async function editPage(ctx) {
    const id = ctx.params.id;
    const job = await data.getById(id);

    ctx.render(editTemplate(job, createSubmitHandler(ctx, onSubmit)));

    async function onSubmit(ctx, details, event) {
        if (Object.values(details).some(s => s == '')) {
            alert('All fields required');
            return;
        }

        await data.edit(id, details);
        event.target.reset();
        ctx.page.redirect(`/details/${id}`);
    }
}