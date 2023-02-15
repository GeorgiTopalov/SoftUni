function addItem() {
    let inputElement = document.getElementById('newItemText');
    let outputLiElement = document.createElement('li');
    let itemsUlElement = document.getElementById('items');

    outputLiElement.textContent = inputElement.value;

    let deleteElement = document.createElement('a');
    deleteElement.href = '#';
    deleteElement.textContent = '[Delete]';
    deleteElement.addEventListener('click', (e) => {
        e.currentTarget.parentNode.remove();
    });

    outputLiElement.appendChild(deleteElement);

    itemsUlElement.appendChild(outputLiElement);
}