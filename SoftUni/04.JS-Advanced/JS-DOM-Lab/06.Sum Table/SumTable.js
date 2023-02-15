function sumTable() {
let priceElements = document.querySelectorAll('tr td:nth-of-type(2)');
let sum = 0;
for (let i = 0; i < priceElements.length - 1; i++){
    sum+= Number(priceElements[i].textContent);
}
let sumElement = document.getElementById('sum');
sumElement.textContent = sum;
}