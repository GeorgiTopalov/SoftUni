function solution(input) {
    const cars = new Map();

    while (input.length > 0) {
        let [brand, model, quantity] = input.shift().split(' | ');
        let models = new Map();

        if (!cars.has(brand)) {
            models.set(model, Number(quantity));
            cars.set(brand, models);
        } else {
            let currentModels = cars.get(brand);

            if (!currentModels.has(model)) {
                currentModels.set(model, Number(quantity));
            } else {
                let currentQt = currentModels.get(model);
                currentModels.set(model, currentQt + Number(quantity));
                cars.set(brand, currentModels);
            }
        }
    }

    for (const [brand, models] of cars) {
        console.log(brand);
        for (const [model, quantity] of models) {
            console.log(`###${model} -> ${quantity}`);
        }
    }
}

solution(['Mercedes-Benz | 50PS | 123',
'Mini | Clubman | 20000',
'Mini | Convertible | 1000',
'Mercedes-Benz | 60PS | 3000',
'Hyunday | Elantra GT | 20000',
'Mini | Countryman | 100',
'Mercedes-Benz | W210 | 100',
'Mini | Clubman | 1000',
'Mercedes-Benz | W163 | 200']);

    
    