const form = document.querySelector('#home-page form');
const homePage = document.querySelector('#home-page');

const url = 'http://localhost:3030/jsonstore/collections/myboard/posts';


async function createPost(e) {
    e.preventDefault();
    const formData = new FormData(form);

    if (e.submitter.className == 'cancel') {
        e.preventDefault();
        e.target.reset();
    } else {

        const topicName = formData.get('topicName');
        const username = formData.get('username');
        const postText = formData.get('postText');
        const date = '11/01/2022';

        if (username == '' || topicName == '') {
            return alert('All fields are required!');
        }

        const postElement = document.createElement('div');
        postElement.classList = 'topic-container';
        postElement.innerHTML = `
        <div class="topic-name-wrapper">
        <div class="topic-name">
        <a href="#" class="normal">
        <h2>${topicName}</h2>
        </a>
        <div class="columns">
        <div>
        <p>Date: <time>${date}</time></p>
        <div class="nick-name">
        <p>Username: <span>${username}</span></p>
        </div>
        </div>
        </div>
        </div>
        </div>
        `;

        homePage.appendChild(postElement)

        const resp = await fetch(url, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ username, topicName, date, postText }),
        });
    }

}

export {
    createPost,
}