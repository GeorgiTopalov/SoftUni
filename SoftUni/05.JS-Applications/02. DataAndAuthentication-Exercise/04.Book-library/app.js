function solve() {
    function bookLibrary() {
        document.getElementById('loadBooks').addEventListener('click', loadAllBooks);
    
        document.getElementById('create-form').addEventListener('submit', createBook);
    
        document.querySelector('table').addEventListener('click', handleTableClick);
        document.getElementById('edit-form').style.display = 'none';
        document.getElementById('edit-form').addEventListener('submit', updateBook);
    
    
    }
    
    bookLibrary();
    
    async function request(url, options) {
        const response = await fetch(url, options);
    
        if (response.ok != true) {
            const error = await response.json();
            alert(error.message);
            throw new Error(error.message);
        }
    
        const data = await response.json();
        return data;
    }
    
    async function loadAllBooks() {
        const books = await request('http://localhost:3030/jsonstore/collections/books');
    
        const rows = Object.entries(books).map(createRow).join('');
    
        document.querySelector('body > table > tbody').innerHTML = rows;
    }
    
    function handleTableClick(e) {
        if (e.target.className == 'deleteBtn') {
            deleteBook(e.target.parentNode.parentNode.id);
        } else if (e.target.className == 'editBtn') {
            document.getElementById('create-form').style.display = 'none';
            document.getElementById('edit-form').style.display = 'block';
    
            loadBookForEditting(e.target.parentNode.parentNode.id);
        }
    }
    
    function createRow([id, book]) {
    
        return `<tr id="${id}"><td>${book.title}</td> <td>${book.author}</td> <td><button class="editBtn">Edit</button><button class="deleteBtn">Delete</button></td></tr>`;
    }
    
    async function createBook(e) {
        e.preventDefault();
    
        var formData = new FormData(e.target);
    
        const title = formData.get('title');
        const author = formData.get('author');
    
        if (title && author) {
            const book = { title: title, author: author };
    
            e.target.reset();
    
            await request('http://localhost:3030/jsonstore/collections/books', {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(book),
            });
    
            
            await loadAllBooks();
        }
    }
    
    async function updateBook(e) {
        e.preventDefault();
    
        var formData = new FormData(event.target);
    
        const id = formData.get('id');
        const title = formData.get('title');
        const author = formData.get('author');
    
        if (title && author) {
            const book = { title: title, author: author };
    
            event.target.reset();
    
            await request(`http://localhost:3030/jsonstore/collections/books/${id}`, {
                method: 'put',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(book),
            });
    
            document.getElementById('create-form').style.display = 'block';
            document.getElementById('edit-form').style.display = 'none';
    
            
            await loadAllBooks();
        }
    }
    
    async function deleteBook(id) {
        await request(`http://localhost:3030/jsonstore/collections/books/${id}`, {
            method: 'delete',
        });
    
        
        await loadAllBooks();
    }
    
    async function loadBookForEditting(bookId) {
        const book = await request(`http://localhost:3030/jsonstore/collections/books/${bookId}`);
    
        document.querySelector('#edit-form [name="id"]').value = bookId;
        document.querySelector('#edit-form [name="title"]').value = book.title;
        document.querySelector('#edit-form [name="author"]').value = book.author;
    }
    
    function createElement(type, content, attributes = []) {
        const element = document.createElement(type);
    
        if (content) {
            element.textContent = content;
        }
    
        if (attributes.length > 0) {
            element.setAttribute(attributes[0], attributes[1]);
        }
    
        return element;
    }
}

solve();