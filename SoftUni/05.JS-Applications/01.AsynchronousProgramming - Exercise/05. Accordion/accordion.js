async function solution() {
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const titlesResponse = await fetch (url);
    const titlesData = await titlesResponse.json();
    const infoResponse = await fetch
    const mainDiv = document.getElementById('main');

    Object.values(titlesData).forEach(async a  =>{
        const currentUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${a._id}`;
        const response = await fetch (currentUrl);
        const data = await response.json();

        console.log(data);

        const accordion = document.createElement('div');
        accordion.classList = 'accordion';
        const divHead = document.createElement('div');
        divHead.classList = 'head';
        const span = document.createElement('span');
        span.textContent = `${a.title}`;
        const button = document.createElement('button');
        button.classList = 'button';
        button.id = `${a._id}`;
        button.textContent = 'More';

        const extraDiv = document.createElement('div');
        extraDiv.classList = 'extra';
        p = document.createElement('p');
        p.textContent = `${data.content}`;

        button.addEventListener('click', show);

        divHead.appendChild(span);
        divHead.appendChild(button);
        extraDiv.appendChild(p);
        accordion.appendChild(divHead);
        accordion.appendChild(extraDiv);

        mainDiv.appendChild(accordion);
    });

    function show(event){
        if (event.target.textContent === 'More'){
            event.target.parentNode.parentNode.lastChild.style.display = 'block';
            event.target.textContent = 'Less';
        }else{
            event.target.parentNode.parentNode.lastChild.style.display = 'none';
            event.target.textContent = 'More';
        }
    }
}

