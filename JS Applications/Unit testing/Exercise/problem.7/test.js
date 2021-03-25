let {assert} = require('chai')
let Warehouse = require('./warehouse.js');

describe('Warehouse',() => {
    let warehouse;
        beforeEach(() => {
            warehouse = new Warehouse(10);
        })
    describe('constructor',() => {
        it('should set capacity properly', () => {
           assert.equal(warehouse.capacity,10);
        })
        it('should create availableProducts object', () => {
            assert.isTrue(warehouse.availableProducts != undefined)
        })
    })

    describe('AddProduct',() => {
        it('should add product',() => {
            let actual = 
            warehouse.addProduct('Food', 'noodles' ,5);
            warehouse.addProduct('Food', 'noodles' ,5);
            let expected = {'noodles': 10}
            assert.equal(JSON.stringify(actual), 
            JSON.stringify(expected));
        })
        it('should throw error when there is not enough space',() => {
            assert.throw(() => {
                warehouse.capacity = 2;
                warehouse.addProduct('Food', 'noodles' , 10);
                warehouse.addProduct('Food', 'chips' , 10);
                warehouse.addProduct('Food', 'cake' , 10);
            },'There is not enough space or the warehouse is already full');
        })
    })

    describe('orderProducts',() => {
        it('should sort the products of given type',()=>{            
            warehouse.addProduct('Food', 'chips' , 3);
            warehouse.addProduct('Food', 'noodles' , 5);
            let actual  = warehouse.orderProducts('Food');
            let expected = {
                'noodles': 5,
                'chips': 3
            }
            assert.equal(JSON.stringify(actual), 
            JSON.stringify(expected));
        })
    })

    describe('occupiedCapacity',() => {
        it('should return the already occupied place in the warehouse',()=>{            
            warehouse.addProduct('Food', 'chips' , 3);
            warehouse.addProduct('Food', 'noodles' , 5);
            let actual = warehouse.occupiedCapacity();
            assert.equal(actual,8);
        })
    })
    describe('revision',() => {
        it('should return the correct revision output',()=>{            
            warehouse.addProduct('Food', 'chips' , 3);
            warehouse.addProduct('Drink', 'fanta' , 5);
            let actual = warehouse.revision();
            let expected = [
                'Product type - [Food]',
                '- chips 3',
                'Product type - [Drink]',
                '- fanta 5'].join('\n');

            assert.equal(actual,expected);
        })
    })
    describe('scrapeAProduct',() => {
        it('should reduce product quntity',()=>{            
            warehouse.addProduct('Food', 'chips' , 7);
            let actual = warehouse.scrapeAProduct('chips', 5);
            let expected = {'chips': 2};
            assert.equal(actual.toString(), expected.toString());
        })
        it('should reset product quntity if input quantity is bigger than the real',()=>{            
            warehouse.addProduct('Food', 'chips' , 7);
            let actual = warehouse.scrapeAProduct('chips', 20);
            let expected = {'chips': 0};
            assert.equal(actual.toString(), expected.toString());
        })
        it('should return outpu if product do not exists',()=>{
            assert.throw(() => {
                warehouse.scrapeAProduct('cheese',20)
            },`cheese do not exists`)
        })
    })
})