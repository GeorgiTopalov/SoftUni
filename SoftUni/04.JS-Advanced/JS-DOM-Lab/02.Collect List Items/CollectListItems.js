function extractText() {
    let extractedText = document.getElementById('items');
    let areaToExtract = document.getElementById('result');
    areaToExtract.textContent = extractedText.textContent;
}