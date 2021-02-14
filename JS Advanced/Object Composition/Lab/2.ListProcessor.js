function solve(input){

    function listProcessorBuilder() {        
    let list = [];

        return  {
            add: (string) =>  list.push(string),
            remove: (string) => list = list.filter(x => x != string),
            print: () => console.log(list.join())
        }
    }

    let listProcessor = listProcessorBuilder();
 
    for (const command of input) {
        [operation, input] = command.split(' ');
        listProcessor[operation](input);
    }
}

solve(['add peter', 'add george', 'add peter', 'remove peter','print']);