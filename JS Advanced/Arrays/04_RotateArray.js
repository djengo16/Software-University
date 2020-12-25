function solve(arr){
let count = parseInt(arr.pop());
if(count > arr.length){
    count %= arr.length;
}
    for(let i = 0;i < count;i++ ){
        arr.unshift(arr.pop());
    }

    let output = arr.join(' ');
    console.log(output);
}

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']
)