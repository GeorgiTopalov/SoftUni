import * as api from './api.js';

const endpoints = {
    all: '/data/pets?sortBy=_createdOn%20desc&distinct=name',
    create: '/data/pets',
    byId: '/data/pets/',
    donations: '/data/donation',
    allDonations: (petId) => `/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`,
    userDonations: (petId, userId) => `/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`
}

export async function getAll() {
    return api.get(endpoints.all);
}

export async function create(data) {
    return api.post(endpoints.create, data)
}
export async function getById(id) {
    return api.get(endpoints.byId + id);
}
export async function editPair(id, data) {
    return api.put(endpoints.byId + id, data);
}
export async function removeById(id) {
    return api.del(endpoints.byId + id);
}

export async function getAllDonations(petId) {
    return api.get(endpoints.allDonations(petId));
}

export async function donate(petId){
    return api.post(endpoints.donations, petId);
}

export async function getUserDonationForOffer(petId, userId){
    return api.get(endpoints.userDonations(petId, userId));
}
