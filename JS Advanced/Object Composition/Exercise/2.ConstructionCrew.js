function solve(obj) {
  if (obj["dizziness"]) {
    let levelOfHydrated = 0.1 * obj["weight"] * obj["experience"];
    obj["dizziness"] = false;
    obj['levelOfHydrated'] += levelOfHydrated;
  }
  return obj;
}

console.log(
  solve({ weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true }
  ));