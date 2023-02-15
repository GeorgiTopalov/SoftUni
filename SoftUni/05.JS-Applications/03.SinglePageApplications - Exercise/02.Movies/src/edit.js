import { showView } from './utils.js';

const section = document.getElementById('edit-movie');
section.remove();

export function showEdit(){
    showView(section);
}
