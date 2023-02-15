function solve(input){
let allHeroes = [];

for (const hero of input) {
    let heroDetails = hero.split(' / ');
    let name = heroDetails[0];
    let level = Number(heroDetails[1]);
    let items = [];

    if (heroDetails.length == 3){
        for (const item of heroDetails[2].split(', ')) {
            items.push(item);
        }
    }

    let newHero = {
        name,
        level,
        items,
    }
    allHeroes.push(newHero);
}

return JSON.stringify(allHeroes);
}

console.log(solve(['Isacc / 25',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']));