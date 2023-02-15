import { logout } from "../api/user.js";


export async function logoutUser(ctx){
    logout();
    ctx.page.redirect('/');
}