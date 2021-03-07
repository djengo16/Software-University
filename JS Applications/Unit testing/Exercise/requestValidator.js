function validate(request){
    const methods = ["GET", 'POST', 'DELETE', 'CONNECT'];
    const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const specialCharacters = ['<', '>', '\\', '&', '\'', '"']

    if(!methods.includes(request.method)){
        throw new Error('Invalid request header: Invalid Method');
    }

    let regex = /^[A-z0-9.]+$/;

    if(!regex.test(request.uri)){
        throw new Error('Invalid request header: Invalid URI');
    }

    if(!versions.includes(request.version)){
        throw new Error('Invalid request header: Invalid Version');
    }

    if(specialCharacters.some(c => request.message.includes(c))){
        throw new Error('Invalid request header: Invalid Version');
    }

    return request;
}

console.log(validate({
    method: 'POST',
    uri: 'home.bash',
    version: 'HTTP/1.1',
    message: 'https://svn.myservice.com/downloads/'
  }));