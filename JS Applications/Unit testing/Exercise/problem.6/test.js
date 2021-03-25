let PaymentPackage = require('./paymentPackage.js');
let {assert} = require('chai');

describe('paymentPackage', function(){
    let paymentPackage;
    beforeEach(() => {
        paymentPackage = new PaymentPackage('Test', 20);
        paymentPackage.VAT = 20;
        paymentPackage.active = true;
    })
    it('should be instantiated', function(){
        const paypack = new PaymentPackage('Name', 20);
        assert.equal(paypack.name,'Name');
    })
    it('should throw error with incorect name', function(){
        assert.throw(() => {
            new PaymentPackage('', 20);
        },'Name must be a non-empty string');
    })
    it('should return the correct name', function(){
        assert.equal(paymentPackage.value,20)
    })
    //VALUE
    it('should return the correct value', function(){
        assert.equal(paymentPackage.name,'Test')
    })
    it('should throw error with incorrect value', function(){
        assert.throw(() => {
            new PaymentPackage('name', 's');
        },'Value must be a non-negative number');
    })

    it('should throw error with negative value', function(){
        assert.throw(() => {
            new PaymentPackage('name', -20);
        },'Value must be a non-negative number');
    })

    //VAT
    it('should throw error with incorrect VAT', function(){
        assert.throw(() => {
            paymentPackage.VAT = 'inc';
        },'VAT must be a non-negative number');
    })
    it('should throw error with negative VAT', function(){
        assert.throw(() => {
            paymentPackage.VAT = -20;
        },'VAT must be a non-negative number');
    })
    it('should return the correct VAT', function(){
        assert.equal(paymentPackage.VAT,20)
    })
    //active
    it('should throw error with incorrect active value',function (){
        assert.throw(() => {
            paymentPackage.active = 'inc';
        },'Active status must be a boolean')
    })
    it('should return correct active value',function(){
        assert.equal(true,paymentPackage.active)
    })
    //toString
    it('should return correct string', function (){
        let result  = [
            `Package: Test`,
            `- Value (excl. VAT): 20`,
            `- Value (VAT 20%): ${20 * (1 + 20 / 100)}`
          ].join('\n');

          assert.equal(result,paymentPackage.toString()) 
    })
})