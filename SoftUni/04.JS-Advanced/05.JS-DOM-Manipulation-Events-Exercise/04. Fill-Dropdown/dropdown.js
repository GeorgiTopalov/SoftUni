function addItem() {
    let newItemTextElement = document.getElementById('newItemText');
    let newItemValueElement = document.getElementById('newItemValue');

    let newElement = document.createElement('option');
    newElement.textContent = newItemTextElement.value;
    newElement.value = newItemValueElement.value;

    document.getElementById('menu').appendChild(newElement);

    newItemTextElement.value = '';
    newItemValueElement.value = '';
}