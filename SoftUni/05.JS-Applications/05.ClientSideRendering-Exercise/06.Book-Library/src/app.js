//app:
//init other modules
//dependency injection
//-rendering
//-communication between modules

import { showCatalog } from './catalog.js';
import { showCreate } from './create.js';
import { showUpdate } from './update.js';
import { showButton } from './loadBtn.js'
import { render } from './util.js';

const body = document.body;

const ctx = {
    update
};

update();

function update() {
    render([
        showButton(ctx),
        showCatalog(ctx),
        showCreate(ctx),
        showUpdate(ctx),
    ], body);
}









