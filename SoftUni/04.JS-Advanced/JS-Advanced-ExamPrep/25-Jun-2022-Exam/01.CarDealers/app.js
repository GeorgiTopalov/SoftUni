window.addEventListener("load", solve);

function solve() {
  let publishButtonElement = document.getElementById('publish');

  let tableBodyElement = document.getElementById('table-body');



  publishButtonElement.addEventListener('click', (e) => {
    e.preventDefault();

    let makeElement = document.getElementById('make');
    let modelElement = document.getElementById('model');
    let yearElement = document.getElementById('year');
    let fuelElement = document.getElementById('fuel');
    let originalCostElement = document.getElementById('original-cost');
    let sellingPriceElement = document.getElementById('selling-price');

    let make = makeElement.value;
    let model = modelElement.value;
    let year = yearElement.value;
    let fuel = fuelElement.value;
    let cost = originalCostElement.value;
    let price = sellingPriceElement.value;
    
    if (!make || !model || !year || !fuel || !cost || !price) {
      return;
    }

    if (cost > price) {
      return
    }

    let rowElement = document.createElement('tr');
    rowElement.classList = 'row';
    let makeCellElement = document.createElement('td');
    let modelCellElement = document.createElement('td');
    let yearCellElement = document.createElement('td');
    let fuelCellElement = document.createElement('td');
    let originalCostCellElement = document.createElement('td');
    let sellingPriceCellElement = document.createElement('td');
    let buttonsCell = document.createElement('td');
    let editButtonElement = document.createElement('button');
    let sellButtonElement = document.createElement('button');

    makeCellElement.textContent = make;
    modelCellElement.textContent = model;
    yearCellElement.textContent = year;
    fuelCellElement.textContent = fuel;
    originalCostCellElement.textContent = cost;
    sellingPriceCellElement.textContent = price;


    makeElement.value = ''
    modelElement.value = ''
    yearElement.value = ''
    fuelElement.value = ''
    originalCostElement.value = ''
    sellingPriceElement.value = ''


    editButtonElement.classList = 'action-btn edit';
    sellButtonElement.classList = 'action-btn sell';
    editButtonElement.textContent = 'Edit';
    sellButtonElement.textContent = 'Sell';

    buttonsCell.appendChild(editButtonElement);
    buttonsCell.appendChild(sellButtonElement);

    rowElement.appendChild(makeCellElement);
    rowElement.appendChild(modelCellElement);
    rowElement.appendChild(yearCellElement);
    rowElement.appendChild(fuelCellElement);
    rowElement.appendChild(originalCostCellElement);
    rowElement.appendChild(sellingPriceCellElement);
    rowElement.appendChild(buttonsCell);

    tableBodyElement.appendChild(rowElement);

    editButtonElement.addEventListener('click', (e) => {

      makeElement.value = make;
      modelElement.value = model;
      yearElement.value = year;
      fuelElement.value = fuel;
      originalCostElement.value = cost;
      sellingPriceElement.value = price;
      
      e.target.parentElement.parentElement.remove();
  
    });
  
  
    sellButtonElement.addEventListener('click', (e) => {
      let carsListElement = document.getElementById('cars-list');
      let eachListElement = document.createElement('li');
      let modelSpanElement = document.createElement('span');
      let yearSpanElement = document.createElement('span');
      let priceDifSpanElement = document.createElement('span');
  
      eachListElement.classList = 'each-list';
      modelSpanElement.textContent = `${make} ${model}`;
      yearSpanElement.textContent = `${year}`;
      priceDifSpanElement.textContent = `${Number(price) - Number(cost)}`;
  
      e.target.parentElement.parentElement.remove();
  
      eachListElement.appendChild(modelSpanElement);
      eachListElement.appendChild(yearSpanElement);
      eachListElement.appendChild(priceDifSpanElement);
      carsListElement.appendChild(eachListElement);
  
      let profitElement = document.getElementById('profit');
      let totalProfit = Number(profitElement.textContent) + Number(priceDifSpanElement.textContent);
      profitElement.textContent = totalProfit.toFixed(2);
    });

  });
  
}
