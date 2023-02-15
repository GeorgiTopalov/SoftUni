import { html } from '../../node_modules/lit-html/lit-html.js';
import { createSubmitHandler, getUserData } from '../util.js';
import * as data from '../api/data.js';

const searchTemplate = (user, onSubmit, shoes) => html`
<section id="search">
    <h2>Search by Brand</h2>

    <form @submit=${onSubmit} class="search-wrapper cf">
        <input id="#search-input" type="text" name="search" placeholder="Search here..." required />
        <button type="submit">Search</button>
    </form>
    <div>
        <h3>Results:</h3>
    
        ${shoes && shoes.length > 0
            ? shoes.map(s => shoePairTemplate(s, user))
            : html`<h2>There are no results found.</h2>`
        }
        <div id="search-container">
    
    </div>
</section>`;

const shoePairTemplate = (shoe, user) => html`
<ul class="card-wrapper">
    <li class="card">
        <img src=${shoe.imageUrl} alt="travis" />
        <p>
            <strong>Brand: </strong><span class="brand">${shoe.brand}</span>
        </p>
        <p>
            <strong>Model: </strong><span class="model">${shoe.model}</span>
        </p>
        <p><strong>Value:</strong><span class="value">${shoe.value}</span>$</p>
        ${user
        ? html`<a class="details-btn" href="/details/${shoe._id}">Details</a>`
        : html``
    }
    </li>
    </ul>`;


export async function searchPage(ctx) {
    const user = getUserData();
    ctx.render(searchTemplate(user, createSubmitHandler(ctx, onSubmit)));

    async function onSubmit(ctx, searchInfo) {
        const shoes = await data.getShoesByBrand(searchInfo.search);
        console.log(shoes);

        ctx.render(searchTemplate(user, createSubmitHandler(ctx, onSubmit), shoes));
    }
}