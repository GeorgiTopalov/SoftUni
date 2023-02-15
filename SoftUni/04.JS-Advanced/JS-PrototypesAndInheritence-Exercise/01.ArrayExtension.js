(function solve(){
Array.prototype.last = function(){

return this[this.length - 1];
}
Array.prototype.skip = function(n){
    if (n < 0 || n >= this.length){
        throw new Error('Index out of range!');
    }

    let newArray = [];
    for(let i = n; i < this.length; i++){
        newArray.push(this[i]);
    }

    return newArray;
}
Array.prototype.take = function(n){
    if (n < 0 || n >= this.length){
        throw new Error('Index out of range!');
    }
    let newArray = [];

    for(let i = 0; i < n; i++){
        newArray.push(this[i]);
    }

    return newArray;
}
Array.prototype.sum = function(){
    let sum = 0;

    for(let i = 0; i< this.length; i++){
        sum += this[i];
    }

    return sum;
}
Array.prototype.average = function(){
    return this.sum() / this.length;
}
})();

var testArray = [1, 2, 3];
console.log(testArray.skip(1)[0]);