$(function () {
    $("#userReservationsTable").DataTable();
    $("#userPaymentsTable").DataTable();
});

function EditReservation(reservationId) {
    window.location.href = UserUrl.EditReservation + "?reservationId=" + reservationId;
}

function AddToBlackList(userId) {
    window.location.href = UserUrl.AddToBlackList + "?userId=" + userId;
}

function EditProfile(userId) {
    window.location.href = UserUrl.EditProfile + "?userId=" + userId;
}