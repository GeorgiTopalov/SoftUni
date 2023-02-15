function solve() {
  let textValue = document.getElementById('text');
  let conventionTypeValue = document.getElementById('naming-convention');

  let textArray = textValue.value.toLowerCase().split(' ');
  let stringResult = '';
  
    for (i = 0; i < textArray.length; i++){
      if (i == 0){
        if (conventionTypeValue.value == 'Camel Case'){
          stringResult += textArray[0];
        }else if (conventionTypeValue.value == 'Pascal Case'){
          stringResult += textArray[0].charAt(0).toUpperCase() + textArray[i].slice(1);
        }else{
          stringResult = 'Error!';
          break;
        }
      }else{
        stringResult += textArray[i].charAt(0).toUpperCase() + textArray[i].slice(1);
      }
    }
    
    let resultElement = document.getElementById('result');
    resultElement.textContent = stringResult;
}