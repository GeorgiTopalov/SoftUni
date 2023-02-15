function solve() {

   let buttonElements = Array.from(document.getElementsByTagName('button'));
   let textArea = document.getElementsByTagName('textarea')[0];
   let productsList = [];
   let sumTotal = 0;

   buttonElements.forEach(el => el.addEventListener('click', (e) => {
      if (e.target.className == 'add-product') {
         let price = e.target.parentElement.nextElementSibling.innerHTML;
         let productName = e.target.parentElement.previousElementSibling.children[0].innerHTML;

         if (!productsList.includes(productName)) {
            productsList.push(productName);
         }

         sumTotal += Number(price);

         textArea.value += `Added ${productName} for ${price} to the cart.\n`;
      } else if(e.target.className == 'checkout'){
         buttonElements.forEach(el => el.setAttribute('disabled', 'true'));
         textArea.value += `You bought ${productsList.join(', ')} for ${sumTotal.toFixed(2)}.`
      }
   }));
}


