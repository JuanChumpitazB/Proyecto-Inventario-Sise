
$(document).ready(function () {

});


function Login() {
    let usu = $('#txtUsuarioL').val();
    let pwd = $('#txtPasswordL').val();
    var cadena = '{"usuario":' + stringify(usu) + ', "password":' + stringify(pwd) + ' }';
    $.ajax({
        url: "/WepAppMVC/Usuario/Logear",
        data: cadena,  //  "{}",
        type: "POST",
        dataType: "json",
        async: false,
        success: function (jsondata) {
            if (typeof (jsondata) == "object") {
                if (jsondata.lenght > 0) {
                    if (jsondata[0] == true && jsondata[1] == true) {
                        window.location.href = jsondata[2];
                    }
                    else {
                        alert(jsondata[2]);
                    }
                }
                else {
                    bandera = false;
                }
            }
        }
    }).fail(function (jqxhr, textStatus, error) {
        var err = textStatus + ", " + error;
        alert(err);
        bandera = true;
    });
}
