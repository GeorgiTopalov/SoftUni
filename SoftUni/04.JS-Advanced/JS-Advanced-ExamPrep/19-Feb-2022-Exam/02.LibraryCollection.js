class LibraryCollection{
    constructor(capacity){
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor){
        if (this.books.length == this.capacity){
            throw new Error('Not enough space in the collection.');
        }
        this.books.push({bookName, bookAuthor, payed: false});

        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook(bookName){
        let book = this.books.find(x => x.bookName == bookName);
        if(!book){
            throw new Error(`${bookName} is not in the collection.`);
        }
        if(book.payed == true){
            throw new Error(`${bookName} has already been paid.`);
        }

        book.payed = true;

        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName){
        let book = this.books.find(x => x.bookName == bookName);
        if(!book){
            throw new Error(`The book, you're looking for, is not found.`);
        }
        if(book.payed == false){
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

       let indexToRemove = this.books.indexOf(book);
       this.books.splice(indexToRemove, 1);
        return `${bookName} remove from the collection.`
    }

    getStatistics(bookAuthor){
        if(bookAuthor == undefined){
            let emptySlots = this.capacity - this.books.length;
            let message = `The book collection has ${emptySlots} empty spots left.\n`
            for (const book of this.books.sort((a,b)=> a.bookName.localeCompare(b.bookName))) {
                if (book.payed == true){
                    message += `${book.bookName} == ${book.bookAuthor} - Has Paid.\n`
                }else{
                    message += `${book.bookName} == ${book.bookAuthor} - Not Paid.\n`
                }
            }
            return message.trimEnd();

        }else{
            let bookToPrint = this.books.find(x => x.bookAuthor == bookAuthor);
            if (!bookToPrint){
                throw new Error(`${bookAuthor} is not in the collection.`);
            }
            if (bookToPrint.payed == true){
                return `${bookToPrint.bookName} == ${bookAuthor} - Has Paid.`
            }
            return `${bookToPrint.bookName} == ${bookAuthor} - Not Paid.`
        }

    }
}

const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics());


