function solve() {
  let inputElement = document.querySelector('body div div textarea');
  let generateButtonElement = document.querySelector('body div div button');

  generateButtonElement.addEventListener('click', () => {

    let itemInfo = Array.from(JSON.parse(inputElement.value));

    for (let i = 0; i < itemInfo.length; i++) {

      let newRow = document.createElement('tr');
      let imgTd = document.createElement('td');
      let image = document.createElement('img');
      image.src = itemInfo[i].img;
      imgTd.appendChild(image);
      newRow.appendChild(imgTd);

      let nameTd = document.createElement('td');
      let name = document.createElement('p');
      name.id = 'name';
      name.textContent = itemInfo[i].name;
      nameTd.appendChild(name);
      newRow.appendChild(nameTd);

      let priceTd = document.createElement('td');
      let price = document.createElement('p');
      price.id = 'price';
      price.textContent = itemInfo[i].price;
      priceTd.appendChild(price);
      newRow.appendChild(priceTd);

      let decFactorTd = document.createElement('td');
      let decFactor = document.createElement('p');
      decFactor.id = 'decFactor';
      decFactor.textContent = itemInfo[i].decFactor;
      decFactorTd.appendChild(decFactor);
      newRow.appendChild(decFactorTd);

      let checkboxTd = document.createElement('td');
      let checkbox = document.createElement('input');
      checkbox.type = 'checkbox';
      checkboxTd.appendChild(checkbox);
      newRow.appendChild(checkboxTd);

      document.getElementsByTagName('tbody')[0].appendChild(newRow);
    }
  });



  let buyButtonElement = document.querySelector('div div button:nth-of-type(2)');

  buyButtonElement.addEventListener('click', () => {

    let totalPrice = 0;
    let boughtItemNames = [];
    let totalDecFactor = 0;

    let allItemsElements = Array.from(document.querySelectorAll('.table tr'));

    for (let i = 2; i < allItemsElements.length; i++) {

      let checkbox = allItemsElements[i].querySelector('input');

      if (checkbox.checked == true) {

        console.log('1');

        totalPrice += Number(allItemsElements[i].querySelector('#price').textContent);
        boughtItemNames.push(allItemsElements[i].querySelector('#name').textContent);
        totalDecFactor += Number(allItemsElements[i].querySelector('#decFactor').textContent);

        console.log(allItemsElements[i].querySelector('#price').textContent);
        console.log(allItemsElements[i].querySelector('#decFactor').textContent);
      }
    }

    let outputTextAreaElement = document.querySelector('div div textarea:nth-of-type(2)');

    outputTextAreaElement.value += `Bought furniture: ${boughtItemNames.join(', ')}\n`;
    outputTextAreaElement.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    outputTextAreaElement.value += `Average decoration factor: ${totalDecFactor / boughtItemNames.length}`;

  });

}