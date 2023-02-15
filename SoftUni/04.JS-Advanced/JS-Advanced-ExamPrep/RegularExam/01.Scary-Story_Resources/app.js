window.addEventListener("load", solve);

function solve() {
  let firstName = document.getElementById('first-name');
  let lastName = document.getElementById('last-name');
  let age = document.getElementById('age');
  let storyTitle = document.getElementById('story-title');
  let genre = document.getElementById('genre');
  let story = document.getElementById('story');
  let previewList = document.getElementById('preview-list');
  let main = document.getElementById('main');

  let allInputs = [firstName, lastName, age, storyTitle, genre, story];


  let publishBtn = document.getElementById('form-btn');
  publishBtn.addEventListener('click', () => {


    if (allInputs.some(x => x.value == '')) {
      return;
    }

    let fN = firstName.value;
    let lN = lastName.value;
    let a = age.value;
    let titl = storyTitle.value;
    let gen = genre.value;
    let stor = story.value;

    let li = document.createElement('li');
    let article = document.createElement('article');
    li.classList = 'story-info';

    let nameH4 = document.createElement('h4');
    let ageP = document.createElement('p');
    let titleP = document.createElement('p');
    let genreP = document.createElement('p');
    let p = document.createElement('p');


    nameH4.textContent = `Name: ${firstName.value} ${lastName.value}`;
    ageP.textContent = `Age: ${age.value}`;
    titleP.textContent = `Title: ${storyTitle.value}`;
    genreP.textContent = `Genre: ${genre.value}`;
    p.textContent = stor;

    let saveBtn = document.createElement('button');
    let editBtn = document.createElement('button');
    let deleteBtn = document.createElement('button');

    saveBtn.classList = 'save-btn';
    editBtn.classList = 'edit-btn';
    deleteBtn.classList = 'delete-btn';

    saveBtn.textContent = 'Save Story';
    editBtn.textContent = 'Edit Story';
    deleteBtn.textContent = 'Delete Story';

    article.appendChild(nameH4);
    article.appendChild(ageP);
    article.appendChild(titleP);
    article.appendChild(genreP);
    article.appendChild(p);
    li.appendChild(article);
    li.appendChild(saveBtn);
    li.appendChild(editBtn);
    li.appendChild(deleteBtn);
    previewList.appendChild(li);

    publishBtn.disabled = true;



    allInputs.forEach(x => x.value = '');


    saveBtn.addEventListener('click', () => {
      main.innerHTML = '';

      let h1 = document.createElement('h1');
      h1.textContent = 'Your scary story is saved!';

      main.appendChild(h1);
    });

    deleteBtn.addEventListener('click', (e) => {
      e.target.parentNode.parentNode.remove();
      publishBtn.disabled = false;

    });

    editBtn.addEventListener('click', (e) => {
      firstName.value = fN;
      lastName.value = lN;
      age.value = a;
      storyTitle.value = titl;
      genre.value = gen;
      story.value = stor;

      e.target.parentNode.parentNode.remove();
      publishBtn.disabled = false;
    });
  });
}
