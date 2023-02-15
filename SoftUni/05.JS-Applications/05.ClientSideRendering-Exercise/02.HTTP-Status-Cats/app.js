import { html, render } from '../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

const allCatsSection = document.getElementById('allCats');


const template = (cat) => html`
<li>
<img src=./images/${cat.imageLocation}.jpg width="250" height="250" alt="Card image cap">
<div class="info">
<button class="showBtn">Show status code</button>
<div>
<div class="status" style="display: none" id=${cat.id}>
<h4>Status Code: ${cat.statusCode}</h4>
<p>${cat.statusMessage}</p>
</div>
</li>`;


render(html`<ul>${cats.map(cat => template(cat))}</ul>`, allCatsSection);

allCatsSection.addEventListener('click', (ev) => {
    if (ev.target.tagName == 'BUTTON') {
        const button = ev.target;
        if (button.textContent == 'Show status code') {
            button.parentNode.querySelector('.status').style.display = 'block';
            button.textContent = 'Hide status code';
        } else {
            button.parentNode.querySelector('.status').style.display = 'none';
            button.textContent = 'Show status code';
        }
    }
});