function solve() {
    let taskElement = document.getElementById('task');
    let descriptionElement = document.getElementById('description');
    let dateElement = document.getElementById('date');
    let addButtonElement = document.getElementById('add');

    let open = document.getElementsByTagName('section')[1];
    let inProgress = document.getElementsByTagName('section')[2];
    let complete = document.getElementsByTagName('section')[3];

    addButtonElement.addEventListener('click', e => {
        e.preventDefault();

        if (taskElement.value !== '' || descriptionElement.value !== '' || dateElement.value !== ''){

            let newArticle = document.createElement('article');
            let articleH3 = document.createElement('h3');
            articleH3.textContent = taskElement.value;
            let articleDesc = document.createElement('p');
            articleDesc.textContent = 'Description: '+ descriptionElement.value;
            let articleDate = document.createElement('p');
            articleDate.textContent = 'Due Date: '+ dateElement.value;

            let buttonsDiv = document.createElement('div');
            buttonsDiv.className = 'flex';
            let greenButton = document.createElement('button');
            greenButton.textContent = 'Start';
            greenButton.className = 'green'; 
            let redButton = document.createElement('button');
            redButton.textContent = 'Delete';
            redButton.className = 'red'; 

            buttonsDiv.appendChild(greenButton);
            buttonsDiv.appendChild(redButton);

           

            redButton.addEventListener('click', () => {
                newArticle.remove();
            });

            newArticle.appendChild(articleH3);
            newArticle.appendChild(articleDesc);
            newArticle.appendChild(articleDate);
            newArticle.appendChild(buttonsDiv);


            open.children[1].appendChild(newArticle);
           

            greenButton.addEventListener('click', (e) => {
                inProgress.children[1].appendChild(newArticle);
                let finishButton = document.createElement('button');

                finishButton.textContent = 'Finish';
                finishButton.className = 'orange';
              
                greenButton.remove();
                buttonsDiv.appendChild(finishButton);

                finishButton.addEventListener('click', ()=>{
                    complete.children[1].appendChild(newArticle);
                    buttonsDiv.remove();
                });

            });

        }
    });

    
}