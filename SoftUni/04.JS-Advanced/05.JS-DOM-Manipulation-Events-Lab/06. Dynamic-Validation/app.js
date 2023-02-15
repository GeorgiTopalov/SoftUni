function validate() {
    let inputElement = document.getElementById('email');

    let pattern = /^([\a-z\-.]+)@([a-z]+)(\.[a-z]+)+$/;

    inputElement.addEventListener('change', (e) => {
        if (!inputElement.value.match(pattern)){
            e.target.classList.add('error');
        }else{
            e.target.classList.remove('error');
        }
    });

}