function solve(arr){
let separator = arr.pop();
let result = arr.join(separator);
console.log(result);
}

solve(['One', 
'Two', 
'Three', 
'Four', 
'Five', 
'-']
);