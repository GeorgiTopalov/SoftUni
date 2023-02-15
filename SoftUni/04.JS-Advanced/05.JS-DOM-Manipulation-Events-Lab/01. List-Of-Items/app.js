function addItem() {
    let inputElement = document.getElementById('newItemText');
    let outputLiElement = document.createElement('li');

    let itemsUlElement = document.getElementById('items');

    outputLiElement.textContent = inputElement.value;

    itemsUlElement.appendChild(outputLiElement);
}