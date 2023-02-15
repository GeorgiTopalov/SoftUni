function create(words) {

   let contentElement = document.getElementById('content');

   for (const word of words) {
      let newDivElement = document.createElement('div');
      let pa = document.createElement('p');
      pa.textContent = word;
      pa.style.display = 'none';

      newDivElement.appendChild(pa);

      newDivElement.addEventListener('click', (e) => {
         pa.style.display = 'block';
      });
      contentElement.appendChild(newDivElement);
   }
}