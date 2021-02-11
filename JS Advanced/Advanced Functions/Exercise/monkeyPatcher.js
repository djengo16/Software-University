function solution(cmd){

    if(cmd === 'upvote'){
        this.upvotes +=1;
    }else if(cmd === 'downvote'){
        this.downvotes +=1;
    }else{
        //report [upvotes,downvotes,difference,rating]
        let totalVotes = this.upvotes + this.downvotes;

        let balance = this.upvotes - this.downvotes;
        let rating = findRating(totalVotes,this.upvotes);
        let valueToAdd = 0;

        if(totalVotes > 50){
            let greaterVote = this.upvotes > this.downvotes ? this.upvotes : this.downvotes;
            valueToAdd = Math.ceil(greaterVote * 0.25);
        }

        function findRating(total,upv){
            if(total < 10){
                return 'new';
            }
            if(balance < 0){
                return 'unpopular';
            }
            if((upv / total) * 100 > 66){
                return 'hot';
            }
            return 'controversial';
        }
        return [this.upvotes + valueToAdd,this.downvotes + valueToAdd,balance,rating];
    }
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
solution.call(post, 'upvote');
solution.call(post, 'downvote');
let score = solution.call(post, 'score'); // [127, 127, 0, 'controversial']
console.log(score);
for(let i = 0; i < 50; i++){
    solution.call(post, 'downvote'); 
} 
score = solution.call(post, 'score');
console.log(score);   // [139, 189, -50, 'unpopular']