function solve(){
    class Post{
        constructor(title, content){
            this.title = title,
            this.content = content
        }

        toString(){
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post{
        constructor(title, content, likes, dislikes){
            super(title, content)
            this.likes = likes,
            this.dislikes = dislikes,
            this.comments = []
        }

        addComment(comment){
            this.comments.push(comment);
        }

        toString(){
            let baseStr = super.toString();
            baseStr += `\nRating: ${ this.likes - this.dislikes}`;

            if(this.comments.length != 0){
                baseStr += "\nComments:\n";
                baseStr += this.comments.map(c => {
                    return ` * ${c}`
                }).join('\n');
            }
            return baseStr;
        }
    }

    class BlogPost extends Post{
        constructor(title, content, views){
            super(title, content)
            this.views = views
        }

        view(){
            this.views ++;
           return this;
        }

        toString(){
            let baseStr = super.toString();
            baseStr += `\nViews: ${this.views}`;
            return baseStr;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}
let classes = solve();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);
let blg = new classes.BlogPost('BlogPostTitle','Some text content..',4);
let test = new classes.BlogPost("TestTitle", "TestContent", 5);
blg.view().view().view();
console.log(blg.views);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());
