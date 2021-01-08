function solve(input) {
  let words = input[0].match(/\w+/g).reduce(
    (acc, x) => ({
      ...acc,
      [x]: (acc[x] || 0) + 1,
    }),
    {}
  );
  return JSON.stringify(words);
}
console.log(solve(["JS devs use Node.js for server-side JS.-- JS for devs"]));
