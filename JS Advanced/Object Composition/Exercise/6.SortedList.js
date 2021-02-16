function sortedList() {
  const collection = [];
  function sort() {
    collection.sort((a, b) => a - b);
  }

  return {
    add: function(element) {
      collection.push(element);
      this.size++;
      sort();
    },
    remove: function(index)  {
      if (index >= 0 && index <= this.size - 1) {
        collection.splice(index, 1);
        this.size--;
      }
    },
    get: function(index) {
      if (index >= 0 && index <= this.size - 1) {
      return collection[index];
      }
    },
    size: 0,
  };
}