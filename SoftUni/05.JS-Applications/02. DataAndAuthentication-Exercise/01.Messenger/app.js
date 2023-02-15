function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/messenger';

    const allMessages = document.getElementById('messages');


    const sendBtn = document.getElementById('submit').addEventListener('click', async (e) => {

        const author = document.querySelector('input[name="author"]');
        const message = document.querySelector('input[name="content"]');
        if (author.value === '' || message.value === ''){
            return;
        }
        await request(url, {author: author.value, content: message.value});
    });

    const loadBtn = document.getElementById('refresh').addEventListener('click', async (e) => {
        const res = await fetch(url);
        const data = await res.json();

        allMessages.value = Object.values(data).map(({ author, content }) => `${author}: ${content}`).join('\n');
    });

    async function request(url, data) {
        if (data) {
            data = {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            };
        }

        const response = await fetch(url, data);
        return response.json();
    }
}

attachEvents();