import { html, render } from '../node_modules/lit-html/lit-html.js';


function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   const url = 'http://localhost:3030/jsonstore/advanced/table';
   const tbody = document.querySelector('tbody');
   let template = (info) => html`
      ${info.map(i => html`
      <tr id=${i._id}>
         <td>${i.firstName} ${i.lastName}</td>
         <td>${i.email}</td>
         <td>${i.course}</td>
      </tr>`)}`;

   getTableData();

   async function getTableData() {
      const resp = await fetch(url);
      const data = await resp.json();

      update(Object.values(data));
   }

   function update(data) {
      let result = template(data);
      render(result, tbody);
   }

   function onClick() {
      const input = document.getElementById('searchField');
      const value = input.value.toLocaleLowerCase();

      if (input.value == '') {
         return alert('Field is empty!');
      }

      const rows = Array.from(document.querySelectorAll('tbody tr'));

      for (const row of rows) {

         for (const child of row.children) {

            let info = child.textContent.toLocaleLowerCase();

            if (info.includes(value)) {
               row.classList = 'select';
               break;
            } else {
               row.classList = '';
            }
         }
      }

      input.value = '';
   }
}

solve();