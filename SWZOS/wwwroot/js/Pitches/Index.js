﻿$(function () {

    $("#pitchesTable").DataTable();

});

function EditPitch(id) {
    window.location.href = PitchUrl.EditPitch + "?pitchId=" + id;
}