import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { createSubmitHandler } from '../util.js';

const editTemplate = (shoePair, onSubmit) => html`
<section id="edit">
    <div class="form">
        <h2>Edit item</h2>
        <form @submit=${onSubmit} class="edit-form">
            <input type="text" name="brand" id="shoe-brand" placeholder="Brand" .value=${shoePair.brand} />
            <input type="text" name="model" id="shoe-model" placeholder="Model" .value=${shoePair.model} />
            <input type="text" name="imageUrl" id="shoe-img" placeholder="Image url" .value=${shoePair.imageUrl} />
            <input type="text" name="release" id="shoe-release" placeholder="Release date" .value=${shoePair.release} />
            <input type="text" name="designer" id="shoe-designer" placeholder="Designer" .value=${shoePair.designer} />
            <input type="text" name="value" id="shoe-value" placeholder="Value" .value=${shoePair.value} />

            <button type="submit">post</button>
        </form>
    </div>
</section>`;

export async function editPage(ctx) {
    const id = ctx.params.id;
    const shoePair = await data.getById(id);

    ctx.render(editTemplate(shoePair,createSubmitHandler(ctx, onSubmit)));

    async function onSubmit(ctx, details, event){
        if (Object.values(details).some(s => s == '')){
            alert('All fields required');
            return;
        }

        await data.editPair(id, details);
        event.target.reset();
        ctx.page.redirect('/dashboard');
    }
}