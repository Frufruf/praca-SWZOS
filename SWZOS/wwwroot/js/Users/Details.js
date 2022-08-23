$(function () {
    $("#userReservationsTable").DataTable();
    $("#userPaymentsTable").DataTable();
});

function EditReservation(reservationId) {
    window.location.href = UserUrl.EditReservation + "?reservationId=" + reservationId;
}