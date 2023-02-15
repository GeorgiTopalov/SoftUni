function toggle() {
    
    let buttonElement = document.querySelector('.button');
    let hiddenTextElement = document.getElementById('extra');

    if (hiddenTextElement.style.display == 'block'){
        buttonElement.textContent = 'More';
        hiddenTextElement.style.display = 'none';
    }else{
        buttonElement.textContent = 'Less';
        hiddenTextElement.style.display = 'block';
    }
}