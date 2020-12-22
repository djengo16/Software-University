function solve(number) {
    let sum = 0;
    let lastNum = number % 10;
    let isSame = true;
    while (number / 10 > 0) {
        let currentNum = number % 10;
        sum+=currentNum;
        if(lastNum != currentNum){
            isSame = false;
        }
        lastNum = currentNum;
        number = Math.floor(number / 10);
    }
    console.log(isSame);
    console.log(sum);
}

solve(2232);