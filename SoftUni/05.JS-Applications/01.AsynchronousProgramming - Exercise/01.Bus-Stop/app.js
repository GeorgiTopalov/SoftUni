async function getInfo() {
    const inputValue = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${inputValue}`;
    let stopName = document.getElementById('stopName');
    let busDiv = document.getElementById('buses');

    try{
        const response = await fetch(url);
        const data = await response.json();
    
        console.log(data);
        busDiv.innerHTML = '';
    
        stopName.textContent = data.name;
    
        for (const bus in data.buses) {
            let newBus = document.createElement('li');
            newBus.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;
            busDiv.appendChild(newBus);
        }
    }
    catch{
        stopName.textContent = 'Error';
        busDiv.innerHTML = '';
    }
}