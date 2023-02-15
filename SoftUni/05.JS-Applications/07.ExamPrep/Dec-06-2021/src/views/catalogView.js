import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';

const catalogTemplate = (ctx, albums) => html`
<section id="catalogPage">
    <h1>All Albums</h1>
    ${albums.length > 0
    ? html`
    <ul class="my-books-list">
        ${albums.map(a => albumTemplate(ctx, a))}
    </ul>`
    : html`<p>No Albums in Catalog!</p>`
    }
    </div>
</section>`;

const albumTemplate = (ctx, album) => html`
<div class="card-box">
    <img src=${album.imgUrl}>
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: ${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>
        ${ctx.user
        ?html`
        <div class="btn-group">
            <a href="/details/${album._id}" id="details">Details</a>
        </div>`
        : nothing
        }
        
    </div>
</div>`;

export async function catalogPage(ctx) {
    const albums = await data.getAll();
    ctx.render(catalogTemplate(ctx, albums));
}