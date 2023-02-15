import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { getUserData } from '../util.js';

const detailsTemplate = (post, isOwner, onDelete, hasDonated, totalDonations, onApply, isLogged) => html`
<section id="details-page">
    <h1 class="title">Post Details</h1>

    <div id="container">
        <div id="details">
            <div class="image-wrapper">
                <img src=${post.imageUrl} alt="Material Image" class="post-image">
            </div>
            <div class="info">
                <h2 class="title post-title">${post.title}</h2>
                <p class="post-description">Description: ${post.description}</p>
                <p class="post-address">Address: ${post.address}</p>
                <p class="post-number">Phone number: ${post.phone}</p>
                <p class="donate-Item">Donate Materials: ${totalDonations}</p>
                <div class="btns">
                    ${buttonsControlsTemplate(isOwner, onDelete, post._id)}
                    ${applicationControlsTemplate(isOwner, hasDonated, onApply, isLogged)}
                </div>
            </div>
        </div>
    </div>
</section>`;

const buttonsControlsTemplate = (isOwner, onDelete, id) => {

    if (isOwner) {
        return html`
                <a href="/edit/${id}" class="edit-btn btn">Edit</a>
                <a @click=${onDelete} href="javascript:void(0)" class="delete-btn btn">Delete</a>
            `;
    } else {
        return null;
    }
};

const applicationControlsTemplate = (isOwner, hasDonated, onApply, isLogged) => {
    if (hasDonated !== 0 || !isLogged || isOwner ) {
        return null;
    } else {
        return html`
        <a @click=${onApply} href="javascript:void(0)" class="donate-btn btn">Donate</a>`;
    }
}

export async function detailsPage(ctx) {
    const postId = ctx.params.id;
    const userData = getUserData();
    const post = await data.getById(postId);

    let hasDonated;
    let totalDonations = await data.getAllDonations(postId);

    if (userData){
        hasDonated = await data.getUserDonationForOffer(postId, userData._id);
    }
     
    console.log(userData);
    console.log(totalDonations);

    const isOwner = userData && (userData._id == post._ownerId);
    const isLogged = userData !== undefined;
    console.log(isOwner);
    console.log(isLogged);
   

    ctx.render(detailsTemplate(post, isOwner, onDelete, hasDonated, totalDonations, onApply, isLogged));

    async function onDelete() {
        const result = confirm("Do you really want to delete this play?");

        if (result) {
            await data.removeById(postId);
            ctx.page.redirect('/');
        }
    }

    async function onApply(ev) {
        const application = {
            postId,
        };
        await data.donate(application);

        totalDonations = await data.getAllDonations(postId);
        hasDonated = await data.getUserDonationForOffer(postId, userData._id);    
        ctx.render(detailsTemplate(post, isOwner, onDelete, hasDonated, totalDonations, onApply, isLogged));
        ev.target.style.display = 'none';
    }
}


