function solve(input){
let result = {};
for(let i = 0; i < input.length;i+=2){
    if(input[i] in result){
        result[input[i]] += JSON.parse(input[i+1]);
    }else{
        result[input[i]] = JSON.parse(input[i+1]);
    }
}
console.log(JSON.stringify(result));
}

solve(['Sofia','20','Varna','3','sofia','5','varna','4']);