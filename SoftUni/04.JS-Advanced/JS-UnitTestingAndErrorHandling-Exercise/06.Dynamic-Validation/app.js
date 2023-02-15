function validate() {
    let pattern = /^[a-z0-9+_.-]+@(.+)$/;
    let emailElement = document.getElementById('email');
    console.log(emailElement.value);
    emailElement.addEventListener('change',()=>{
        if (!emailElement.value.match(pattern)){
            emailElement.className = 'error';
        }else{
            emailElement.className = '';
        }
    });

}