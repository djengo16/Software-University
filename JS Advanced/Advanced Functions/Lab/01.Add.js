function solution(num){
    return (num2) => num + num2;
}
let add7 = solution(7);
console.log(add7(2));
console.log(add7(3));

