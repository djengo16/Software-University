function solve(input) {
  let towns = {};
  input.forEach((x) => {
    [city, product, sales, quantity] = x.split(/ -> | : /);
    if (!towns[city]) {
      towns[city] = {};
      console.log(`Town - ${city}`);
    }
    towns[city][product] = sales * quantity;
    console.log(`$$$${product} : ${towns[city][product]}`);
  });
}
solve([
  "Sofia -> Laptops HP -> 200 : 2000",
  "Sofia -> Raspberry -> 200000 : 1500",
  "Sofia -> Audi Q7 -> 200 : 100000",
  "Montana -> Portokals -> 200000 : 1",
  "Montana -> Qgodas -> 20000 : 0.2",
  "Montana -> Chereshas -> 1000 : 0.3",
]);
