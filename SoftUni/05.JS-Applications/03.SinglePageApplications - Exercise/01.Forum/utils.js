function hideAll() {
    document.querySelectorAll('.view-section').forEach(v => v.style.display = 'none');
}

function showView(selection) {
    hideAll();
    selection.style.display = 'block';
}

 async function loadComments(){
    const resp = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
    const data = await resp.json();

    console.log(Object.values(data));
   // createPost(data);
} 
export {
    showView,
    loadComments,
};