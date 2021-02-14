function solve(input){

    let recs = input.map(([width,height]) => ({
        width,
        height,
        area: () => width * height,
        compareTo: function(other) {
            let result  = other.area() - this.area();

            return result == 0
            ?  other.width - this.width
            : result;
        }       
    }));
    return recs.sort((a, b) => a.compareTo(b));
}

console.log(solve([[1,20],[20,1],[5,3],[5,3]]));