function attachEvents() {
    const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';

    const loadBtn = document.getElementById('btnLoadPosts');
    const viewBtn = document.getElementById('btnViewPost');
    const posts = document.getElementById('posts');

    loadBtn.addEventListener('click', async (e) => {

        while (posts.firstChild){
            posts.removeChild(posts.firstChild);
        }
        const postsResponse = await fetch(postsUrl);
        const postsData = await postsResponse.json();

        for (const key in postsData) {

            const option = document.createElement('option');
            option.value = key;
            option.textContent = postsData[key].title;

            posts.appendChild(option);
        }
    });

    viewBtn.addEventListener('click', async (e) => {
        const postTitle = document.getElementById('post-title');
        const postBody = document.getElementById('post-body');
        const postComments = document.getElementById('post-comments');

        postComments.innerHTML = ''

        const currentPostId = posts.value;
        const commentsUrl = `http://localhost:3030/jsonstore/blog/comments`;
        const commentsResponse = await fetch(commentsUrl);
        const commentsData = await commentsResponse.json();

        const postsUrl = `http://localhost:3030/jsonstore/blog/posts/${currentPostId}`;
        const postsResponse = await fetch(postsUrl);
        const postsData = await postsResponse.json();

        console.log(postsData);
        postTitle.textContent = postsData.title;
        postBody.textContent = postsData.body;

        for (const key in commentsData) {
            if (commentsData[key].postId == currentPostId) {
                const comment = document.createElement('li');
                comment.id = commentsData[key].postId;
                comment.textContent = commentsData[key].text;
                postComments.appendChild(comment);
            }
        }
    });

}

attachEvents(); 

