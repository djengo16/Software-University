function getArticleGenerator(articles) {
    let initialArticles = articles;

    function returnArticle(){
        if(initialArticles.length != 0){
        let article = document.createElement('article');
        article.textContent = initialArticles.shift();
        document.querySelector('#content').appendChild(article);
        }
    }
    return returnArticle;
}
