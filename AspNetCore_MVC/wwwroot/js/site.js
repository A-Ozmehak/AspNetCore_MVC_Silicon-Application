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

    let errorImage = document.getElementById('error');
    if (this.checked) {
        errorImage.src = "/images/404-white.svg";
    } else {
        errorImage.src = "/images/404.svg";
    }
});