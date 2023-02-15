function colorize() {
    let tableElements = document.querySelectorAll('tr:nth-of-type(2n)');

    for (const element of tableElements) {

        element.style.backgroundColor = 'Teal';
    }
    
}