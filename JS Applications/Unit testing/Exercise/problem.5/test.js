let {assert, expect} = require('chai');
let StringBuilder = require('./StringBuilder.js');

describe('StringBuilder', function() {
    describe('constructor',function(){
        it('should be instantiated with the passed string', function(){
            let str = new StringBuilder('init');
            assert.equal(str.toString(),'init');
        })
        it('should be instantiated with no params', function(){
            let str = new StringBuilder();
            assert.equal(str.toString(),'');
        })
        it('should throw error if not string', function(){
            expect(() => new StringBuilder(5)).to.throw('Argument must be string');
        })
    })

    describe('append', function(){
        it('should append the string',function(){
            let str = new StringBuilder('Hello');
            str.append(' world!');
            assert.equal(str.toString(),'Hello world!');
        })
        it('should throw error if not string', function(){
            expect(() => new StringBuilder().append(5)).to.throw('Argument must be string');
        })
    })

    describe('prepend', function(){
        it('should prepend the string',function(){
            let str = new StringBuilder(' world!');
            str.prepend('Hello');
            assert.equal(str.toString(),'Hello world!');
        })
        it('should throw error if not string', function(){
            expect(() => new StringBuilder().prepend(5)).to.throw('Argument must be string');
        })
    })

    describe('insertAt', function(){
        it('should insert the string at the correct place',function(){
            let str = new StringBuilder('How today?');
            str.insertAt(' are you', 3);
            assert.equal(str.toString(),'How are you today?');
        })
        it('should throw error if not string', function(){
            expect(() => new StringBuilder().insertAt(undefined,2)).to.throw('Argument must be string');
        })
    })

    describe('remove', function(){
        it('should remove the string from the correct place',function(){
            let str = new StringBuilder('test remove');
            str.remove(4,7);
            assert.equal(str.toString(),'test');
        })
    })

})