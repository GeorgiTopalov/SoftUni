import { html } from './util.js';

const buttonTemplate = (update) => html`
<button @click= ${() => updateCatalog( update)} id="loadBooks">LOAD ALL BOOKS</button>`;

export function showButton(ctx){
    return buttonTemplate(ctx.update);
}

async function updateCatalog(update){
   update();
}