﻿$(function () {
    let startDateArray = startDate.split(".").reverse();
    let endDateArray = endDate.split(".").reverse();

    $("#startDate").val(startDateArray.join("-"));
    $("#endDate").val(endDateArray.join("-"));

    $("#reservationsTable").DataTable({
        order: [[2, "asc"]]
    });

    $("#addFootballPitchReservation").on("click", function () {
        window.location.href = ReservationUrl.PickDate + "?pitchTypeId=1"
    });   

    $("#addTenisCourtReservation").on("click", function () {
        window.location.href = ReservationUrl.PickDate + "?pitchTypeId=2"
    });

    $("#addBasketballPitchReservation").on("click", function () {
        window.location.href = ReservationUrl.PickDate + "?pitchTypeId=3"
    });

    $("#addVolleyballPitchReservation").on("click", function () {
        window.location.href = ReservationUrl.PickDate + "?pitchTypeId=4"
    });   

    $("#searchReservations").on("click", function () {
        startDate = $("#startDate").val();
        endDate = $("#endDate").val();
        window.location.href = ReservationUrl.Index + "?startDate=" + startDate + "&endDate=" + endDate;
    });
})

function EditReservation(reservationId) {
    window.location.href = ReservationUrl.EditReservation + "?reservationId=" + reservationId;
}

function CancelReservation(reservationId) {
    $.ajax({
        type: "POST",
        url: ReservationUrl.CancelReservation + "?reservationId=" + reservationId,
        success: function (success) {
            if (success) {
                window.alert("Rezerwacja została anulowana");
                window.location.reload();
            } else {
                window.alert("Nie udało się anulować rezerwacji");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            window.alert("Wystąpił nieoczekiwany błąd");
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }
    });
}