import { html, render } from './node_modules/lit-html/lit-html.js';

const root = document.getElementById('root');

document.querySelector('form').addEventListener('submit', (ev) =>{
    ev.preventDefault();
    const input = document.getElementById('towns').value;
    let townsToRender = input.split(', ');

    const result = townsTemplate(townsToRender);
    render(result, root);
});


let townsTemplate = (towns) => html `
<ul>
${towns.map(town => html `<li>${town}</li>`)}
</ul>`;

