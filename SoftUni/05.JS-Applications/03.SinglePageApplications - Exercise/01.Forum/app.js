// improve HTML structure
// homePage view
// create app.js module
// create post logic
// placeholders for the two views
// implement comment section views

import { createPost } from "./create.js";
import { loadComments, showView } from "./utils.js";

const home = document.querySelector('nav ul li a');
const form = document.querySelector('#home-page form').addEventListener('click', createPost());


const homePage = document.querySelector('#home-page');
const commentPage = document.querySelector('#comment-page');

showView(commentPage);


home.addEventListener('click',(e) =>{
        showView(homePage);
});

//hideAll();


