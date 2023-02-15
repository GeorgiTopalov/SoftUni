import page from '../node_modules/page/page.mjs';
import { logout } from './api/user.js';
import { authMiddleware } from './midlewares/authentication.js';
import { decorateContext, renderNav } from './midlewares/decorateCtx.js';
import { createPage } from './views/createView.js';
import { catalogPage } from './views/catalogView.js';
import { detailsPage } from './views/detailsView.js';
import { editPage } from './views/editView.js';
import { homePage } from './views/homeView.js';
import { loginPage } from './views/loginView.js';
import { registerPage } from './views/registerView.js';


page(decorateContext);
page(authMiddleware);
page(renderNav);
page('/', homePage);
page('/login', loginPage);
page('/register', registerPage);
page('/catalog', catalogPage);
page('/edit/:id', editPage);
page('/create', createPage);
page('/logout', logoutUser);
page('/details/:id', detailsPage);

page.start();


async function logoutUser(ctx){
    logout();
    ctx.page.redirect('/');
}