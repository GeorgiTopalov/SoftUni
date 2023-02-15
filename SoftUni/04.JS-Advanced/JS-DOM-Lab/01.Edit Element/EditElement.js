function editElement(element, match, replacement) {
    const content = element.textContent;
    const text = new RegExp(match, 'g');
    const newContent = content.replace(text, replacement);
    element.textContent = newContent;
}