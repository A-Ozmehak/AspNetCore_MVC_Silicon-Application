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