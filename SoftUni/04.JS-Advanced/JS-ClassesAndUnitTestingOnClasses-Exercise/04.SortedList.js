class List {

    constructor() {
        this.sortedList = [];
        this.size = this.sortedList.length;
    }

    add(element) {
        this.sortedList.push(element);
        this.size = this.sortedList.length;
        this.sortedList.sort((a, b) => a - b);
    }

    remove(index) {
        if (index < 0 || index >= this.sortedList.length) {
            throw new Error('Index out of range!');
        }
        this.sortedList.splice(index, 1);
        this.size = this.sortedList.length;
    }

    get(index) {
        if (index < 0 || index >= this.sortedList.length) {
            throw new Error('Index out of range!');
        }
        return this.sortedList[index];
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.size);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));