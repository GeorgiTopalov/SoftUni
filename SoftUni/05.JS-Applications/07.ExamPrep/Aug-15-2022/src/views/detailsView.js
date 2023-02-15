import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { getUserData } from '../util.js';

const detailsTemplate = (shoePair, isOwner,onDelete ) => html`
<section id="details">
    <div id="details-wrapper">
        <p id="details-title">${shoePair.details}</p>
        <div id="img-wrapper">
            <img src=${shoePair.imageUrl} alt="example1" />
        </div>
        <div id="info-wrapper">
            <p>Brand: <span id="details-brand">${shoePair.brand}</span></p>
            <p>
                Model: <span id="details-model">${shoePair.model}</span>
            </p>
            <p>Release date: <span id="details-release">${shoePair.release}</span></p>
            <p>Designer: <span id="details-designer">${shoePair.designer}</span></p>
            <p>Value: <span id="details-value">${shoePair.value}</span></p>
        </div>

        ${buttonsControlsTemplate(isOwner, onDelete, shoePair._id)}
    </div>
</section>`;

const buttonsControlsTemplate = (isOwner, onDelete, id) => {

    if (isOwner) {
            return html`
            <div id="action-buttons">
            <a id="btn-edit" href="/edit/${id}">Edit</a>
            <a @click=${onDelete} id="btn-delete" href="javascript:void(0)">Delete</a>
            </div>`;
        } else {
        return null;
     }
};

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const shoePair = await data.getById(id);
    const userData = getUserData();

    console.log(userData._id);
    console.log(shoePair._ownerId);
    const isOwner = userData && (userData._id == shoePair._ownerId);
    console.log(isOwner);

    
    ctx.render(detailsTemplate(shoePair, isOwner, onDelete ));

    async function onDelete() {
        const result = confirm("Do you really want to delete this play?");

        if (result) {
            await data.removeById(id);
            ctx.page.redirect('/dashboard');
        }
    }
}