$(function () {

    $("#pitchesButton").on("click", function () {
        window.location.href = AdminUrl.PitchUrl;
    });

    $("#equipmentButton").on("click", function () {
        window.location.href = AdminUrl.EquipmentUrl;
    });

    $("#blackListButton").on("click", function () {
        window.location.href = AdminUrl.BlackListUrl;
    });

    //$("#priceListButton").on("click", function () {
    //    window.location.href = AdminUrl.PriceListUrl;
    //});

    //$("#approvalsButton").on("click", function () {
    //    window.location.href = AdminUrl.ApprovalUrl;
    //});

});