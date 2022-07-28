(function () {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')
    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })


/*** Init Toast ***/
    toastr.options = {
        "progressBar": true
    }
})()

function ConfirmSwalMessage(title, message, btnConfirmText, btnCancelText, action) {
    Swal.fire({
        title: title,
        text: message,
        icon: 'warning',
        showCancelButton: !0,
        confirmButtonColor: '#34c38f',
        cancelButtonColor: '#f46a6a',
        confirmButtonText: btnConfirmText
        //cancelButtonText: btnCancelText,
    }).then((result) => {
        if (result.value) {
            window.location.href = action;
        }
    })
}