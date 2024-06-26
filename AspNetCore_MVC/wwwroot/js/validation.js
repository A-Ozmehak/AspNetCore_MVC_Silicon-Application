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
        let password = document.getElementsByName(element.dataset.valEqualtoOther)[0].value

        if (element.value === password)
            formErrorHandler(element, true)
        else
            formErrorHandler(element, false)
    }
    else {
        const regEx = /^(?=.*[A-Z])(?=.*[!@#$%^&*(),.?":{}|<>])(?=.*[0-9]).{8,}$/;
        formErrorHandler(element, regEx.test(element.value))
    }
}

const checkboxValidator = (element) => {
    const isValid = element.checked;
    formErrorHandler(element, isValid);
}

const textareaValidator = (element, minLength = 5) => {
    if (element.value.length >= minLength)
        formErrorHandler(element, true)
    else
        formErrorHandler(element, false)
}

let forms = document.querySelectorAll('form')

forms.forEach(form => {
    let inputs = form.querySelectorAll('input')
    let textareas = form.querySelectorAll('textarea')

    textareas.forEach(textarea => {
        if (textarea.dataset.val === 'true') {
            textarea.addEventListener('keyup', (e) => {
                textareaValidator(e.target)
            })
        }
    })

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
})
