import * as api from './api.js';

const endpoints = {
    all: '/data/offers?sortBy=_createdOn%20desc',
    create: '/data/offers',
    byId: '/data/offers/',
    applications: '/data/applications',
    allApplications: (offerId) => `/data/applications?where=offerId%3D%22${offerId}%22&distinct=_ownerId&count`,
    userApplications: (offerId, userId) => `/data/applications?where=offerId%3D%22${offerId}%22%20and%20_ownerId%3D%22${userId}%22&count`
}

export async function getAll() {
    return api.get(endpoints.all);
}

export async function createPair(data) {
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
export async function getAllApplications(offerId) {
    return api.get(endpoints.allApplications(offerId));
}

export async function apply(offerId){
    return api.post(endpoints.applications, offerId);
}

export async function getUserApplicationForOffer(offerId, userId){
    return api.get(endpoints.userApplications(offerId, userId));
}


