function solve(){
    let argTypes = {
    };

    for (let arg of arguments) {
        const type = typeof arg;
        console.log(`${type}: ${arg}`);
        if(!argTypes.hasOwnProperty(type)){
            argTypes[type] = 0;
        }
        argTypes[type]++;
    }

    Object.entries(argTypes)
    .sort((a,b) => b[1] -a[1])
    .forEach(x => console.log(`${x[0]} = ${x[1]}`));
}

console.log(solve('cat', 42, function () { console.log('Hello world!');},{}));