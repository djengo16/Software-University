const { assert } = require("chai");
let charLookup = require("./CharLookup");

describe("lookupChar", () => {
  it("should return undefined with a non-sting first parameter", () => {
    assert.equal(charLookup(1, 1), undefined);
  });
  it("should return undefined with a non-number second parameter", () => {
    assert.equal(charLookup("test", "non-number"), undefined);
  });
  it("should return undefined with a floating point number second parameter", () => {
    assert.equal(charLookup("test", 2.15), undefined);
  });
  it("should return Incorrect Index with an incorrect index value", () => {
    assert.equal(charLookup("test", 20), "Incorrect index");
  });
  it("should return Incorrect Index with an negative index value", () => {
    assert.equal(charLookup("test", -20), "Incorrect index");
  });
  it("should return Incorrect Index with an equal to length index value", () => {
    assert.equal(charLookup("test", 4), "Incorrect index");
  });
  it("should return the correct char at the given index", () => {
    assert.equal(charLookup("test", 2), "s");
  });
});
