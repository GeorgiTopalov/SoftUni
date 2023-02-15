function solution(input) {
    let juices = new Map();
    let bottles = new Map();

    for (const juice of input) {
        let juiceName = juice.split(' => ')[0];
        let quantity = Number(juice.split(' => ')[1]);

        if (!juices.has(juiceName)) {
            juices.set(juiceName, quantity);
        } else {
            quantity += juices.get(juiceName);
            juices.set(juiceName, quantity);
        }


        while (juices.get(juiceName) >= 1000) {
            juices.set(juiceName, juices.get(juiceName) - 1000);

            if (!bottles.has(juiceName)) {
                bottles.set(juiceName, 1);
            } else {
                bottles.set(juiceName, bottles.get(juiceName) + 1);
            }
        }
    }

    for (const juiceType of bottles) {
        console.log(`${juiceType[0]} => ${juiceType[1]}`);
    }
}

solution(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);