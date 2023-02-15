import { html, updateBook } from './util.js';

const updateTemplate = (book) => html`
<form @submit=${onSubmit} id="edit-form">
    <input type="hidden" name="id" .value=${book._id}>
    <h3>Edit book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title..." .value=${book.title}>
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author..." .value=${book.author}>
    <input type="submit" value="Save">
</form>`;

export function showUpdate(ctx){
    if (ctx.book == undefined){
        return null;
    }
    return updateTemplate(ctx.book);
}

async function onSubmit(ev) {
    ev.preventDefault();
    const formData = new FormData(ev.target);

    const id = formData.get('id');
    const title = formData.get('title').trim();
    const author = formData.get('author').trim();

    if (title == '' || author == '') {
        return alert('All fields are required before submitting!');
    }

    await updateBook(id, { title, author });

    ev.target.reset();
}