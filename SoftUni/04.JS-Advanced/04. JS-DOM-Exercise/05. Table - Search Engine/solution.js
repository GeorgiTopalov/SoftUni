function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {

      let tableRowsElements = document.querySelectorAll('.container tbody tr');
      let searchInputValue = document.getElementById('searchField').value;

      for (let row of tableRowsElements) {
         if (row.innerHTML.toLowerCase()
            .includes(searchInputValue.toLowerCase())) {
            row.className = 'select';
         }else{
            row.className = '';
         }
      }
   }
}