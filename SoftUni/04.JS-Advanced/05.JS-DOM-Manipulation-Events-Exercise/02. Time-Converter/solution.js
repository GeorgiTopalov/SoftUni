function attachEventsListeners() {
 let daysInputElement = document.getElementById('days');
 let hoursInputElement = document.getElementById('hours');
 let minutesInputElement = document.getElementById('minutes');
 let secondsInputElement = document.getElementById('seconds');

 let buttonsElements = Array.from(document.querySelectorAll('input[type = "button"]'));

 buttonsElements.forEach(el => el.addEventListener('click', (e) =>{

    let input = e.target.parentElement.querySelector('input[type="text"]');

    if (e.target.id === 'daysBtn'){
        hoursInputElement.value = Number(input.value) * 24;
        minutesInputElement.value = Number(input.value) * 1440;
        secondsInputElement.value = Number(input.value) * 86400;
    }else if (e.target.id === 'hoursBtn'){
        daysInputElement.value = Number(input.value) / 24;
        minutesInputElement.value = Number(input.value) * 60;
        secondsInputElement.value = Number(input.value) * 3600;
    }else if (e.target.id === 'minutesBtn'){
        daysInputElement.value = Number(input.value) / 1440;
        hoursInputElement.value = Number(input.value) / 60;
        secondsInputElement.value = Number(input.value) * 60;
    }else{
        daysInputElement.value = Number(input.value) / 86400;
        hoursInputElement.value = Number(input.value) / 3600;
        minutesInputElement.value = Number(input.value) / 60;
    }
 }));
}