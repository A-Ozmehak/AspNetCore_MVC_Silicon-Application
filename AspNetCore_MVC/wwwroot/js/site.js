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



// change avatar
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
                document.querySelector('#profileImage').src = data.profileImage;
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
    document.querySelector('#updateProfileImage').submit();
});
