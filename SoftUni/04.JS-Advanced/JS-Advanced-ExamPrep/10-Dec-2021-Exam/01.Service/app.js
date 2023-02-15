window.addEventListener('load', solve);

function solve() {
    let submitButton = document.querySelector('button[type = "submit"]');
    let typeProduct = document.getElementById('type-product');
    let description = document.getElementById('description');
    let clientName = document.getElementById('client-name');
    let clientPhone = document.getElementById('client-phone');

    let receivedOrders = document.getElementById('received-orders');
    let completedOrders = document.getElementById('completed-orders');
    let clearButton = document.querySelector('.clear-btn');

    let allInput = [typeProduct, description, clientName, clientPhone];

    submitButton.addEventListener('click', (e)=>{
        e.preventDefault();
        if (allInput.some(x => x.value == '')){
            return;
        }

        let divContainer = document.createElement('div');
        divContainer.classList = 'container';
        
        let h2 = document.createElement('h2');
        let h3 = document.createElement('h3');
        let h4 = document.createElement('h4');
        h2.textContent = `Product type for repair: ${allInput[0].value}`;
        h3.textContent = `Client information: ${allInput[2].value}, ${allInput[3].value}`;
        h4.textContent = `Description of the problem: ${allInput[1].value}`;

        let startBtn = document.createElement('button');
        let finishBtn = document.createElement('button');
        startBtn.classList = 'start-btn';
        finishBtn.classList = 'finish-btn';
        startBtn.textContent = 'Start repair';
        finishBtn.textContent = 'Finish repair';
        finishBtn.disabled = true;

        let allDivElements = [h2, h3, h4, startBtn, finishBtn];

        for (const element of allDivElements) {
        divContainer.appendChild(element);
        }

        receivedOrders.appendChild(divContainer);

        startBtn.addEventListener('click', (e)=>{
            e.target.disabled = true;
            finishBtn.disabled = false;
        });
        finishBtn.addEventListener('click', (e)=>{
            completedOrders.appendChild(divContainer);
            divContainer.removeChild(startBtn);
            divContainer.removeChild(finishBtn);
        });

        for(let i=1; i < allInput.length; i++){
            allInput[i].value= '';
        }
    });

    clearButton.addEventListener('click', (e)=>{
        let divContainerElements = completedOrders.getElementsByTagName('div');
        
        for (let i = 0; i < divContainerElements.length; i++) {
            divContainerElements[i].remove();
            i--;
        }
    });
}