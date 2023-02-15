function solve(order) {

    let engine = {};
    let carriage = {type: order.carriage, color: order.color};

    if (order.power <= 90) {
        engine.power = 90;
        engine.volume = 1800;
    } else if (order.power <= 120) {
        engine.power = 120;
        engine.volume = 2400;
    } else {
        engine.power = 200;
        engine.volume = 3500;
    }
    let wheelsize = order.wheelsize;

    if (wheelsize % 2 == 0) {
        wheelsize--;
    }

    let car = {
        model: order.model,
        engine: engine,
        carriage: carriage,
        wheels: [wheelsize, wheelsize, wheelsize, wheelsize]
    }

    return car;
}

console.log(solve({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }));