import { clearUserData, setUserData } from '../util.js';
import * as api from './api.js';

export async function login(email, password) {
    const result = await api.post('/users/login', { email, password });
    setUserData(result);
    return result;
}

export async function register(username, email, password, gender) {
    const result = await api.post('/users/register', {username, email, password, gender });
    setUserData(result);
}

export async function logout() {
    api.get('/users/logout');
    clearUserData();
}
