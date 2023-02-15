function attachEvents() {
    let inputElement = document.getElementById('location');
    const button = document.getElementById('submit');
    const url = `http://localhost:3030/jsonstore/forecaster/locations`;
    const forecastDiv = document.getElementById('forecast');
    const currentDiv = document.getElementById('current');
    const upcomingDiv = document.getElementById('upcoming');

    button.addEventListener('click', async (e) => {

        try {

            let response = await fetch(url);
            let data = await response.json();


            let location = data.find(x => x.name === inputElement.value);
            forecastDiv.style.display = 'block';


            const todayUrl = `http://localhost:3030/jsonstore/forecaster/today/${location.code}`;
            let todayResp = await fetch(todayUrl);
            let todayData = await todayResp.json();

            let todayConditionSymbol = getConditionSymbol(todayData.forecast);
            let todayHigh = todayData.forecast.high;
            let todayLow = todayData.forecast.low;

            createNewElement('div', 'forecast', currentDiv);
            const todayDiv = document.querySelector('.forecast');
            createNewElement('span', 'condition symbol', todayDiv, todayConditionSymbol);
            createNewElement('span', 'condition', todayDiv);
            const conditionSpan = document.querySelectorAll('.condition')[1];
            createNewElement('span', 'forecast-data', conditionSpan, todayData.name);
            createNewElement('span', 'forecast-data', conditionSpan, `${todayLow}°/${todayHigh}°`);
            createNewElement('span', 'forecast-data', conditionSpan, todayData.forecast.condition);

        }
        catch (error) {
            console.log(error);
        }

        try {
            const upcomingUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`;
            let upcomingResp = await fetch(upcomingUrl);
            let upcomingData = await upcomingResp.json();


            createNewElement('div', 'forecast-info', upcomingDiv);
            let upcomingInfoDiv = document.querySelector('.forecast-info');

            for (let i = 0; i < upcomingData.forecast.length; i++) {
                createNewElement('span', 'upcoming', upcomingInfoDiv);
                let currentSpan = document.querySelectorAll('.upcoming')[i];
                let currentHigh = upcomingData.forecast[i].high;
                let currentLow = upcomingData.forecast[i].low;

                let currentConditionSymbol = getConditionSymbol(upcomingData.forecast[i]);

                createNewElement('span', 'symbol', currentSpan, currentConditionSymbol);
                createNewElement('span', 'forecast-data', currentSpan, `${currentLow}°/${currentHigh}°`);
                createNewElement('span', 'forecast-data', currentSpan, upcomingData.forecast[i].condition);
            }
        }
        catch (error) {
            console.log(error);
        }
    });

    function getConditionSymbol(data) {
        let conditionSymbol = '';

        if (data.condition === 'Sunny') {
            conditionSymbol = `☀`;
        } else if (data.condition === 'Partly sunny') {
            conditionSymbol = `⛅`;
        } else if (data.condition === 'Overcast') {
            conditionSymbol = `☁`;
        } else {
            conditionSymbol = `☂`;
        }

        return conditionSymbol;
    }

    function createNewElement(type, _class, parent, content) {
        let newDoc = document.createElement(type);
        newDoc.classList = _class;
        if (content) {
            newDoc.textContent = content;
        }

        parent.appendChild(newDoc);

    }
}

attachEvents();



