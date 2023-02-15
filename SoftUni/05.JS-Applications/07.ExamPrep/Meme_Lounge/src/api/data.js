import * as api from './api.js';

const endpoints = {
    all: '/data/memes?sortBy=_createdOn%20desc',
    create: '/data/memes',
    byId: '/data/memes/',
    byUser: (userId) => `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
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

export async function getMyMemes(userId){
    return api.get(endpoints.byUser(userId));
}
