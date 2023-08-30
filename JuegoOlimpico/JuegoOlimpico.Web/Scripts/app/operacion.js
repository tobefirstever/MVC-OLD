
var arrFilas = [];
var arrEditar = [];
var arrEliminar = [];

$(document).ready(function () {
    $.jgrid.defaults.responsive = true;
    $.jgrid.defaults.styleUI = 'Bootstrap';

    fn_iniciarVista();

    $("#btnCrear").click(function () {
        fn_cargarModalCrear(0);
    });

});



function fn_iniciarVista() {

    $("#jqGridOpCob").jqGrid({
        url: $("#listado-sedes").data('request-url'),
        postData: {
            idPais: function () { return jQuery("#hdIdPais").val(); } //ddlEstadoCredCob option:selected
        },
        datatype: 'json',
        mtype: 'Post',
        colNames: ['EDT', 'ELI', 'IdSede', 'NombreSede', 'NombrePais', 'NroComplejos',
            'Presupuesto'],
        colModel: [
            { name: 'Edit', formatter: bntEdit, align: 'center', width: 70 },
            { name: 'Eli',  formatter: btnEli, align: 'center', width: 70 },
            { key: true, hidden: true, name: 'IdSede', index: 'IdSede', editable: true },
            { key: false, name: 'NombreSede', index: 'NombreSede', editable: true },
            { key: false, name: 'NombrePais', index: 'NombrePais', editable: true },
            { key: false, name: 'NroComplejos', index: 'NroComplejos', editable: true },
            { key: false, name: 'Presupuesto', index: 'Presupuesto', editable: true }

        ],
        pager: jQuery('#jqGridPagerOpCob'),
        rowNum: 10,
        rowList: [10, 20, 30, 40],
        height: '100%',
        viewrecords: true,
        loadonce: false,
        emptyrecords: 'No se encontraron datos',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: true,
        search: true,
        beforeSelectRow: function (rowid, e) {
            var $myGrid = $(this);
            if ($(e.target).closest('td')[0] != undefined) {
                var i = $.jgrid.getCellIndex($(e.target).closest('td')[0]);
                var cm = $myGrid.jqGrid('getGridParam', 'colModel');

                return (cm[i].name === 'cb');
            }
            else {
                return false;
            }
        },
        onSelectRow: function (rowid, status, e) {
            if (status) {
                fn_cargarSeleccion(rowid, status);
            }
            else {
                fn_cargarSeleccion(rowid, status);
            }
        },
        onSelectAll: function (aRowids, status) {
            if (!status) {
                for (var i = arrFilas.length; i > 0; i--) { arrFilas.pop(); }
            }
        },
        loadComplete: function () {
            $(this).find(">tbody>tr.jqgrow:odd").addClass("myAltRowClassEven");
            $(this).find(">tbody>tr.jqgrow:even").addClass("myAltRowClassOdd");

        },
        emptyDataText: 'There are no records. If you would like to add one, click the "Add New ..." button below.',
        gridComplete: function () {
            var recs = parseInt($("#jqGridOpCob").getGridParam("records"), 10);
            var emptyText = grid.getGridParam('emptyDataText');
            if (isNaN(recs) || recs == 0) {
                $("#jqGridPagerOpCob_left").hide();
                $("#jqGridPagerOpCob_center").hide();
            }
            else {
                $("#jqGridPagerOpCob_left").show();
                $("#jqGridPagerOpCob_center").show();
            }
        }
    })
    $('#btnBuscar').click(function (event) {
        event.preventDefault();

      
        $("#hdIdPais").val($("#ddlPais option:selected").val());

        filterGrid();
        $("#jqGridPagerOpCob_left").show();
        $("#jqGridPagerOpCob_center").show();

        fn_BuscarOperacionCoberturada();

    });
    function bntEdit(cellvalue, options, rowObject) {
        return '<a style="text-align:center !important;"  onClick=fn_EditarOpCob(' + rowObject.IdSede + "," + rowObject.IdPais + ');><span class="glyphicon glyphicon-edit icon-grid"></span></a>';
    };
    function btnEli(cellvalue, options, rowObject) {
     
        return '<a style="text-align:center;"  onClick=fn_EliminarOpCob(' + rowObject.IdSede + ');><span class="glyphicon glyphicon-trash icon-grid"></span></a>';
        
        
    }
    var myReload = function () {
        myGrid.trigger('reloadGrid');
    };
   
    var grid = jQuery("#jqGridOpCob");
    grid.find('th input[type="checkbox"]').hide();
}


