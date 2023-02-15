function printDeckOfCards(cards) {

    const deck = []

    for (let i = 0; i < cards.length; i++) {
        const cardData = cards[i].split('')
        const [face, suit] = [
            cardData.slice(0, -1).join(''),
            cardData[cardData.length - 1]
        ]

        try {
            deck.push(createCard(face, suit).toString())
        } catch (e) {
            console.log(`Invalid card: ${cards[i]}`)
            return
        }
    }

    return deck.join(' ')

    function createCard(face, suit) {
        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const suits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663',
        };


        if (!faces.includes(face)) {
            throw new Error('Error');
        }

        let card = {
            face,
            suit,
            toString() {
                console.log(this.face + suits[this.suit]);
            },
        };

        return card;
    }

}

printDeckOfCards(['AS', '10D', 'KH', '2C']);

  