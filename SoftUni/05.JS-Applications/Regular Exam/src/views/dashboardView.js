import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';

const dashboardTemplate = (items) => html`
<section id="dashboard">
        <h2>Albums</h2>

        ${items.length > 0
            ? html`<ul class="card-wrapper">
                ${items.map(itemTemplate)}
            </ul>`
            : html`<h2>There are no albums added yet.</h2>`
        }
</section>`;

const itemTemplate = (item) => html`
<li class="card">
            <img src=${item.imageUrl} alt="travis" />
            <p>
              <strong>Singer/Band: </strong><span class="singer">${item.singer}</span>
            </p>
            <p>
              <strong>Album name: </strong><span class="album">${item.album}</span>
            </p>
            <p><strong>Sales:</strong><span class="sales">${item.sales}</span></p>
            <a class="details-btn" href="/details/${item._id}">Details</a>
          </li>`;

export async function dashboardPage(ctx) {
    const items = await data.getAll();
    ctx.render(dashboardTemplate(items));
}