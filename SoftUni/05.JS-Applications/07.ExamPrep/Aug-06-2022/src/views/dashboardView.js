import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';

const dashboardTemplate = (jobs) => html`
<section id="dashboard">
    <h2>Job Offers</h2>

    <ul class="card-wrapper">
        ${jobs.length > 0
            ? jobs.map(jobTemplate)
            : html`<h2>No offers yet.</h2>`
        }
    </ul>
</section>`;

const jobTemplate = (job) => html`
<div class="offer">
    <img src=${job.imageUrl} alt="example1" />
    <p>
        <strong>Title: </strong><span class="title">${job.title}</span>
    </p>
    <p><strong>Salary:</strong><span class="salary">${job.salary}</span></p>
    <a class="details-btn" href="/details/${job._id}">Details</a>
</div>`;

export async function dashboardPage(ctx) {
    const jobs = await data.getAll();
    ctx.render(dashboardTemplate(jobs));
}