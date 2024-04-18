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


// change between dark and light theme
document.addEventListener('DOMContentLoaded', function () {
    let sw = document.querySelector('#switch-mode')

    sw.addEventListener('change', function () {
        let theme = this.checked ? "dark" : "light";
        document.body.className = theme;

        fetch(`/sitesettings/changetheme?theme=${theme}`)
            .then(res => {
                if (res.ok)
                    window.location.reload()
                else
                    console.log("something")
            })
    })
})


document.addEventListener('DOMContentLoaded', function () {
    handleProfileImageUpload();
})


function handleProfileImageUpload() {
    try {
        let fileUploder = document.getElementById('fileInput')

        if (fileUploder != undefined) {
            fileUploder.addEventListener('change', function () {
                if (this.files.length > 0) {
                    this.form.submit()
                }
            })
        }
    }
    catch { }
}