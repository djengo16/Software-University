function getArticleGenerator(articles) {

    function returnArticle(){
        if(articles.length != 0){
        let article = document.createElement('article');
        article.textContent = articles.shift();
        document.querySelector('#content').appendChild(article);
        }
    }
    return returnArticle;
}
