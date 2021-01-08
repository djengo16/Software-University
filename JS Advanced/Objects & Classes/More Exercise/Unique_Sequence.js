function problem(input) {
  let arrays = new Map();
  for (let i = 0; i < input.length; i++) {
    let currentArray = JSON.parse(input[i])
      .map(Number)
      .sort((a, b) => b - a);
    let toAdd = currentArray.join(", ");
    if (!arrays.has(toAdd)) {
      arrays.set(toAdd, currentArray.length);
    }
  }
  let result = Array.from(arrays.keys()).sort(
    (a, b) => arrays.get(a) - arrays.get(b)
  );
  result.forEach((a) => console.log(`[${a}]`));
}
problem([
  "[-3, -2, -1, 0, 1, 2, 3, 4]",
  "[10, 1, -17, 0, 2, 13]",
  "[4, -3, 3, -2, 2, -1, 1, 0]",
]);
