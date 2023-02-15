function focused() {
    let inputElements = Array.from(document.querySelectorAll('input[type = "text"]'));

    inputElements.forEach(el => el.addEventListener('focus', (e) => {
        e.target.parentNode.classList.add('focused');
    }));
    inputElements.forEach(el => el.addEventListener('blur', (e) => {
        e.target.parentNode.classList.remove('focused');
    }));
   
}