function calculator() {
    let numberOneElement;
    let numberTwoElement;
    let resultElement;

    return obj = {

        init(selector1, selector2, resultSelector) {
             numberOneElement = document.querySelector(selector1);
             numberTwoElement = document.querySelector(selector2);
             resultElement = document.querySelector(resultSelector);

        },
        add() {
            resultElement.value = Number(numberOneElement.value) + Number(numberTwoElement.value);
        },
        subtract() {
            resultElement.value = Number(numberOneElement.value) - Number(numberTwoElement.value);
        },
    };

}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');




