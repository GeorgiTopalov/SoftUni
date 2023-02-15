import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { createSubmitHandler } from '../util.js';

const editTemplate = (board, onSubmit) => html`
section id="editPage">
<form @submit=${onSubmit} class="editForm">
    <img src="./images/editpage-dog.jpg">
    <div>
        <h2>Edit PetPal</h2>
        <div class="name">
            <label for="name">Name:</label>
            <input name="name" id="name" type="text" value=${board.name} >
        </div>
        <div class="breed">
            <label for="breed">Breed:</label>
            <input name="breed" id="breed" type="text" value=${board.breed} >
        </div>
        <div class="Age">
            <label for="age">Age:</label>
            <input name="age" id="age" type="text" value=${board.age} >
        </div>
        <div class="weight">
            <label for="weight">Weight:</label>
            <input name="weight" id="weight" type="text" value=${board.weight} >
        </div>
        <div class="image">
            <label for="image">Image:</label>
            <input name="image" id="image" type="text" value=${board.image} >
        </div>
        <button class="btn" type="submit">Edit Pet</button>
    </div>
</form>
</section>`;

export async function editPage(ctx) {
    const id = ctx.params.id;
    const pet = await data.getById(id);

    ctx.render(editTemplate(pet, createSubmitHandler(ctx, onSubmit)));

    async function onSubmit(ctx, details, event) {
        if (Object.values(details).some(s => s == '')) {
            alert('All fields required');
            return;
        }

        await data.editPair(id, details);
        event.target.reset();
        ctx.page.redirect(`/details/${id}`);
    }
}