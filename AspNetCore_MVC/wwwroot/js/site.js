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


document.getElementById('basicInfoForm').addEventListener('submit', function (event) {
    event.preventDefault(); // Prevent the form from submitting via the browser

    var basicInfoForm = this;
    var addressInfoForm = document.getElementById('addressInfoForm');

    var xhr = new XMLHttpRequest();
    xhr.open(basicInfoForm.method, basicInfoForm.action);
    xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    xhr.onload = function () {
        if (xhr.status === 200) {
            var data = JSON.parse(xhr.responseText);
            // If the server returns a success message, display it
            if (data.successMessage) {
                document.getElementById('successMessage').textContent = data.successMessage;
            }

            // If the server returns updated basic info, update the form fields
            if (data.basicInfo) {
                document.getElementById('form-firstname').value = data.basicInfo.FirstName;
                document.getElementById('form-lastname').value = data.basicInfo.LastName;
                document.getElementById('form-email').value = data.basicInfo.Email;
                document.getElementById('form-phone').value = data.basicInfo.Phone;
                document.getElementById('form-bio').value = data.basicInfo.Biography;
            }

            // If the server returns updated address info, update the form fields
            if (data.addressInfo) {
                document.getElementById('form-addressline-1').value = data.addressInfo.AddressLine_1;
                document.getElementById('form-addressline-2').value = data.addressInfo.AddressLine_2;
                document.getElementById('form-postalcode').value = data.addressInfo.PostalCode;
                document.getElementById('form-city').value = data.addressInfo.City;
            }
        } else if (xhr.status !== 200) {
            var data = JSON.parse(xhr.responseText);
            // If the server returns an error message, display it
            if (data.errorMessage) {
                document.getElementById('errorMessage').textContent = data.errorMessage;
            }
        }
    };
    xhr.send(new URLSearchParams(new FormData(basicInfoForm)).toString() + '&' + new URLSearchParams(new FormData(addressInfoForm)).toString());
});
