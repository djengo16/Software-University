function solve(arr,sortCriterion){
    let tickets = [];
    
    arr.forEach(x => {
      [destination, price, status] = x.split("|");
      price = Number(price);
        tickets.push({ destination, price, status });
    })
    let sorted;
    if (sortCriterion === "destination") {
      sorted = tickets.sort((curr, next) =>
        curr.destination.localeCompare(next.destination)
      );
    } else if (sortCriterion === "price") {
      sorted = tickets.sort((curr, next) => curr.price - next.price);
    } else {
      sorted = tickets.sort((curr, next) =>
        curr.status.localeCompare(next.status)
      );
    }
    return sorted;
}

let output = solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
);
console.log(output);