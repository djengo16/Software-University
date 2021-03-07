let assert = require('chai').assert;
let isOddOrEven = require('./isOddOrEven')

describe('isOddOrEven', () => {
    it('should return undefined with a number parameter', () => {
        assert.equal(isOddOrEven(1), undefined);
    })

    it('should return undefined with an object parameter', () => {
        assert.equal(isOddOrEven({name:'George'}), undefined);
    })

    it('should return even with an even string', () => {
        assert.equal(isOddOrEven('even'), 'even');
    })

    it('should return odd with an odd string', () => {
        assert.equal(isOddOrEven('odd'), 'odd');
    })

})