const { expect } = require('chai');
const chai = require('chai');
const calc = require('./calculator.js');

describe('Calc sum', function(){
    it('Should return positive number when adding two positive numbers', () => {
        //Arrange
        let firstNumber = 1;
        let secondNumber = 5;

        //Act
        let result = calc.sum(firstNumber,secondNumber);

        //Assert
        chai.assert.equal(6,result);
    });

    it('Should return negative when adding two negative numbers', () => {
        let result = calc.sum(-5, -20);

        chai.assert.isTrue(result < 0);
        expect(result).to.equal(-25);
    })
})