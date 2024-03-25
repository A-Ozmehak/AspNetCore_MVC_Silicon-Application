const toggleMenu = () => {
    document.getElementById('menu').classList.toggle('hide');
    document.getElementById('account-buttons').classList.toggle('hide');
}

const checkScreenSize = () => {
    if (window.innerWidth >= 1200) {
        document.getElementById('menu').classList.remove('hide');
        document.getElementById('account-buttons').classList.remove('hide');
    }
    else {
        if (!document.getElementById('menu').classList.contains('hide'))
            document.getElementById('menu').classList.add('hide');

        if (!document.getElementById('account-buttons').classList.contains('hide'))
            document.getElementById('account-buttons').classList.add('hide');
    }
}

window.addEventListener('resize', checkScreenSize);
checkScreenSize();


// add dark-mode class to elements and classes when it's active
document.getElementById('switch-mode').addEventListener('change', function () {
    document.body.classList.toggle('dark-mode', this.checked);

    var classNames = ['menu-link', 'features', 'box', 'dark-text', 'download-section', 'download-container', 'newsletter-section', 'checkboxLabel', 'btn-social', 'fa-brands', 'course', 'get-started', 'includes', 'outer-circle', 'inner-circle', 'contact', 'form-container', 'btn-gray'];
    let tagNames = ['h1', 'h2', 'h3', 'h4', 'h5', 'h6', 'label', 'p', 'input', 'select', 'span', 'textarea'];

    tagNames.forEach(tag => {
        let elements = document.getElementsByTagName(tag);
        for (let i = 0; i < elements.length; i++) {
            elements[i].classList.toggle('dark-mode', this.checked);
        }
    });

    classNames.forEach(className => {
        let elements = document.getElementsByClassName(className);
        for (let i = 0; i < elements.length; i++) {
            elements[i].classList.toggle('dark-mode', this.checked);
        }
    });

    let errorImage = document.getElementById('error-image');
    let getStartedImage = document.getElementById('get-started-image');
    let logo = document.getElementById('logo');

    if (this.checked) {
        console.log(logo);
        if (errorImage) 
            errorImage.src = "/images/404-white.svg";
        if (getStartedImage)  
            getStartedImage.src = "/images/illustration-dark.svg";
        if (logo)  
            logo.src = "/images/solid-dark.svg";
    } else {
        console.log(logo);

        if (errorImage)    
            errorImage.src = "/images/404.svg";
        if (getStartedImage)
            getStartedImage.src = "/images/illustration.svg";
        if (logo)
            logo.src = "/images/solid.svg";
    }

    var storeImage = document.getElementsByClassName('store-image');
    for (var i = 0; i < storeImage.length; i++) {
        if (this.checked) { 
            storeImage[0].src = "/images/appstore-dark.svg";
            storeImage[1].src = "/images/googleplay-dark.svg"; 
        } else {
            storeImage1[0].src = "/images/appstore.svg";
            storeImage[1].src = "/images/googleplay.svg";
        }
    }
});

document.addEventListener('DOMContentLoaded', () => {
    document.querySelector('#updateProfileImage').addEventListener('submit', event => {
        event.preventDefault();
        let formData = new FormData(event.target);
        fetch(event.target.action, {
            method: event.target.method,
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                document.querySelector('#updateProfileImage').src = data.profileImage;
            })
            .catch(() => {
                alert('An error occurred while uploading the image.');
            });
    });
});


// hide file input field
document.querySelector('#profileImage').addEventListener('click', function () {
    document.querySelector('#fileInput').click();
});

document.querySelector('#fileInput').addEventListener('change', function () {
    document.querySelector('#uploadForm').submit();
});







const formErrorHandler = (element, validationResult) => {
    let spanElement = document.querySelector(`[data-valmsg-for="${element.name}"]`)

    if (validationResult) {
        element.classList.remove('input-validation-error')
        spanElement.classList.remove('field-validation-error')
        spanElement.classList.add('field-validation-valid')
        spanElement.innerHTML = ''
    }
    else {
        element.classList.add('input-validation-error')
        spanElement.classList.add('field-validation-error')
        spanElement.classList.remove('field-validation-valid')
        spanElement.innerHTML = element.dataset.valRequired
    }

}

const compareValidator = (element, compareValue) => {
    if (element.value === compareValue)
        return true;

    return false;
}

const textValidator = (element, minLength = 2) => {
    if (element.value.length >= minLength) {
        formErrorHandler(element, true)
    }
    else {
        formErrorHandler(element, false)
    }
}

const emailValidator = (element) => {
    const regEx = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    formErrorHandler(element, regEx.test(element.value))
}

const passwordValidator = (element) => {
    if (element.dataset.valEqualtoOther !== undefined) {
        let password = document.getElementsByName(element.dataset.valEqualtoOther.replace('*', 'Form'))[0].value

        if (element.value === password)
            formErrorHandler(element, true)
        else
            formErrorHandler(element, false)
    }
    else {
        const regEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,})/;
        formErrorHandler(element, regEx.test(element.value))
    }
}

const checkboxValidator = (element) => {
    if (element.checked)
        formErrorHandler(element, true)
    else
        formErrorHandler(element, false)
}

let forms = document.querySelectorAll('form')
let inputs = forms[0].querySelectorAll('input')

inputs.forEach(input => {
    if (input.dataset.val === 'true') {

        if (input.type === 'checkbox') {
            input.addEventListener('change', (e) => {
                checkboxValidator(e.target)
            })
        }
        else {
            input.addEventListener('keyup', (e) => {
                switch (e.target.type) {
                    case 'text':
                        textValidator(e.target)
                        break;
                    case 'email':
                        emailValidator(e.target)
                        break;
                    case 'password':
                        passwordValidator(e.target)
                        break;
                }
            })
        }
    }
})