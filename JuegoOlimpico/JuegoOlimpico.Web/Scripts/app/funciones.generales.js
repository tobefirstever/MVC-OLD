var varbaseUrl = "hola";
function quitaDec(me) {
    var txt = me.value;
    if (txt.indexOf(".") > -1 && txt.split(".")[1].length > 2) {
        var substr = txt.split(".")[1].substring(0, 2);
        me.value = txt.split(".")[0] + "." + substr;
    }
}

function MostrarMensaje(titulo, mensaje, callfunction) {
    $("#lblTitleMessageBox").text(titulo);
    $("#lblMessageBox").text(mensaje);
    $("#div-message-box").modal('show');
    if (callfunction != null) {
        $("#div-message-box").on('hide.bs.modal', function () {
            callfunction();
        });
    }
    else {
        $("#div-message-box").unbind('hide');
    }
}

function CerrarMensaje() {
    $("#div-message-box").modal('hide');
}

$(document).on('click', '#select-all', function () {
    if (this.checked) {
        // Iterate each checkbox
        $(':checkbox').each(function () {
            this.checked = true;
        });
    }
    else {
        $(':checkbox').each(function () {
            this.checked = false;
        });
    }
});

$(document).on('click', '.error', function () {
    $(this).addClass('field-validation-valid');
    $(this).removeClass('campo-validacion-error');
});

$body = $("body");

$(document).on({
    ajaxStart: function () { $body.addClass("loading"); },
    ajaxStop: function () { $body.removeClass("loading"); }
});

function daysInMonth(m, y) { // m is 0 indexed: 0-11
    switch (m) {
        case 1:
            return (y % 4 == 0 && y % 100) || y % 400 == 0 ? 29 : 28;
        case 8: case 3: case 5: case 10:
            return 30;
        default:
            return 31
    }
}

function ValidarHora(hora) {
    if (hora.value.trim() != "") {
        var reGoodDate = new RegExp("^\\d{2}\\:\\d{2}$");
        if (reGoodDate.test(hora.value)) {
            if (ConsistenciarHoraMinuto(hora.value) == false) {
                alert("La hora ingresada no es correcta.");
                hora.value = "";
                hora.focus();
            }
        }
        else {
            alert("La hora ingresada no es correcta.");
            hora.value = "";
            hora.focus();
        }
    }
}

function ConsistenciarHoraMinuto(p_hora) {
    var hora = p_hora.substring(0, 2);
    var minuto = p_hora.substring(3, 5);

    var intHora = parseInt(hora, 10);
    var intMinuto = parseInt(minuto, 10);

    if (isNaN(intHora) || isNaN(intMinuto)) {
        return false;
    }

    if (intHora < 0 || intHora > 23) {
        return false;
    }

    if (intMinuto < 0 || intMinuto > 59) {
        return false;
    }

    return true;
}

function formatearFecha(control) {
    if (control.value.length == 2 || control.value.length == 5)
        control.value = control.value + "/";
}

function validarFecha(control, idFecha, flagComparar) {
    if (control.value.length != 0) {
        if (control.value.length != 10) {
            alert("La " + idFecha + " ingresada no es correcta.");
            control.value = "";
            control.focus();
        } else {
            if (validate_fecha(control.value) == false) {
                alert("La " + idFecha + " ingresada no es correcta.");
                control.value = "";
                control.focus();
            } else {
                if (flagComparar && compararFechaActual(control.value) == false) {
                    alert("La " + idFecha + " no puede ser mayor que la fecha actual.");
                    control.value = "";
                    control.focus();
                }
            }
        }
    }
}

function validate_fecha(fecha) {
    var arrayFecha = fecha.split("/");

    if (arrayFecha.length != 3 || arrayFecha[0] == "" || arrayFecha[1] == "" || arrayFecha[2] == "")
        return false;

    var anio = parseInt(quitaCeros(arrayFecha[2]));
    var mes = parseInt(quitaCeros(arrayFecha[1]));
    var dia = parseInt(quitaCeros(arrayFecha[0]));

    if (dia > 31 || mes > 12)
        return false;

    //Comprobamos meses de 30 días
    if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && dia > 30)
        return false;

    //Comprobamos mes febrero y bisiestos
    if (mes == 2 && (dia > 29 || (dia == 29 && ((anio % 400 != 0) && ((anio % 4 != 0) || (anio % 100 == 0))))))
        return false;

    return true;
}

function quitaCeros(cad) {
    var enc = false;
    var i = 0;
    while (i < cad.length && !enc) {
        if (cad.charAt(i) == '0') {
            i++;
        } else {
            enc = true;
        }
    }
    return (cad.substring(i, cad.length));
}

