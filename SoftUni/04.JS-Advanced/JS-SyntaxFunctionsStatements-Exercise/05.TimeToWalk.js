function solution(steps, footprint, speed){
    let distance = steps * footprint;
    let speedPerSec = speed * 1000 / 3600;
    let timeInSec = Math.round(distance / speedPerSec);
    let rest = Math.floor(500 / speedPerSec);
    let hours = 0;
    let minutes = 0;
    let seconds = 0;

    for (i = 1; i <= timeInSec; i++){
        if (i % rest === 0){
            minutes++;
        }
        seconds++;
        if (seconds === 60){
            seconds = 0;
            minutes++;
        }
        if (minutes === 60){
            minutes = 0;
            hours++;
        }
    }
    
    console.log(`${hours.toFixed(0).padStart(2, 0)}:${minutes.toFixed(0).padStart(2, 0)}:${seconds.toFixed(0).padStart(2, 0)}`);
}

solution(4000, 0.60, 5);
