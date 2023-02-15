function result() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        get area() {
            return;
        }

        changeUnits(value) {
            this.units = value;
        }

        scaleUnits(param){

            
            if (this.units == 'cm'){
                param *= 1;
            }else if (this.units == 'mm'){
                param *= 10;
            }else if (this.units == 'm'){
                param /= 10;
            }

            return param;
        }

        toString() {
          return  `Figures units: ${this.units}`
        }
    }

    class Circle extends Figure {
        constructor(radius, units) {
            super(units)
            this._radius = radius;
        }

        get area() {
            return Math.PI * this.radius * this.radius;
        }
        get radius(){
            return this.scaleUnits(this._radius);
        }
        

        toString(){
           return `Figures units: ${this.units} Area: ${this.area} - radius: ${this.radius}`
        }
    }

    class Rectangle extends Figure{
        constructor(width, height, units){
            super(units)
            this._width = width;
            this._height = height;
        }

        get area(){
            
            return this.width * this.height;
        }
        get width(){
            return this.scaleUnits(this._width);
        }
        get height(){
            return this.scaleUnits(this._height);
        }
        toString(){
           return `Figures units: ${this.units} Area: ${this.area} - width: ${this.width}, height: ${this.height}`
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}

let classes = result();
let Figure = classes.Figure;
let Rectangle = classes.Rectangle;
let Circle = classes.Circle;

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50
