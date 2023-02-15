import { render } from '../../node_modules/lit-html/lit-html.js';
import { navigationView } from '../views/navigationView.js';

const header = document.querySelector('nav');
const root = document.querySelector('main');

function ctxRender(content){
    render(content, root);
}
export function decorateContext(ctx, next) {
    ctx.render = ctxRender;
    next();
} 

export function renderNav (ctx, next){
    render(navigationView(ctx), header);
    next();
}; 
