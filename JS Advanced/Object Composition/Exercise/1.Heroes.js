function solve() {
  function fight() {
    console.log(`${this.name} slashes at the foe!`);
    this.stamina--;
  }

  function cast(spell) {
    console.log(`${this.name} cast ${spell}`);
    this.mana--;
  }

  function mage(name) {
    let state = {
      name,
      health: 100,
      mana: 100,
      cast,
    };

    return state;
  }

  function fighter(name) {
    let state = {
      name,
      health: 100,
      stamina: 100,
      fight,
    };
    return state;
  }

  return { mage, fighter };
}

let create = solve();
const scorcher = create.mage("Scorcher");
const scorcher3 = create.mage("Scorche2");
scorcher.cast("fireball");
scorcher.cast("thunder");
scorcher.cast("light");

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight();

console.log(scorcher2.stamina);
console.log(scorcher.mana);