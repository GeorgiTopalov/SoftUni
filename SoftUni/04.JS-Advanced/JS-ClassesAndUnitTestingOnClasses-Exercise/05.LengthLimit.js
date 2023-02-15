class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
        this.usableString = innerString;
        this.usableLength = innerLength;
    }

    increase(length) {
        this.usableLength += length;
        this.usableString = '';
        let currentLength = this.usableLength;
        if (this.usableLength > this.innerString.length) {
            currentLength = this.innerString.length;
        }
        for (let i = 0; i < currentLength; i++) {
            this.usableString += this.innerString[i];
        }
    }

    decrease(length) {
        this.usableLength = this.innerLength - length;

        if (this.usableLength < 0) {
            this.usableLength = 0;
        }

        this.usableString = '';

        for (let i = 0; i < this.usableLength; i++) {
            this.usableString += this.innerString[i];
        }
    }

    toString() {
        if (this.usableLength < this.innerString.length) {
            return `${this.usableString}` + '...';
        }

        return `${this.usableString}`;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(10);
console.log(test.toString()); // ...

test.increase(6);
console.log(test.toString()); // Test
