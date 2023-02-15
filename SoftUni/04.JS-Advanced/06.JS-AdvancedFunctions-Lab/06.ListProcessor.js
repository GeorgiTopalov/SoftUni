function solution(input) {
    let output = [];

    function processCommand() {
        return {
            add: (s) => output.push(s),
            remove: (s) => output = output.filter(e => e !== s),
            print: () => console.log(output.join(',')),
        };
    }
    for (const commandArgs of input) {

        let commandExecution = processCommand();
        let commandArgsSplit = commandArgs.split(' ');
        let command = commandArgsSplit[0];

        if (command === 'add') {
            commandExecution.add(commandArgsSplit[1]);
        } else if (command === 'remove') {
            commandExecution.remove(commandArgsSplit[1]);
        } else if (command === 'print') {
            commandExecution.print();
        }
    }
}

solution(['add hello', 'add again', 'remove hello', 'add again', 'print']);