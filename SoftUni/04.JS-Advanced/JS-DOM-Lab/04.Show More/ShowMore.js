function showText() {
    let moreElement = document.getElementById('more');
    moreElement.style.display = 'none';
    let textElement = document.getElementById('text');
    textElement.style.display = 'inline';
    moreElement.value = textElement.textContent;
}