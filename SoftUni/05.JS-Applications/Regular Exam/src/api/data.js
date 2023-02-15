import * as api from './api.js';

const endpoints = {
    all: '/data/albums?sortBy=_createdOn%20desc',
    create: '/data/albums',
    byId: '/data/albums/',
    addLike: '/data/likes',
    allLikes: (albumId) => `/data/likes?where=albumId%3D%22${albumId}%22&distinct=_ownerId&count`,
    likesForAlbum: (albumId, userId) => `/data/likes?where=albumId%3D%22${albumId}%22%20and%20_ownerId%3D%22${userId}%22&count`
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
export async function edit(id, data) {
    return api.put(endpoints.byId + id, data);
}
export async function removeById(id) {
    return api.del(endpoints.byId + id);
}

export async function getAllLikes(albumId) {
    return api.get(endpoints.allLikes(albumId));
}
export async function addLike() {
    return api.post(endpoints.addLike);
}
export async function getMyLikes(albumId, userId) {
    return api.get(endpoints.likesForAlbum(albumId, userId));
}
