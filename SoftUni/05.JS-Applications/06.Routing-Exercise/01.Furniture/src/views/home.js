import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';

const homeTemplate = (furniture) => html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Welcome to Furniture System</h1>
            <p>Select furniture from the catalog to view details.</p>
        </div>
    </div>
    <div class="row space-top">
        ${furniture.map(f => template(f))};
    </div>`;

const template = (data) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
            <img src=${data.img}/>
            <p>${data.description}</p>
            <footer>
                <p>Price: <span>${data.price}</span></p>
            </footer>
            <div>
                <a href="details/123" class="btn btn-info">${data.details}</a>
            </div>
        </div>
    </div>
</div>`;

export async function homeView(ctx) {
    const furniture = await data.getAll();
    console.log(furniture);
    ctx.render(homeTemplate(furniture));
}