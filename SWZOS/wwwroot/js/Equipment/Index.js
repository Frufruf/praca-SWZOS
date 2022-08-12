$(function () {

    $("#equipmentTable").DataTable();

});

function EditEquipment(equipmentId) {
    window.location.href = EquipmentUrl.Edit + "?id=" + equipmentId;
}