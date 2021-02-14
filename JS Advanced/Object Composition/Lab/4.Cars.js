function solve(input) {
  function objectCreatorEngine() {
    let objects = new Map();
    return {
      create: (name, parent) => {
        if (parent) {
          let parentObj = objects.get(parent);
          objects.set(name, Object.create(parentObj));
        }else{
            objects.set(name, {});
        }
      },
      set: (name, key, value) => {
        objects.get(name)[key] = value;
      },
      print: (name) => {
        let curr = objects.get(name);
        let result = [];
        for (const key in curr) {
            result.push(`${key}:${curr[key]}`);
        }

        console.log(result.join(', '));
      },
    };
  }

  let objCreator = objectCreatorEngine();

  for (const command of input) {
    let params = command.split(" ");
    let cmd = params[0];

    if (cmd === "create") {

      let name = params[1];
      let parent = params[3];
      objCreator.create(name, parent);

    } else if (cmd === "set") {

      params.shift();
      [obj, key, value] = params;
      objCreator.set(obj, key, value);

    } else {
      objCreator.print(params[1]);
    }
  }
}

solve([
  "create pesho",
  "create gosho inherit pesho",
  "create stamat inherit gosho",
  "set pesho rank number1",
  "set gosho nick goshko",
  "print stamat",
]);