import { createBook, html } from './util.js';

const createTemplate = () => html`
<form @submit=${onSubmit} id="add-form">
    <h3>Add book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title...">
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author...">
    <input type="submit" value="Submit">
</form>`;

export function showCreate(ctx) {
    if (ctx.book == undefined){
        return createTemplate() 
    }
    return null;
}

async function onSubmit(ev) {
    ev.preventDefault();
    const formData = new FormData(ev.target);

    const title = formData.get('title').trim();
    const author = formData.get('author').trim();

    if (title == '' || author == '') {
        return alert('All fields are required before submitting!');
    }

    await createBook({ title, author });

    ev.target.reset();
   
}