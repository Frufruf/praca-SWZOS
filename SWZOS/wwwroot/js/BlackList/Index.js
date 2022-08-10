$(function () {
    $("#searchUsers").on("click", function () {
        let searchModel = {
            name: $("#userName").val(),
            surname: $("#userSurname").val(),
            email: $("userEmail").val()
        }

        $.ajax({
            type: "POST",
            url: BlackListUrl.Search,
            data: searchModel,
            dataType: "json",
            success: function (model) {
                if (model.success) {
                    $("#searchedUsersTable > tbody").empty();
                    $("#searchedUsersDiv").attr("hidden", false);

                    for (i = 0; i < model.users.length; i++) {
                        $('#searchedUsersTable > tbody:last-child').append('<tr><td>' + model.users[i].name + '</td><td>'
                            + model.users[i].surname + '</td><td>'
                            + model.users[i].mailAddress + '<td></td>'
                            + model.users[i].phoneNumber + '</td><td>'
                            + '<a href="">Profil</a></tr>');
                    }
                } else {
                    window.alert(model.errorMessage);
                }
            },
            error: function (jqXHR, textStatus, errorThrown ) {
                window.alert("Wystąpił nieoczekiwany błąd");
                console.log(jqXHR);
                console.log(textStatus);
                console.log(errorThrown);
            }
        });
    });
});

function Details(id) {
    window.location.href = BlackListUrl.Details + "?id=" + id;
}