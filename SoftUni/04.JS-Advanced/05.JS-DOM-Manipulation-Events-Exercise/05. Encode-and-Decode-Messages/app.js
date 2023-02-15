function encodeAndDecodeMessages() {
    let inputTextAreaElement = document.querySelector('textarea[placeholder="Write your message here..."]');
    let receiveTextAreaElement = document.querySelector('textarea[placeholder="No messages..."]');
    let encodeButtonElement = inputTextAreaElement.parentNode.querySelector('button');
    let decodeButtonElement = receiveTextAreaElement.parentNode.querySelector('button');

    encodeButtonElement.addEventListener('click', () => {
        let message = inputTextAreaElement.value;
        let cryptedMessage = '';
        for (let i = 0; i < message.length; i++) {
            let currentChar = message.charCodeAt(i) + 1;
            cryptedMessage += String.fromCharCode(currentChar);
        }

        inputTextAreaElement.value = '';
        receiveTextAreaElement.value = cryptedMessage;
    });

    decodeButtonElement.addEventListener('click', () => {
       let message = receiveTextAreaElement.value;
       let decryptedMessage = '';

       for (let i = 0; i < message.length; i++) {
        let currentChar = message.charCodeAt(i) - 1;
        decryptedMessage += String.fromCharCode(currentChar);
    }

    receiveTextAreaElement.value = decryptedMessage;
    });


}