function area() {
    return Math.abs(this.x * this.y);
};
function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function solve(area, vol, input){
    let coordinates = JSON.parse(input);

    let output = [];

    for (const row of coordinates) {
        output.push({
            area: area.call(row),
            volume: vol.call(row),
        });
    }

    return output;
}

console.log(solve(area, vol,'[{"x":"10","y":"-22","z":"10"},{"x":"47","y":"7","z":"-5"},{"x":"55","y":"8","z":"0"},{"x":"100","y":"100","z":"100"},{"x":"55","y":"80","z":"250"}]'));