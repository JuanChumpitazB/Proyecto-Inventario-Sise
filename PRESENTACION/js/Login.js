
$(document).ready(function () {

});


function Login() {
    let usu = $('#txtUsuarioL').val();
    let pwd = $('#txtPasswordL').val();
    var cadena = '{"usuario":' + usu + ', "password":' + pwd + ' }';
    $.ajaxSetup({ async: false });
    $("#ddlProyectos").html('');
    $("#ddlProyectos").append('<option value="">--Seleccione--</option>');
    $.getJSON('/Usuario/Logear', { usuario: usu, password:pwd }
        , function (data) {
            if (typeof (data) == "object") {
                if (data.length > 0) {
                    if (data[0] == "True" && data[1] == "True") {
                        window.location.href = data[2];
                    }
                    else {
                        alert(data[2]);
                    }
                }
            }
        }).fail(function (jqxhr, textStatus, error) {
            alert(error);
        });
}
