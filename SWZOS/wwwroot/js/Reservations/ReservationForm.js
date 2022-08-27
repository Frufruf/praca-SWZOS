$(function () {

    $("#Duration").on("change", function () {
        CalculatePrice();
    });

    $("#equipmentFormDiv").on("change", ".equipmentSelect", function () {
        CalculatePrice();
    });

    $("#equipmentFormDiv").on("change", ".equipmentQuantity", function () {
        CalculatePrice();
    });

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
        CalculatePrice();
    });

    $("#SubmitReservationForm").on("click", function () {
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
                    console.log(data.errors);
                    $("#validationDiv").html(data.errors[0].errorMessage).addClass("text-danger");
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                window.alert("Wystąpił nieoczekiwany błąd");
                console.log(jqXHR);
                console.log(textStatus);
                console.log(errorThrown);
            }
        });
    });

});

function CalculatePrice() {
    console.log("Calculating price...");
    let duration = $("#Duration").val();
    let fullPrice = pitchPrice * (duration / 60.0);
    let equipment = $(".equipmentForm");

    equipment.each(function (index, element) {
        let itemId = $(element).find("select").val();
        let quantity = $(element).find(".equipmentQuantity").val();
        let itemPrice = pitchEquipment.find(a => a.id == itemId).price;

        fullPrice += (itemPrice * quantity) + (duration / 60.0);
    });
    $("#priceCounterInput").val(fullPrice);
}

function RemoveEquipment(button) {
    let id = $(button).attr("id").split("_")[1];
    $("#equipmentDiv_" + id).remove();
    CalculatePrice();
}

function ValidateReservation() {

}