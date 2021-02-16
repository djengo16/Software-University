function solve(){
    let proto = {};

    let instance = Object.create(proto);

    instance.extend = function (template){
        for (const prop in template) { 
            if(typeof template[prop] === 'function'){
                proto[prop] = template[prop];
            }else{
                instance[prop] = template[prop];
            }
            
        }
    };
    return instance;
}

var template = {
    extensionMethod: function () {
        console.log("From extension method")
    }
};

var testObject = solve();
testObject.extend(template);
