import { towns as townNames } from './towns.js';
import { html, render } from '../node_modules/lit-html/lit-html.js';


const towns = townNames.map(town => ({name: town, match: false}));
const divTowns = document.querySelector('#towns');
const input = document.getElementById('searchText');
const output = document.getElementById('result');

const searchBtn = document.querySelector('article button').addEventListener('click', search);

const listTemplate = (towns) => html`
<ul>
${towns.map(town => html`<li class=${town.match ? 'active' : ''}>${town.name}</li>`)}
</ul>`;

update();
function search() {
   let match = input.value.toLowerCase();
   let matches = 0;
   for (const town of towns) {
      if (match && town.name.toLowerCase().includes(match)){
         town.match = true;
         matches++;
      }else{
         town.match = false;
      }
      
   }
   output.textContent = `${matches} matches found`; 
   update();
}

function update() {
   render(listTemplate(towns), divTowns);
}