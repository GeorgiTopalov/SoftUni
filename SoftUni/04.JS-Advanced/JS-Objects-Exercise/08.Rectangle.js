function rectangle(width, height, color){
    
let rectangle = {
    width,
    height,
    color: color.charAt(0).toUpperCase() + color.slice(1),
    calcArea: function() {
        return width * height;
    }
}

return rectangle;
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());