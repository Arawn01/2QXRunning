$(function () {
    $('.dateTimePicker').datetimepicker({
        locale: 'fr',
        format: 'DD/MM/YYYY HH:mm'
    });
});

$(function () {
    $('.datePicker').datetimepicker({
        locale: 'fr',
        format: 'DD/MM/YYYY'
    });
});


$("#formAccueil").on("submit", function (e) {

    var x = document.forms["formAccueil"]["ville-id"].value;
    if (x == -1) {
        $("#inputGroupVille").addClass("has-warning");
        $("#inputGroupVille").removeClass("has-success");
        e.preventDefault();
    };
});


$(function () {
    $(".evenement").hover(function () {
        $(this).css("background-color", "rgba(5,5,5,0.2)");
    }, function () {
        $(this).css("background-color", "rgba(220,220,220,0.3)");
    });
});

