function solve() {

	let inputValue = document.getElementById('input').value;
	let outputElement = document.getElementById('output');
	let splittedText = inputValue.split('.').filter(x => x !== '');

	for (let i = 0; i < splittedText.length; i++) {
		if (i == 0 || i % 3 == 0) {
			let paragraphTag = document.createElement('p');
			outputElement.appendChild(paragraphTag);
		}

		let paragraph = document.querySelector('#output:last-child');
		let text = (splittedText[i] + '. ');
		paragraph.innerHTML += text;

	}
}