function validarFechas(control, idFecha, msgFecha, controlCompare) {

    if (control.value.length != 0) {
        if (control.value.length != 10) {
            alert("La " + msgFecha + " ingresada no es correcta.");
            control.value = "";
            control.focus();
        } else {
            if (validate_fecha(control.value) == false) {
                alert("La " + msgFecha + " ingresada no es correcta.");
                control.value = "";
                control.focus();
            } else {
                if (compararFechaActual(control.value) == false) {
                    alert("La " + msgFecha + " no puede ser mayor que la fecha actual.");
                    control.value = "";
                    control.focus();
                } else {
                    if (control.value.length == 10 && controlCompare.value.length == 10) {
                        if (idFecha == "I") {
                            if (compararFechas(control.value, controlCompare.value) == false) {
                                alert("La " + msgFecha + " no puede ser mayor que la fecha final.");
                                control.value = "";
                                control.focus();
                            }
                        }
                        else {
                            if (compararFechas(controlCompare.value, control.value) == false) {
                                alert("La " + msgFecha + " no puede ser menor que la fecha inicial.");
                                control.value = "";
                                control.focus();
                            }
                        }
                    }
                }
            }
        }
    }
}

function compararFechas(fechaIni, fechaFin) {
    var myDateI = fechaIni.split("/");
    var myDateF = fechaFin.split("/");
    var ini = new Date(myDateI[1] + "/" + myDateI[0] + "/" + myDateI[2]).getTime();
    var fin = new Date(myDateF[1] + "/" + myDateF[0] + "/" + myDateF[2]).getTime();
    if (ini > fin) return false;
    else return true;
}

function compararFechaActual(fecha) {
    var f = new Date();
    var fechaActual = new Date((f.getMonth() + 1) + "/" + f.getDate() + "/" + f.getFullYear());
    var myDate = fecha.split("/");
    var fechaIngresada = new Date(myDate[1] + "/" + myDate[0] + "/" + myDate[2]).getTime();
    if (fechaIngresada > fechaActual) return false;
    else return true;
}

function compareFechas(fechaIni, fechaFin) {
    var myDateI = fechaIni.split("/");
    var myDateF = fechaFin.split("/");
    var ini = new Date(myDateI[1] + "/" + myDateI[0] + "/" + myDateI[2]).getTime();
    var fin = new Date(myDateF[1] + "/" + myDateF[0] + "/" + myDateF[2]).getTime();
    if (ini > fin) {
        alert("La fecha final no puede ser menor que la fecha inicial.")
        return false;
    }
    return true;
}

function formatearFecha(control) {
    if (control.value.length == 2 || control.value.length == 5)
        control.value = control.value + "/";
}

function ValidaFormatoFechasDinamicas(e, control) {
    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    if (tecla == 8) return true;
    patron = /[0-9\/]/;
    te = String.fromCharCode(tecla);
    if (patron.test(te) == false)
        return false;
    else if (patron.test(te) == true && (control.value.length == 2 || control.value.length == 5))
        control.value = control.value + "/";
}

function validarFechaDinamica(control, idFecha) {
    if (control.value.length != 0) {
        if (control.value.length != 10) {
            alert("La " + idFecha + " ingresada no es correcta.");
            control.value = "";
            control.focus();
        } else {
            if (validate_fecha(control.value) == false) {
                alert("La " + idFecha + " ingresada no es correcta.");
                control.value = "";
                control.focus();
            } else {
                var maxYear = (new Date()).getFullYear() + 1;
                var arrayFecha = control.value.split("/");
                if (arrayFecha[2] > maxYear) {
                    alert("La " + idFecha + " ingresada no puede ser mayor al 31/12/" + maxYear);
                    control.value = "";
                    control.focus();
                }
            }
        }
    }
}

// Función que suma o resta días a la fecha indicada
function SumarFecha(d, fecha, tipo) {
    var Fecha = new Date();
    var sFecha = fecha || (Fecha.getDate() + "/" + (Fecha.getMonth() + 1) + "/" + Fecha.getFullYear());
    var sep = sFecha.indexOf('/') != -1 ? '/' : '-';
    var aFecha = sFecha.split(sep);
    var fecha = aFecha[2] + '/' + aFecha[1] + '/' + aFecha[0];
    fecha = new Date(fecha);

    if (tipo == "S") {
        fecha.setDate(fecha.getDate() + parseInt(d));
    }
    else {
        fecha.setDate(fecha.getDate() - parseInt(d));
    }
    var anno = fecha.getFullYear();
    var mes = fecha.getMonth() + 1;
    var dia = fecha.getDate();
    mes = (mes < 10) ? ("0" + mes) : mes;
    dia = (dia < 10) ? ("0" + dia) : dia;
    var fechaFinal = dia + sep + mes + sep + anno;
    return (fechaFinal);
}

