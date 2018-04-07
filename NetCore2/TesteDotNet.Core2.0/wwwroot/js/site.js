$(document).ready(function () {
	$('#modalExclusao').on('show.bs.modal', function (event) {
        var rel = $(event.relatedTarget);
        var dataset = rel[0].dataset;

        $("#nome").text(dataset.nome);
        $("#categoria").text(dataset.categoria);
		$("#id").val(dataset.id);
    });

    $("#busca").focus();
});