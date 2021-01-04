class List {
  constructor() {
    this._collection = [];
    this.size = this._collection.length;
  }

  add(element) {
    this._collection.push(element);
    this._collection.sort((a, b) => a - b);
    this.size++;
  }
  remove(index) {
    if (index < this._collection.length && index > -1) {
      this._collection.splice(index, 1);
      this._collection.sort((a, b) => a - b);
      this.size--;
    }
  }
  get(index) {
    if (index < this._collection.length && index > -1) {
      return this._collection[index];
    }
  }
}

let list = new List();
console.log(list._collection);
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);
