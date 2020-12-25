function sortByTwoCriteria(arr){
arr.sort((a, b) => {
    if(a.length > b.length){
        return 1;
    }
    else if (a.length === b.length){
      return  a.localeCompare(b);
    }
    else{
        return -1;
    }
});
    arr.forEach(x => console.log(x));
}

sortByTwoCriteria(['test', 
'Deny', 
'omen', 
'Default']
);