function subtract() {
    let firstNumberElement = document.getElementById('firstNumber');
    let secondNumberElement = document.getElementById('secondNumber');
    let substractionOfNumbers = Number(firstNumberElement.value) - Number(secondNumberElement.value);

    let resultElement = document.getElementById('result');
    resultElement.textContent = substractionOfNumbers;
}