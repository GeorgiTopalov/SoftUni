function solve() {
    let addButtonElement = document.getElementById('add');
    let resetButtonElement = document.getElementById('reset');
    let listElement = document.getElementById('list');
    let sentListElement = document.querySelector('.sent-list');
    let deleteListElement = document.querySelector('.delete-list');

    let recipientElement = document.getElementById('recipientName');
    let titleElement = document.getElementById('title');
    let messageElement = document.getElementById('message');

    addButtonElement.addEventListener('click', (e) => {
        e.preventDefault();


        let recipient = recipientElement.value;
        let title = titleElement.value;
        let message = messageElement.value;

        if (recipient == '' || title == '' || message == '') {
            return;
        }

        let liElement = document.createElement('li');
        let h4Title = document.createElement('h4');
        let h4recipient = document.createElement('h4');
        let span = document.createElement('span');

        h4Title.textContent = `Title: ${title}`;
        h4recipient.textContent = `Recipient Name: ${recipient}`;
        span.textContent = message;

        let divListAction = document.createElement('div');
        divListAction.classList = 'list-action';

        let sendButton = document.createElement('button');
        let deleteButton = document.createElement('button');

        sendButton.type = 'submit';
        sendButton.id = 'send';
        sendButton.textContent = 'Send';

        deleteButton.type = 'submit';
        deleteButton.id = 'delete';
        deleteButton.textContent = 'Delete';

        divListAction.appendChild(sendButton);
        divListAction.appendChild(deleteButton);

        liElement.appendChild(h4Title);
        liElement.appendChild(h4recipient);
        liElement.appendChild(span);
        liElement.appendChild(divListAction);

        listElement.appendChild(liElement);



        deleteButton.addEventListener('click', (e) => {
            e.preventDefault();
            deleteListElement.appendChild(e.target.parentNode.parentNode);
            e.target.parentNode.remove();
        });

        sendButton.addEventListener('click', (e) => {
            e.preventDefault();

            let newLi = document.createElement('li');
            let recipientSpan = document.createElement('span');
            let titleSpan = document.createElement('span');
            let buttonDiv = document.createElement('div');
            buttonDiv.classList = 'btn';

            recipientSpan.textContent = `To: ${recipient}`;
            titleSpan.textContent = `Title: ${title}`;

            let deleteMailButton = document.createElement('button');
            deleteMailButton.textContent = 'Delete';
            deleteMailButton.type = 'submit';
            deleteMailButton.classList = 'delete';

            buttonDiv.appendChild(deleteMailButton);
            newLi.appendChild(recipientSpan);
            newLi.appendChild(titleSpan);
            newLi.appendChild(buttonDiv);
            sentListElement.appendChild(newLi);


            e.target.parentNode.parentNode.remove();

            deleteMailButton.addEventListener('click', (e) => {
                deleteListElement.appendChild(e.target.parentNode.parentNode);
                e.target.remove();
            });
        });

    });

    resetButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        recipientElement.value = '';
        titleElement.value = '';
        messageElement.value = '';


    });
}
solve()