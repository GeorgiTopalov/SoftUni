import { html } from '../../node_modules/lit-html/lit-html.js';
import * as data from '../api/data.js';
import { getUserData } from '../util.js';

const detailsTemplate = (pet, isOwner, onDelete, hasDonated, totalDonations, onApply, isLogged) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src=${pet.image}>
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: ${totalDonations}$</h4>
            </div>
            <div class="actionBtn">
                ${buttonsControlsTemplate(isOwner, onDelete, pet._id, hasDonated, onApply, isLogged)}
            </div>
        </div>
</section>`;

const buttonsControlsTemplate = (isOwner, onDelete, id, hasDonated, onApply, isLogged) => {
    if (isOwner) {
        return html`
                <a class="edit" href="/edit/${id}">Edit</a>
                <a @click=${onDelete} class="remove" href="javascript:void(0)">Delete</a>`;
    } else {
        return html`
                ${applicationControlsTemplate(isOwner, hasDonated, onApply, isLogged)}`;
    }
};

const applicationControlsTemplate = (isOwner, hasDonated, onApply, isLogged) => {
    if (hasDonated != 0 || !isLogged || isOwner) {
        return null;
    } else {
        return html`
        <a @click=${onApply} href="javascript:void(0)" class="donate-btn btn">Donate</a>`;
    }
}

export async function detailsPage(ctx) {
    const petId = ctx.params.id;
    const pet = await data.getById(petId);
    const userData = getUserData();

    let hasDonated;
    let donations = await data.getAllDonations(petId);
    if (userData) {
        hasDonated = await data.getUserDonationForOffer(petId, userData._id);
    }
    const isOwner = userData && (userData._id == pet._ownerId);
    const isLogged = userData != null;

    let totalDonations = Number(donations) * 100;

    ctx.render(detailsTemplate(pet, isOwner, onDelete, hasDonated, totalDonations, onApply, isLogged));

    async function onDelete() {
        const result = confirm("Do you really want to delete this play?");

        if (result) {
            await data.removeById(petId);
            ctx.page.redirect('/');
        }
    }

    async function onApply() {
        const donation = {
            petId
        };
        await data.donate(donation);

        donations = await data.getAllDonations(petId);
        hasDonated = await data.getUserDonationForOffer(petId, userData._id);
        totalDonations = Number(donations) * 100;
        
        ctx.render(detailsTemplate(pet, isOwner, onDelete, hasDonated, totalDonations, onApply, isLogged));
    }
}