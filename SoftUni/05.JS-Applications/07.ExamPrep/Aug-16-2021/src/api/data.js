import * as api from './api.js';

const endpoints = {
    all: '/data/games?sortBy=_createdOn%20desc',
    create: '/data/games',
    byId: '/data/games/',
    recent: '/data/games?sortBy=_createdOn%20desc&distinct=category',
    allComments: (gameId) => `/data/comments?where=gameId%3D%22${gameId}%22`,
    addComment: '/data/comments'
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
export async function getRecentGames(){
    return api.get(endpoints.recent);
}
export async function getAllComments(gameId){
    return api.get(endpoints.allComments(gameId));
}
export async function postComment(data){
    return api.post(endpoints.addComment, data)
}