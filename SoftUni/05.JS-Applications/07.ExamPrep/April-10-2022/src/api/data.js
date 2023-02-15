import * as api from './api.js';

const endpoints = {
    all: '/data/posts?sortBy=_createdOn%20desc',
    create: '/data/posts',
    byId: '/data/posts/',
    donations: '/data/donations',
    myPosts: (userId) => `/data/posts?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    allDonations: (postId) => `/data/donations?where=postId%3D%22${postId}%22&distinct=_ownerId&count`,
    userDonations: (postId, userId) => `/data/donations?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`
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
export async function edit(id, data) {
    return api.put(endpoints.byId + id, data);
}
export async function removeById(id) {
    return api.del(endpoints.byId + id);
}
export async function getMyPosts(userId){
    return api.get(endpoints.myPosts(userId));
}
export async function getAllDonations(postId) {
    return api.get(endpoints.allDonations(postId));
}

export async function donate(postId){
    return api.post(endpoints.donations, postId);
}

export async function getUserDonationForOffer(offerId, userId){
    return api.get(endpoints.userDonations(offerId, userId));
}


