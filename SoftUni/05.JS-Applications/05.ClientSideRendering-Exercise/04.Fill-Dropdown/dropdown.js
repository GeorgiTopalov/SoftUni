import { html, render } from '../node_modules/lit-html/lit-html.js';

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';

const dropdownMenu = document.querySelector('div');
const form = document.querySelector('form').addEventListener('submit', addItem);

const dropDownTemplate = (cities) => html`
<select id="menu">
    ${cities.map(city => html`<option value=${city.id}>${city.text}</option>`)}
</select>`;
getData();

async function getData() {
    const resp = await fetch(url);
    const data = await resp.json();

    updateDropdown(Object.values(data));
}

function updateDropdown(cities) {
    const result = dropDownTemplate(cities)
    render(result, dropdownMenu);

}


async function addItem(ev) {
    ev.preventDefault();
    const text = document.getElementById('itemText').value;
    if (text == '') {
        return alert('please fill all the fields');
    }
    const resp = await fetch(url, {
        method: "POST",
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({text})
    });

    if (resp.ok){
        getData();
        ev.target.reset();
    }
}



