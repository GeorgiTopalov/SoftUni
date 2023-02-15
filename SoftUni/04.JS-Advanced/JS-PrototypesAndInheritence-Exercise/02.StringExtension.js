(function solve() {

    String.prototype.ensureStart = function (str) {

        let newString = this.toString();
        if (!newString.startsWith(str)) {
            newString = str + this;
        }
        return newString;

    };

    String.prototype.ensureEnd = function (str) {
        let newString = this.toString();
        if (!newString.endsWith(str)) {
            newString += str;
        }
        return newString;

    };

    String.prototype.isEmpty = function () {
        return this.length === 0 ? true : false;
    }

    String.prototype.truncate = function (n) {
        let newString = this.toString();

        if (n < 3) {
            return '.'.repeat(n);
        }
        if (n > newString.length) {
            return newString;
        } else {
            let endIndex = newString.substring(0, n - 2).lastIndexOf(' ');

            if (endIndex !== -1) {
                return newString.substring(0, endIndex) + '...';
            } else {
                return newString.substring(0, n - 3) + '...';
            }
        }
    };
    String.format = function (string, ...params) {

        for (let i = 0; i < params.length; i++){
            string = string.replace(`{${i}}`, params[i]);
        }
        return string;
    };
})();

let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
str = String.format('jumps {0} {1}',
  'dog');