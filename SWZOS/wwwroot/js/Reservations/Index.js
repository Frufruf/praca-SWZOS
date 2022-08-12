$(function () {

    $("#reservationsTable").DataTable();

    $("#addFootballPitchReservation").on("click", function () {
        window.location.href = ReservationUrl.AddReservation + "?pitchTypeId=1"
    });

    $("#addTenisCourtReservation").on("click", function () {
        window.location.href = ReservationUrl.AddReservation + "?pitchTypeId=2"
    });

    $("#addBasketballPitchReservation").on("click", function () {
        window.location.href = ReservationUrl.AddReservation + "?pitchTypeId=3"
    });

    $("#addVolleyballPitchReservation").on("click", function () {
        window.location.href = ReservationUrl.AddReservation + "?pitchTypeId=4"
    });
})