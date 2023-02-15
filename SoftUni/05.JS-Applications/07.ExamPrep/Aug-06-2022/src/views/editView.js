import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { createSubmitHandler } from '../util.js';

const editTemplate = (job, onSubmit) => html`
<section id="edit">
    <div class="form">
        <h2>Edit Offer</h2>
        <form @submit=${onSubmit} class="edit-form">
            <input type="text" name="title" id="job-title" placeholder="Title" .value=${job.title} />
            <input type="text" name="imageUrl" id="job-logo" placeholder="Company logo url" .value=${job.imageUrl} />
            <input type="text" name="category" id="job-category" placeholder="Category" .value=${job.category} />
            <textarea id="job-description" name="description" placeholder="Description" rows="4" cols="50">${job.description}</textarea>
            <textarea id="job-requirements" name="requirements" placeholder="Requirements" rows="4"
                cols="50">${job.requirements}</textarea>
            <input type="text" name="salary" id="job-salary" placeholder="Salary" .value=${job.salary} />

            <button type="submit">post</button>
        </form>
    </div>
</section>`;

export async function editPage(ctx) {
    const id = ctx.params.id;
    const job = await data.getById(id);

    ctx.render(editTemplate(job, createSubmitHandler(ctx, onSubmit)));

    async function onSubmit(ctx, details, event) {
        if (Object.values(details).some(s => s == '')) {
            alert('All fields required');
            return;
        }

        await data.editPair(id, details);
        event.target.reset();
        ctx.page.redirect('/dashboard');
    }
}