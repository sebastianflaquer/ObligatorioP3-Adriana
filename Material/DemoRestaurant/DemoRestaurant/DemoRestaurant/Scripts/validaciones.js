$(document).ready(initEventos);
function initEventos() {
    $("input[type=submit]").click(function(e)
    {
        var requeridos = $(".requerido");
       var cant = 0;
       requeridos.each(function () {
           var x = $(this).val();
            if(x.length == 0) cant++;
        }
        )
        if (cant > 0) {
            alert("Ningún campo puede estar vacío");
            return false;
        }
        else {
            $("#form1").submit();
            return true;
        }
    })
}