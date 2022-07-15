function EditPrice(typeId, id) {
    if (typeId == 1) {
        window.location.href = PriceListUrl.EditPitchType + "?typeId=" + id;
    } else if (typeId == 2) {
        window.location.href = PriceListUrl.EditEquipment + "?id=" + id;
    } else {

    }
}