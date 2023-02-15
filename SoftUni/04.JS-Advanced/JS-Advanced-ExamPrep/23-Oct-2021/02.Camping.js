class SummerCamp{
    constructor(organizer, location ){
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {"child": 150, "student": 300, "collegian": 500};
        this.listOfParticipants = [];
    }

    registerParticipant (name, condition, money){
        if(!this.priceForTheCamp[condition]){
            throw new Error(`Unsuccessful registration at the camp.`);
        }
        if(this.listOfParticipants.some(x => x.name == name)){
            return `The ${name} is already registered at the camp.`;
        }
        if(money < this.priceForTheCamp[condition]){
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push({name, condition, power: 100, wins: 0});
        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant (name){
        let participant = this.listOfParticipants.find(x => x.name == name)
        if (participant == undefined){
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        let indexToRemove = this.listOfParticipants.indexOf(participant);
        this.listOfParticipants.splice(indexToRemove, 1);

        return `The ${name} removed successfully.`;
    }

    timeToPlay (typeOfGame, participant1, participant2){
        let firstParticipant = this.listOfParticipants.find(x => x.name == participant1)

        if (typeOfGame == 'WaterBalloonFights'){
            let secondParticipant = this.listOfParticipants.find(x => x.name == participant2)
    
            if (firstParticipant == undefined || secondParticipant == undefined){
                throw new Error(`Invalid entered name/s.`);
            }
            if (firstParticipant.condition != secondParticipant.condition){
                throw new Error(`Choose players with equal condition.`);
            }

            if (firstParticipant.power > secondParticipant.power){
                firstParticipant.wins++;
                return `The ${firstParticipant.name} is winner in the game ${typeOfGame}.`;
            }else if(secondParticipant.power > firstParticipant.power){
                secondParticipant.wins++;
                return `The ${secondParticipant.name} is winner in the game ${typeOfGame}.`;
            }else{
                return `There is no winner.`;
            }


        }else{
            if (firstParticipant == undefined){
                throw new Error(`Invalid entered name/s.`);
            }

            firstParticipant.power += 20;

            return `The ${firstParticipant.name} successfully completed the game ${typeOfGame}.`;
        }
        
    }

    toString(){
        let message = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`;

        for (const participant of this.listOfParticipants.sort((a,b) => b.wins - a.wins)) {
            message += `${participant.name} - ${participant.condition} - ${participant.power} - ${participant.wins}\n`;
        }

        return message.trimEnd();
    }
}

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.unregisterParticipant("Petar Petarson"));
console.log(summerCamp.unregisterParticipant("Petar"));










