let equipmentCounter = 0;

$(function () {

    $("#addEquipment").on("click", function () {
        equipmentCounter++;
        let element = $("#equipmentDiv").clone();
        element.removeAttr("id");
        element.removeAttr("hidden");
        element.attr("id", "equipmentDiv_" + equipmentCounter);
        element.attr("class", "equipmentForm");
        $("#equipmentFormDiv").append(element);

        let removeButton = $("#equipmentDiv_" + equipmentCounter + " .removeEquipment");
        removeButton.attr("id", "removeEquipment_" + equipmentCounter);
    });

    $("#SubmitReservationForm").on("click", function (e) {       
        let equipmentList = [];
        let equipment = $(".equipmentForm");

        equipment.each(function (index, element) {
            equipmentList.push({
                id: $(element).find("select").val(),
                quantity: $(element).find(".equipmentQuantity").val()
            });
        });

        let reservation = {
            userId: $("#UserId").val(),
            pitchTypeId: $("#PitchTypeId").val(),
            startDate: $("#StartDate").val(),
            duration: $("#Duration").val(),
            description: $("#Description").val(),
            isEditForm: false,
            equipmentList: equipmentList
        };

        $.ajax({
            type: "POST",
            url: $("#AddReservationForm").attr("action"),
            data: reservation,
            success: function (data) {
                if (data.success) {
                    window.location.href = ReservationsUrl;
                } else {
                    for (let i = 0; i < data.errors; i++) {
                        console.log(data.errors[i]);
                    }
                }
            },
            error: function () {

            }
        });
    });

});

function RemoveEquipment(button) {
    let id = $(button).attr("id").split("_")[1];
    $("#equipmentDiv_" + id).remove();
}

function ValidateReservation() {

}