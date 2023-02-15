window.addEventListener('DOMContentLoaded', ()=>{
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    if(userData != null){
        document.getElementById('guest').style.display = 'none';
        
    }else{
        document.getElementById('user').style.display = 'none';
    
    }
    });