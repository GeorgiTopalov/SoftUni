window.addEventListener("load", solve);

function solve() {

  let publishButtonElement = document.getElementById('publish-btn');
  let clearButtonElement = document.getElementById('clear-btn');

  publishButtonElement.addEventListener('click', (e)=>{
    
    let titleElement = document.getElementById('post-title');
    let categoryElement = document.getElementById('post-category');
    let contentElement = document.getElementById('post-content');
    let rpostUlElement = document.getElementById('review-list');

    let title = titleElement.value;
    let category = categoryElement.value;
    let content = contentElement.value;

    if (title == '' || category == '' || content == ''){
      return;
    }

    titleElement.value = '';
    categoryElement.value = '';
    contentElement.value = '';

    let postLi = document.createElement('li');
    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    let categoryP = document.createElement('p');
    let contentP = document.createElement('p');

    postLi.classList = 'rpost';
    h4.textContent = title;
    categoryP.textContent = `Category: ${category}`;
    contentP.textContent = `Content: ${content}`;

    let editButton = document.createElement('button');
    let approveButton = document.createElement('button');
    editButton.textContent = 'Edit';
    approveButton.textContent = 'Approve';

    editButton.classList = 'action-btn edit';
    approveButton.classList = 'action-btn approve';

    editButton.addEventListener('click', (e)=>{
      titleElement.value = title;
      categoryElement.value = category;
      contentElement.value= content;

      e.target.parentElement.remove();
    });

    approveButton.addEventListener('click', (e)=>{
      let publishedList = document.getElementById('published-list');

      postLi.removeChild(editButton);
      e.target.remove();

      publishedList.appendChild(postLi);
    });

    article.appendChild(h4);
    article.appendChild(categoryP);
    article.appendChild(contentP);
    postLi.appendChild(article);
    postLi.appendChild(approveButton);
    postLi.appendChild(editButton);
    rpostUlElement.appendChild(postLi);
  });

  clearButtonElement.addEventListener('click', ()=>{
    let publishedList = document.getElementById('published-list');

    publishedList.textContent = '';
  });
}