function filterGrid() {
    var postDataValues = $("#jqGridOpCob").jqGrid('getGridParam', 'postData');

    $('#jqGridOpCob').jqGrid().setGridParam(
        {
            postData: postDataValues,
            page: 1
        }).trigger('reloadGrid');

    $("#jqGridPagerOpCob_left").show();
    $("#jqGridPagerOpCob_center").show();
}

function fn_BuscarOperacionCoberturada() {
    var postDataValues = $("#jqGridOpCob").jqGrid('getGridParam', 'postData');

    $('#jqGridOpCob').jqGrid().setGridParam(
        {
            postData: postDataValues,
            page: 1
        }).trigger('reloadGrid');

    $("#jqGridPagerOpCob_left").show();
    $("#jqGridPagerOpCob_center").show();

}

function fn_EliminarOpCob(id) {
    var rowData = $('#jqGridOpCob').jqGrid('getRowData', id);
   
   

    var data = new EliminarSedeModel();
    data.IdSede = id;
    

    if (confirm('¿Está seguro de eliminar el registro seleccionada?')) {
        $.ajax({
            url: $("#opcob-eliminar").data('request-url'),
            contentType: "application/json",
            type: "POST",
            data: JSON.stringify(data),
            success: function (data) {
                if (data.UnAuthorizedMessage) {
                    alert(data.UnAuthorizedMessage);
                    location.reload();
                }
                else {
                    if (data.Valid) {
                        for (var i = arrFilas.length; i > 0; i--) { arrFilas.pop(); }
                        alert('ok');
                        $("#jqGridOpCob").trigger("reloadGrid");
                        return;
                    } else {
                        alert("hubo un error");
                        return;
                    }

                    $.each(data.Errors, function (key, value) {
                        if (value != null) {
                            alert(value[value.length - 1].ErrorMessage);
                        }
                    });
                }
            },
            error: function (reponse) {
                alert("Error Inesperado, contacte al administrador de sistemas");
                location.reload();
            }
        });
    }
}


function fn_EditarOpCob(id, IdPais) {

    var rowData = $('#jqGridOpCob').jqGrid('getRowData', id);


    fn_cargarModalCrear(id);
}


function fn_cargarModalCrear(id) {
    var data = new SedeModel();
    data.IdSede = id;
    $.ajax({
        type: "POST",
        url: $("#modal-operacioncoberturada").data('request-url'),
        data: data,
        success: function (response) {
            if (response.UnAuthorizedMessage) {
                alert(response.UnAuthorizedMessage);
                location.reload();
            }
            else {
                $('#crear-operacion').modal('show');
                $("#div-creacion").html(response.PartialConfiguracion);
            }
        },
        error: function (reponse) {

            alert("Error Inesperado, contacte al administrador de sistemas");
            location.reload();
        }
    });
}

function SedeModel() {
    return {
        IdSede: 0
    };
}

function EliminarSedeModel() {
    return {
        IdSede: 0
    };
}

function fn_cargarSeleccion(id, status) {
    if (status) {
        arrFilas.push({
            id: id,
            status: status
        });
    }
    else {
        if (arrFilas.length > 0) {
            for (var i = 0; i < arrFilas.length; i++) {
                if (arrFilas[i].id == id) {
                    var index = arrFilas.map(function (x) { return x.id; }).indexOf(id);
                    arrFilas.splice(index, 1);
                }
            }
        }
    }
}