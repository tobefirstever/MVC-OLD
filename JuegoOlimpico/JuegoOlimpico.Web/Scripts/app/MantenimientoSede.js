
$(document).ready(function () {

  
  
   
    $("#btnGrabarModal").click(function () {
     
        
            fn_grabarModal();
        
    });

   

    $("#btnLimpiarModal").click(function () {
        fn_limpiarModal();
    });

    $("#btnCancelarModal").click(function () {
        fn_cancelarModal();
    });


    $('#crear-operacion').on('hidden.bs.modal', function () {
        $('#div-creacion').empty();
    });
});

function fn_cancelarModal() {
    $('#crear-operacion').modal('hide');
    $('#div-creacion').empty();
}
function fn_grabarModal() {
    if (confirm('¿Está seguro que desea guardar los datos?')) {
        var data = new RegistrarSedeModel();
        data.IdSede = $("#hdnIdSede").val();
        data.NombreSede = $("#txtSede").val();
        data.IdPais = $("#ddlPaisModal").val();
        data.NroComplejos = $("#txtNroComplejos").val();
        data.Presupuesto = $("#txtPresupuestoModal").val();

       

        $.ajax({
            url: $("#opcob-registrar").data('request-url'),
            contentType: "application/json",
            type: "POST",
            data: JSON.stringify(data),

            success: function (data) {
                if (data.UnAuthorizedMessage) {
                    alert(data.UnAuthorizedMessage);
                    location.reload();
                }
                else {
                    $("#error").removeClass("field-validation-error");
                    $("#error").addClass("field-validation-valid");
                    $("#btnGrabar").removeAttr("disabled");
                    if (data.Valid) {
                        alert(data.Mensaje);
                        $("#crear-operacion").modal("hide");
                        for (var i = arrFilas.length; i > 0; i--) { arrFilas.pop(); }
                        $('#jqGridOpCob').trigger('reloadGrid');
                        return;
                    } else {

                        if (data.Mensaje != "") {
                            alert(data.Mensaje);
                            return;
                        }
                    }
                    return;
                }
            },
            error: function (reponse) {
                alert("Error Inesperado, contacte al administrador de sistemas");
                location.reload();
            }
        });
    }
}

function RegistrarSedeModel() {
    return {
        IdSede: 0,
        NombreSede: '',
        IdPais: 0,
        NroComplejos: 0,
        Presupuesto: 0
    };
}


