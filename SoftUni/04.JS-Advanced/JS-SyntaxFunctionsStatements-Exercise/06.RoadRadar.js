function solution(speed, area) {

    let limitDifference;
    let speedLimit;
    let status;
    if (area === 'motorway') {
        speedLimit = 130;
    } else if (area == 'interstate') {
        speedLimit = 90;
    } else if (area === 'city') {
        speedLimit = 50;
    } else {
        speedLimit = 20;
    }

    limitDifference = speed - speedLimit;
    if (limitDifference > 0 && limitDifference <= 20) {
        status = 'speeding';
    } else if (limitDifference <= 40) {
        status = 'excessive speeding';
    } else if (limitDifference > 40) {
        status = 'reckless driving';
    }


    if (status === undefined) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else {
        console.log(`The speed is ${limitDifference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

solution(21, 'residential');