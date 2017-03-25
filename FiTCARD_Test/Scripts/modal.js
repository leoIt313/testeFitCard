$.fn.setModalAlerta = function () {
    $(this).find(".modal-footer").css("display", "none");
}

$.fn.setModalPergunta = function () {
    $(this).find(".modal-footer").css("display", "block");
    $("#btnModalOk").text("Sim");
    $("#btnModalCancel").text("Não");
}

$.fn.setModalComum = function () {
    $(this).find(".modal-footer").css("display", "block");
    $("#btnModalOk").text("Salvar");
    $("#btnModalCancel").text("Cancelar");
}
