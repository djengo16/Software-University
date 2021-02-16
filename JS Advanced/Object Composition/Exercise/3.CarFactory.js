function solve(inputObj) {
  let engines = {
    small: { power: 90, volume: 1800 },
    normal: { power: 120, volume: 2400 },
    monster: { power: 200, volume: 3500 },
  };

  let carriages = {
    hatchback: (color) => ({
      type: "hatchback",
      color: color
    }),
    coupe: (color) => ({
      type: "coupe",
      color: color
    }),
  };

  function findEngine(power) {
    for (const engine of Object.entries(engines)) {
      if(engine[1]['power'] >= power){
        return engine[1];
      }
    }
  }

  function setWheels(diameter) {
    if (diameter % 2 === 0) {
      diameter -= 1;
    }
    return new Array(4).fill(diameter);
  }

  let car = {
    model: inputObj["model"],
    engine: findEngine(inputObj["power"]),
    carriage: carriages[inputObj["carriage"]](inputObj["color"]),
    wheels: setWheels(inputObj["wheelsize"]),
  };
  return car;
}

console.log(
  solve({
    model: "VW Golf II",
    power: 90,
    color: "blue",
    carriage: "hatchback",
    wheelsize: 14,
  })
);