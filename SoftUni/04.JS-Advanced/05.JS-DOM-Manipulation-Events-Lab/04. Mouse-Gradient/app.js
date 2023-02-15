function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', (e) => {
        let percentage = Math.trunc(e.offsetX / (e.target.offsetWidth-1) * 100);
        resultElement.textContent = `${percentage}%`; 
        
    });
    gradientElement.addEventListener('mouseout', (e) => {
        resultElement.textContent = ''; 
    });
}