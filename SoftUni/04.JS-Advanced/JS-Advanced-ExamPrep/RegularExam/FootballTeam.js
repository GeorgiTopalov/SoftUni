class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {

        let invitedPlayers = [];

        for (const footballPlayer of footballPlayers) {

            let [name, age, playerValue] = footballPlayer.split('/');
            let player = this.invitedPlayers.find(x => x.name == name)

            if (player === undefined) {
                player = { name, age, playerValue };
                this.invitedPlayers.push(player);
            }
            else {
                if (Number(player[playerValue]) < Number(playerValue)) {
                    player[playerValue] = playerValue;
                }
            }
            if (!invitedPlayers.includes(name)){
                invitedPlayers.push(name);
            }
        }


        return `You successfully invite ${invitedPlayers.join(', ')}.`
    }

    signContract(selectedPlayer){
        let [name, playerOffer] = selectedPlayer.split('/');
        let player = this.invitedPlayers.find(x => x.name == name)

        if (player === undefined){
            throw new Error(`${name} is not invited to the selection list!`);
        }
        else if (Number(player.playerValue) > Number(playerOffer)){
            let priceDifference = Number(player.playerValue) - Number(playerOffer);
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${priceDifference} million more are needed to sign the contract!`);
        }

        player.playerValue = 'Bought';

        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    }

    ageLimit(name, age){
        let player = this.invitedPlayers.find(x => x.name == name)

        if (player === undefined){
            throw new Error (`${name} is not invited to the selection list!`);
        }
        if (player.age < age){
            let ageDifference = age - player.age;

            
            if (ageDifference < 5){
                return `${name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!`;
            }
            if (ageDifference >= 5){
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            }
        }
        return `${name} is above age limit!`;

    }

    transferWindowResult(){
        let message = 'Players list:\n';

        for (const player of this.invitedPlayers.sort((a,b) => a.name.localeCompare(b.name))) {
            message += `Player ${player.name}-${player.playerValue}\n`
        }

        return message.trimEnd();
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());


