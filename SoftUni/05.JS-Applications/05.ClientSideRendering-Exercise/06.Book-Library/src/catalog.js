import { getBooks, deleteBook, html, until } from './util.js';


const catalogTemplate = (booksPromise) => html`
<table>
        <thead>
            <tr>
                <th>Title</th>
                <th>Author</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
        ${until(booksPromise, html`<tr>
            <td colSpan="3">Loading&hellip;</td>
        </tr>`)}
    </tbody>
</table>`;

const bookRow = (book, onEdit) => html`<tr id=${book._id}>
    <td>${book.title}</td>
    <td>${book.author}</td>
    <td>
        <button @click=${onEdit}>Edit</button>
        <button @click=${onDelete}>Delete</button>
    </td>
</tr>`

export function showCatalog(ctx) {
    return catalogTemplate(loadBooks(ctx));
}

async function loadBooks(ctx) {
    const data = await getBooks();
    const books = Object.entries(data).map(([k,v]) => Object.assign(v, {_id:k}));
    
    return Object.values(books).map(book => bookRow(book,() => toggleEdit(book, ctx)));
}

async function onDelete(ev){
    
    console.log(ev.target.parentNode.parentNode.id);
    deleteBook(ev.target.parentNode.parentNode.id);
    ev.target.parentNode.parentNode.remove();
}

async function toggleEdit(book, ctx){
    ctx.book = book;
    ctx.update();
}