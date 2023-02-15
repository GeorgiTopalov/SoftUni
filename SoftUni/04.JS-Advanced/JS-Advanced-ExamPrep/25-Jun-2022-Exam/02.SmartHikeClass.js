class SmartHike{
        constructor(username){
            this.username = username;
            this.goals = {};
            this.listOfHikes = [];
            this.resources = 100;
        }

        addGoal(peak, altitude){
            if (peak in this.goals){
                return `${peak} has already been added to your goals`;
            }else{
                this.goals[peak] = altitude;
                return `You have successfully added a new goal - ${peak}`;
            }
        }

        hike(peak,time,difficultyLevel){
            if(!this.goals[peak]){
                throw new Error(`${peak} is not in your current goals`);
            }
            if (this.resources == 0){
                throw new Error("You don't have enough resources to start the hike");
            }

            let resourceDiff = this.resources - (time * 10);

            if (resourceDiff < 0){
                return "You don't have enough resources to complete the hike";
            }

            this.resources = resourceDiff;

            this.listOfHikes.push({peak: peak,time: time,difficulty: difficultyLevel});

            return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
        }


        rest(time){
            this.resources += time * 10;

            if (this.resources >= 100){
                this.resources = 100;
                return `Your resources are fully recharged. Time for hiking!`;
            }else{
                return `You have rested for ${time} hours and gained ${time*10}% resources`;
            }
        }

        showRecord(criteria){
            if (this.listOfHikes.length == 0){
                return `${this.username} has not done any hiking yet`;
            }

            if(criteria === 'all'){
                let displayInfo = 'All hiking records:\n';

                for (const hike of this.listOfHikes) {
                    displayInfo+= `${this.username} hiked ${hike.peak} for ${hike.time} hours\n`;
                }

                return displayInfo.trimEnd();
            }

           let hikesToPrint =  this.listOfHikes.filter(x => x.difficulty == criteria);

           if (hikesToPrint.length == 0){
            return `${this.username} has not done any ${criteria} hiking yet`;
           }else{
            let bestHike = hikesToPrint.sort((a,b) => a.time - b.time).find(x => x);
            return `${this.username}'s best ${criteria} hike is ${bestHike.peak} peak, for ${bestHike.time} hours`;
           }
           
        }
}


const user = new SmartHike('Vili');
user.addGoal('Musala', 2925);
user.hike('Musala', 8, 'hard');
console.log(user.showRecord('easy'));
user.addGoal('Vihren', 2914);
user.hike('Vihren', 4, 'hard');
console.log(user.showRecord('hard'));
user.addGoal('Rui', 1706);
user.rest(5);
console.log(user.hike('Rui', 3, 'easy'));
console.log(user.showRecord('all'));

