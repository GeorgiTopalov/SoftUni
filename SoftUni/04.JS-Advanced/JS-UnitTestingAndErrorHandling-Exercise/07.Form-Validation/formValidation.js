function validate() {
    let submitButtonElement = document.getElementById('submit');
    let isCompanyElement = document.getElementById('company');
    let companyInfoElement = document.getElementById('companyInfo');

    isCompanyElement.addEventListener('change', () => {
        if (isCompanyElement.checked) {
            companyInfoElement.style.display = 'block';
        } else {
            companyInfoElement.style.display = 'none';
        }
    });


    submitButtonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let validationCollection = [];

        let usernameElement = document.getElementById('username');
        let usernamePattern = /^[A-Za-z0-9]{3,20}$/;
        validationCollection.push(validateData(usernameElement, usernameElement.value, usernamePattern))

        let emailElement = document.getElementById('email');
        let emailPattern = /^[A-Za-z0-9+_.-]+@(.+)$/;
        validationCollection.push(validateData(emailElement, emailElement.value, emailPattern));


        let passwordElement = document.getElementById('password');
        let passwordPattern = /^[A-Za-z0-9_]{5,15}$/;
        validationCollection.push(validateData(passwordElement, passwordElement.value, passwordPattern));

        let confirmPassElement = document.getElementById('confirm-password');
        validationCollection.push(validateData(confirmPassElement, confirmPassElement.value, passwordPattern));
        
        if ((passwordElement.value == confirmPassElement.value && confirmPassElement.style.borderColor == 'red') || passwordElement.value != confirmPassElement.value){
            confirmPassElement.style.borderColor = 'red';
        }else{
            confirmPassElement.style.removeProperty('border-color');
        }
        
        


        let companyNumberElement = document.getElementById('companyNumber');

        if (isCompanyElement.checked) {
            let number = Number(companyNumberElement.value);
            let isValid = number >= 1000 && number <= 9999;
            validationCollection.push(isValid)

            if (isValid) {
                companyNumberElement.style.removeProperty('border-color');
            } else {
                companyNumberElement.style.borderColor = 'red';
            }
        }

        let validElement = document.getElementById('valid');

        if (validationCollection.includes(false)) {
            validElement.style.display = 'none';
        } else {
            validElement.style.display = 'block';
        }

        console.log(validationCollection);

        function validateData(element, input, pattern) {
            if (input.match(pattern)) {
                element.style.removeProperty('border-color');
                return true;
            }
            element.style.borderColor = 'red';
            return false;
        }
    });
}
