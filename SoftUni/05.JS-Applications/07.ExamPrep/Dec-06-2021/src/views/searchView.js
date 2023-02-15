import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';

const searchTemplate = (ctx, search, albums) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button @click=${search} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>
    <div class="search-result">
        <div class="search-result">
            ${albums && albums.length > 0
            ? albums.map(a => albumTemplate(ctx, a))
            : html`<p class="no-result">No result.</p>`
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
        ? html`
        <div class="btn-group">
            <a href="/details/${album._id}" id="details">Details</a>
        </div>`
        : nothing
    }
    </div>
</div>`;


export async function searchPage(ctx) {
    ctx.render(searchTemplate(ctx, search))

    async function search() {
        const input = document.getElementById('search-input').value;

        let albumsFound;
        if (input.trim() !== '') {
            albumsFound = await data.getSearchResults(input);
        } else {
            alert('Search field is empty!');
            return;
        }

        ctx.render(searchTemplate(ctx, search, albumsFound))
    }
}