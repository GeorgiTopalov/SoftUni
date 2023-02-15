import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';

const myBooksTemplate = (myBooks) => html`
 <section id="my-books-page" class="my-books">
            <h1>My Books</h1>
        ${myBooks.length > 0
        ? html`
        <ul class="my-books-list">
            ${myBooks.map(bookTemplate)}
        </ul>`
        : html`<p class="no-books">No books in database!</p>`
    }
    </div>
</section>`;

const bookTemplate = (book) => html`
    <li class="otherBooks">
        <h3> ${book.title}</h3>
        <p>Type: ${book.type} </p>
        <p class="img"><img src= ${book.imageUrl}></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>`;

export async function myBooksPage(ctx) {
    const myBooks = await data.getMyBooks(ctx.user._id);
    ctx.render(myBooksTemplate(myBooks));
}