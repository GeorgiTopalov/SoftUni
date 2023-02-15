import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { getUserData } from '../util.js';

const detailsTemplate = (job, isOwner, onDelete, hasLiked, totalApplications, onApply) => html`
<section id="details">
    <div id="details-wrapper">
        <img id="details-img" src=${job.imageUrl} alt="example1" />
        <p id="details-title">${job.title}</p>
        <p id="details-category">
            Category: <span id="categories">${job.category}</span>
        </p>
        <p id="details-salary">
            Salary: <span id="salary-number">${job.salary}</span>
        </p>
        <div id="info-wrapper">
            <div id="details-description">
                <h4>Description</h4>
                <span>${job.description}</span>
            </div>
            <div id="details-requirements">
                <h4>Requirements</h4>
                <span>${job.requirements}</span>
            </div>
        </div>
        <p>Applications: <strong id="applications">${totalApplications}</strong></p>
        <div id="action-buttons">
            ${buttonsControlsTemplate(isOwner, onDelete, job._id)}
            ${applicationControlsTemplate(isOwner, hasLiked, onApply)}
        </div>
    </div>
</section>`;

const buttonsControlsTemplate = (isOwner, onDelete, id) => {

    if (isOwner) {
        return html`
                <a id="edit-btn" href="/edit/${id}">Edit</a>
                <a @click=${onDelete} id="delete-btn" href="javascript:void(0)">Delete</a>
            `;
    } else {
        return null;
    }
};

const applicationControlsTemplate = (isOwner, hasLiked, onApply) => {
    if (!isOwner && !hasLiked) {
        return html`
        <a @click=${onApply} href="" id="apply-btn">Apply</a>`;
    } else {
        return null;
    }
}

export async function detailsPage(ctx) {
    const id = ctx.params.id;
    const userData = getUserData();

    const job = await data.getById(id);
    let hasLiked = await data.getUserApplicationForOffer(id, userData._id);
    let totalApplications = await data.getAllApplications(id);

    const isOwner = userData && (userData._id == job._ownerId);



    ctx.render(detailsTemplate(job, isOwner, onDelete, hasLiked, totalApplications, onApply));

    async function onDelete() {
        const result = confirm("Do you really want to delete this play?");

        if (result) {
            await data.removeById(id);
            ctx.page.redirect('/dashboard');
        }
    }

    async function onApply() {
        const application = {
            id,
        };
        await data.apply(application);
        ctx.render(detailsTemplate(job, isOwner, onDelete, hasLiked, totalApplications, onApply));
    }
}
