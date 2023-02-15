function lockedProfile() {
    let buttonsElements = Array.from(document.querySelectorAll('.profile button'));


    buttonsElements.forEach(el => el.addEventListener('click', (e) => {

        let lockedElement = e.target.parentNode.querySelector('input:first-of-type');

        console.log('first');
        if (lockedElement.checked === false) {
            console.log('second');

            let hiddenDiv = e.target.parentNode.querySelector('div');
            if (e.target.textContent === 'Show more') {
                hiddenDiv.style.display = 'block';
                e.target.textContent = 'Hide it';
            } else {
                hiddenDiv.style.display = 'none';
                e.target.textContent = 'Show more';
            }
        }
    }));
}