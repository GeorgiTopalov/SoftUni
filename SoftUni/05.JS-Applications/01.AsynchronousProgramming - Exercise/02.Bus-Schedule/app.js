function solve() {
    let infoElement = document.querySelector('#info span');
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    let stop = 'depot';
    let stopName = '';

    async function depart() {
        const url = `http://localhost:3030/jsonstore/bus/schedule/${stop}`;
        let response = await fetch(url);

        if (response.status != 200){
            infoElement.textContent = 'Error!';
        }
        let data = await response.json();
       
        stop = data.next;
        stopName = data.name;
        infoElement.textContent = `Next stop ${stopName}`;
        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    function arrive() {
        infoElement.textContent = `Arriving at ${stopName}`;

        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();