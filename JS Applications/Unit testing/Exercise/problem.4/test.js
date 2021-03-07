let {assert, expect} = require('chai');
let {addFive, subtractTen, sum} = require('./mathEnforcer.js');

describe('mathEnforcer',function(){
    describe('addFive', function(){
        it('should return correct result with a non-number parameter',function () {
            assert.equal(addFive('non-number'), undefined);
        })
        it('should return correct result with a number',function () {
            assert.equal(addFive(5), 10);
        })
        it('should return correct result with a negative number',function () {
            assert.equal(addFive(-5), 0);
        })
        it('should return correct result with a floating point number',function () {
            assert.closeTo(addFive(20.396), 25.396, 0.01);
        })
    })

    describe('subtractTen', function(){
        it('should return correct result with a non-number parameter',function () {
            assert.equal(subtractTen('non-number'), undefined);
        })
        it('should return correct result with a number',function () {
            assert.equal(subtractTen(5), -5);
        })
        it('should return correct result with a negative number',function () {
            assert.equal(subtractTen(-5), -15);
        })
        it('should return correct result with a floating point number',function () {
            assert.closeTo(subtractTen(20.396), 10.396, 0.01);
        })
    })

    describe('sum', function(){
        it('should return correct result with a non-number first parameter', function() {
            expect(sum('nan', 2)).equal(undefined);
        })
        it('should return correct result with a non-number second parameter', function() {
            expect(sum(2,'nan')).equal(undefined);
        })
        it('should return correct result with two numbers', function() {
            expect(sum(2, 2)).equal(4);
        })
        it('should return correct result with floating-point number', function() {
            assert.closeTo(sum(20.396, 10.00), 30.396, 0.01);
        })
    })
})