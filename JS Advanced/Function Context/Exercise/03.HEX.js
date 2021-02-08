class Hex {
  constructor(value) {
    this.value = value;
  }
  valueOf() {
    return this.value;
  }
  toString() {
    return `0x${this.value.toString(16).toUpperCase()}`;
  }
  /**
   * Add to our value
   * @param {Hex} hex
   */
  plus(hex) {
    return new Hex(this.value + hex.value);
  }
  /**
   * Substract from our value
   * @param {Hex} hex
   */
  minus(hex) {
    return new Hex(this.value - hex.value);
  }
  parse(number) {
    return Number(number.toString(10));
  }
}
let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === "0xF");
console.log(FF.parse("0xFFF"));
