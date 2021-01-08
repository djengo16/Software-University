function solve(input) {
  let mySet = [...new Set(input)];
  mySet.sort((a, b) => a.length - b.length || a.localeCompare(b));
  mySet.forEach((x) => console.log(x));
}

solve([
  "Ashton",
  "Kutcher",
  "Ariel",
  "Ariel",
  "Lilly",
  "Keyden",
  "Aizen",
  "Billy",
  "Braston",
]);
