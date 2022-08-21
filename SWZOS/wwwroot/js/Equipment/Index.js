$(function () {

    $("#equipmentTable").DataTable(
    {
        bPaginate: true,
        sDom: '<"H"lfr>t<"F"<"addButtonArea">ip>',
     });

    $("div.addButtonArea").html('<button class="btn btn-primary" id="addEquipment">Dodaj</button>');

    $("#addEquipment").on("click", function () {
        window.location.href = EquipmentUrl.Add;
    });

});

function EditEquipment(equipmentId) {
    window.location.href = EquipmentUrl.Edit + "?id=" + equipmentId;
}