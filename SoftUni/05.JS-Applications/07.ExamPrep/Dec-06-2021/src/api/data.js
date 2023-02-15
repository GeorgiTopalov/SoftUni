import * as api from './api.js';

const endpoints = {
    all: '/data/albums?sortBy=_createdOn%20desc&distinct=name',
    create: '/data/albums',
    byId: '/data/albums/',
    byQuery: (query) => `/data/albums?where=name%20LIKE%20%22${query}%22`
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
export async function getSearchResults(query){
    return api.get(endpoints.byQuery(query));
}
