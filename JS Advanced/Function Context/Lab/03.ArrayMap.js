function arrayMap(array, func) {
  return array.reduce((a, x) => {
    a.push(func(x));
    return a;
  }, []);
}

let letters = ["a", "b", "c"];
console.log(arrayMap(letters, (l) => l.toLocaleUpperCase())); // [ 'A', 'B', 'C' ]
