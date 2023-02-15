function solution(ticketInfo, criteria){

    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for(let i = 0; i < ticketInfo.length; i++){
        let [destination, price, status] = ticketInfo[i].split('|');
        let newTicket = new Ticket(destination, parseFloat(price), status);
        tickets.push(newTicket);
    }

    if (criteria == 'price'){
        tickets.sort((a,b) => a.price - b.price);
    }else if (criteria == 'destination'){
        
        tickets.sort((a,b) => a.destination.localeCompare(b.destination));

    }else{
        tickets.sort((a,b) => a.status.localeCompare(b.status));
    }
    
    tickets.forEach(x => console.log(x));
    return tickets;
}

console.log(solution(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'));

