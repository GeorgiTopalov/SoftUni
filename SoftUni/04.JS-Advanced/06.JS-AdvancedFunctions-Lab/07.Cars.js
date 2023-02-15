function solution(input) {
    let cars = {};

    function processCommand() {
        return {

            create: (n) => Object.create(cars[n]) || {},
            inherit: (n1, n2) => n1 = Object.create(cars[n2]),
            set: (n, key, value) => cars[n][key] = value,
            print: (n) => {
                let messageOutput = [];

                for (const key in cars) {
                    messageOutput.push(`${key}:${cars[n][key]}`);
                }

                console.log(messageOutput.join(', '));
            },
        };
    }
    for (const commandArgs of input) {

        let commandExecution = processCommand();
        let commandArgsSplit = commandArgs.split(' ');
        let command = commandArgsSplit[0];
        let name = commandArgsSplit[1];

        if (commandArgsSplit.length > 2 && command === 'create') {
            let parentName = commandArgsSplit[3];
            commandExecution.inherit(cars[parentName], name);
        } else if (command === 'create') {
            commandExecution.create(name);
        } else if (command === 'set') {
            commandExecution.set(name, commandArgsSplit[1], commandArgsSplit[2]);
        } else if (command === 'print') {
            commandExecution.print(name);
        }
    }
}
solution(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']);