function OnlyNumeric(e) {
    var key = e.which ? e.which : e.keyCode;
    if ((key < 48 || key > 57)) {
        if (key == 8 || key == 46 || key == 0) {
            return true;
        }
        else {
            return false;
        }
    }
}

function ValidaNumero(e) {
    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    return ((tecla > 47 && tecla < 58));
}

function ValidaLetraExcel(e) {
    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    return ((tecla > 64 && tecla < 91) || (tecla > 96 && tecla < 123));
}

function ValidaCaracteresFecha(e) {
    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    if (tecla == 8) return true;
    patron = /[0-9\/]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function FormateoNumeroCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

function ValidaNumerosYLetras(e) {
    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    if (tecla == 8) return true;
    patron = /[0-9A-Za-z\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function ValidaLetras(e) {
    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    if (tecla == 8) return true;
    patron = /[A-Za-záÁéÉíÍóÓúÚñÑ\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}


function ValidaLetrasComma(e) {
    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    if (tecla == 8) return true;
    patron = /[A-Za-z,\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function ValidaNumerosYLetrasYComma(e) {
    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
    if (tecla == 8) return true;
    patron = /[0-9A-Za-z,\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

//$(".div-modal").draggable({
//    handle: ".modal-header"
//});


//DESCOMENTAR
//$(".modal-dialog").draggable({
//    handle: ".modal-header"
//});

function formatearNumero(num) {
    var
        simbol = "",
        separador = ",", // separador para los miles
        sepDecimal = ".", // separador para los decimales
        formatear = function (num) {
            if (num == null) {
                return "";
            }
            num += '';
            var splitStr = num.split('.');
            var splitLeft = splitStr[0];
            var decimalPart = "";
            if (splitStr[1] == null) {
                decimalPart = "00";
            } else {
                decimalPart = splitStr[1];
            }
            var splitRight = splitStr.length >= 1 ? sepDecimal + decimalPart : '';
            var regx = /(\d+)(\d{3})/;
            while (regx.test(splitLeft)) {
                splitLeft = splitLeft.replace(regx, '$1' + separador + '$2');
            }
            return simbol + splitLeft + splitRight;
        },
        nuevo = function (num, simbol) {
            simbol = simbol || '';
            return formatear(num);
        };
    return formatear(num);
}
//formatearNumero(1212121)

function baseUrl() {
    var getUrl = window.location;
    return getUrl.protocol + "//" + getUrl.host + "/";
}



var vg_sTodosCaracteres = ' !#$%&\()*+,./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz�����{|}~-';
var vg_sAlfaNumerico = '1234567890������-';


(function (a) {
    a.fn.fn_util_validarAlfaNumerico_a = function () {
        var id = jQuery(this).attr("id");
        a(this).on({
            keypress: function (a) {
                var c = a.which,
                    d = a.keyCode,
                    e = String.fromCharCode(c).toLowerCase(),
                    f = vg_sAlfaNumerico;
                (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || a.preventDefault()
            },
            focusout: function (a) {
                var pDiferente = new RegExp("[" + vg_sAlfaNumerico + "]", 'gi');
                var sDiferente = vg_sTodosCaracteres.replace(pDiferente, '');
                var pFinal = new RegExp("[" + sDiferente + "]", 'gi');
                var sFinal = jQuery(this).val();
                sFinal = sFinal.replace(pFinal, '');
                jQuery(this).val(sFinal);
            }
        })
    }
})(jQuery);





var vg_sTodosCaracteres1 = ' !#$%&\()*+,./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz�����{|}~-';
var vg_sAlfaNumerico1 = '1234567890abcdefghijklmn�opqrstuvwxyz�����-';

(function (a) {
    a.fn.fn_util_validarAlfaNumerico_b = function () {
        var id = jQuery(this).attr("id");
        a(this).on({
            keypress: function (a) {
                var c = a.which,
                    d = a.keyCode,
                    e = String.fromCharCode(c).toLowerCase(),
                    f = vg_sAlfaNumerico1;
                (-1 != f.indexOf(e) || 9 == d || 37 != c && 37 == d || 39 == d && 39 != c || 8 == d || 46 == d && 46 != c) && 161 != c || a.preventDefault()
            },
            focusout: function (a) {
                var pDiferente = new RegExp("[" + vg_sAlfaNumerico1 + "]", 'gi');
                var sDiferente = vg_sTodosCaracteres1.replace(pDiferente, '');
                var pFinal = new RegExp("[" + sDiferente + "]", 'gi');
                var sFinal = jQuery(this).val();
                sFinal = sFinal.replace(pFinal, '');
                jQuery(this).val(sFinal);
            }
        })
    }
})(jQuery);
