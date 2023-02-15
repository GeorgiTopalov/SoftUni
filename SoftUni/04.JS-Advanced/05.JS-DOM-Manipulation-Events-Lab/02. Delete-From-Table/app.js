function deleteByEmail() {
    let inputElement = document.querySelector('[name = "email"]');
    let emailCellElements = document.querySelectorAll('tr td:nth-of-type(2)');
    let resultElement = document.getElementById('result');

    for (let email of emailCellElements) {
        if (inputElement.value == email.textContent){
            resultElement.textContent = 'Deleted.'
            email.parentNode.remove();
            break;
        }
    }

    if (resultElement.textContent != 'Deleted.'){
        resultElement.textContent = 'Not found.'
    }
    
}