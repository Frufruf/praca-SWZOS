$(function () {
    $('#SubmitUserForm').on('click', function () {
        //TODO na późniejszym etapie walidacja

        let form = $('#UserForm');
        let formData = new FormData(form[0]);

        $.ajax({
            type: 'POST',
            url: UserFormUrl.AddUserUrl,
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.success) {

                } else {
                    alert(data.errorMessage);
                }
            },
            error: function (error) {

            }
        });
    });
});