function extract(arr){
    let max = Number.MIN_SAFE_INTEGER;

    let result = arr.filter(num => {
       if(num >= max){
           max = num;
           return true;
       }
       return false
    });
    result.forEach(x => console.log(x));
}

extract([20, 
    3, 
    2, 
    15,
    6, 
    1]    
    );