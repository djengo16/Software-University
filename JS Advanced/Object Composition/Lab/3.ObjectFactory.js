function solve (obj){
    let parsed = JSON.parse(obj);

    let result =  parsed.reduce((acc,x) => {
        acc = {...acc,...x}
        return acc;
    },{});
    
    return result;
}

console.log(solve(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`));