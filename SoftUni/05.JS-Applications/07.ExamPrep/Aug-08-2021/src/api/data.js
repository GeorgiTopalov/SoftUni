import * as api from './api.js';

const endpoints = {
    all: '/data/books?sortBy=_createdOn%20desc',
    create: '/data/books',
    byId: '/data/books/',
    myBooks: (userId) => `/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    addLike: '/data/likes',
    allLikes: (bookId) => `/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`,
    myLikes: (bookId, userId) => `/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`
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
export async function getMyLikes(bookId, userId){
    return api.get(endpoints.myLikes(bookId, userId));
}
export async function getAllLikes(bookId){
    return api.get(endpoints.allLikes(bookId));
}
export async function addLike(bookId){
    return api.post(endpoints.addLike, bookId)
}
export async function getMyBooks(userId){
    return api.get(endpoints.myBooks(userId));
}