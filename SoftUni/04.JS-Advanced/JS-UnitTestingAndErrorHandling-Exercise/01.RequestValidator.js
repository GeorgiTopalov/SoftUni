function solution(input){
const methodTypes = ['GET', 'POST', 'DELETE', 'CONNECT'];
const uriPattern = /^[0-9a-zA-Z\.]{1,20}$/;
const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
const invalidMessagePattern = /[<>\\&'"]/;

if (!methodTypes.includes(input['method'])|| input['method'] === undefined){
    throw new Error('Invalid request header: Invalid Method');
}
if (!input['uri'].match(uriPattern) || input['uri'] === undefined){
    throw new Error('Invalid request header: Invalid URI');
}
if (!versions.includes(input['version']) || input['version'] === undefined){
    throw new Error('Invalid request header: Invalid Version');
}
if (input['message'].match(invalidMessagePattern) || input['message'] === undefined){
    throw new Error('Invalid request header: Invalid Message');
}

return input;
}

console.log(solution({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
  }));