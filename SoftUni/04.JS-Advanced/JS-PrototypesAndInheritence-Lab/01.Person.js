function Person(firstName, lastName){
    this.firstName = firstName;
    this.lastName = lastName;

    Object.defineProperty(this, 'fullName', {
        set: function(value){
            let pattern = /\w+\s\w+/;
            if(value.match(pattern)){
                this.firstName = value.split(' ')[0];
                this.lastName = value.split(' ')[1];
            }
            
        },
        get: function(){
            return `${this.firstName} ${this.lastName}`;
        }
    });
}
let person = new Person("Albert", "Simpson");
console.log(person.fullName); //Albert Simpson
person.firstName = "Simon";
console.log(person.fullName); //Simon Simpson
person.fullName = "Peter";
console.log(person.firstName);  // Simon
console.log(person.lastName);  // Simpson

/* let person = new Person("Peter", "Ivanov");
console.log(person.fullName); //Peter Ivanov
person.firstName = "George";
console.log(person.fullName); //George Ivanov
person.lastName = "Peterson";
console.log(person.fullName); //George Peterson
person.fullName = "Nikola Tesla";
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla */
