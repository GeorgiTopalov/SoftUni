function search() {
let townsElements = document.querySelectorAll('#towns li');
let textElementValue = document.getElementById('searchText').value;

let counter = 0;
for (let i = 0; i < townsElements.length; i++) {

   let currentTown = townsElements[i];

  if (currentTown.textContent.toLowerCase().includes(textElementValue.toLowerCase())){
   currentTown.style.fontWeight = 'bold';
   currentTown.style.textDecoration = 'underline';
   counter++;
  }else{
    let currentTown = townsElements[i];
    currentTown.style.fontWeight = 'normal';
    currentTown.style.textDecoration = 'none';
  }

  townsElements[i] = currentTown;
}

let resultElement = document.getElementById('result');
resultElement.textContent = `${counter} matches found`;
}