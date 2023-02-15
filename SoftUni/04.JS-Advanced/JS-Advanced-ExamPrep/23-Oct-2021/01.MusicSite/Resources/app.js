window.addEventListener('load', solve);

function solve() {
    let addBtn = document.getElementById('add-btn');
    let genreElement = document.getElementById('genre');
    let nameElement = document.getElementById('name');
    let authorElement = document.getElementById('author');
    let dateElement = document.getElementById('date');
    let allHitsContainer = document.querySelector('.all-hits-container');

    let allInputs = [genreElement, nameElement, authorElement, dateElement];

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();

        if (allInputs.some(x => x.value == '')){
            return;
        }

        let hitsInfo = document.createElement('div');
        let img = document.createElement('img');
        let genre = document.createElement('h2')
        let name = document.createElement('h2')
        let author = document.createElement('h2')
        let date = document.createElement('h3')

        hitsInfo.classList = 'hits-info';
        img.src = './static/img/img.png';
        genre.textContent = `Genre: ${allInputs[0].value}`;
        name.textContent = `Name: ${allInputs[1].value}`;
        author.textContent = `Author: ${allInputs[2].value}`;
        date.textContent = `Date: ${allInputs[3].value}`;

        let saveBtn = document.createElement('button');
        let likeBtn = document.createElement('button');
        let deleteBtn = document.createElement('button');

        saveBtn.classList = 'save-btn';
        likeBtn.classList = 'like-btn';
        deleteBtn.classList = 'delete-btn';

        saveBtn.textContent = 'Save song';
        likeBtn.textContent = 'Like song';
        deleteBtn.textContent = 'Delete';

        hitsInfo.appendChild(img);
        hitsInfo.appendChild(genre);
        hitsInfo.appendChild(name);
        hitsInfo.appendChild(author);
        hitsInfo.appendChild(date);
        hitsInfo.appendChild(saveBtn);
        hitsInfo.appendChild(likeBtn);
        hitsInfo.appendChild(deleteBtn);

        allHitsContainer.appendChild(hitsInfo);

        likeBtn.addEventListener('click', (e) =>{
                let likesElement = document.querySelector('.likes p');

                let currentLikes = Number(likesElement.textContent.split(' ')[2]);
                currentLikes++;

                likesElement.textContent = `Total Likes: ${currentLikes}`;

                e.target.disabled = true;
        });

        saveBtn.addEventListener('click', (e) =>{
            hitsInfo.removeChild(saveBtn);
            hitsInfo.removeChild(likeBtn);

            let savedContainer = document.querySelector('.saved-container');
            savedContainer.appendChild(hitsInfo);
        });

        deleteBtn.addEventListener('click', (e)=>{
            e.target.parentNode.remove();
        });
    });
}