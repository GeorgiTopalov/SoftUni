function getArticleGenerator(input) {

    let articles = input;
    let contentElement = document.getElementById('content');

    return () =>{

        if (articles.length > 0){

            let newArticleElement = document.createElement('article');
            newArticleElement.innerText = articles.shift();

            contentElement.appendChild(newArticleElement);
        }
    }

}
