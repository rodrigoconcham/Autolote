$(function () {
    //Obtener el id del automovil seleccionado
    var id =0;

    if ($('#Id').val()) {
        id = $('#Id').val();

    }


    //Evento change del dropdownlist de marca
   
            $.getJSON('/Automovil/ListaTiposPorAutomovil/' + id, function (data) {

                var items = "<option>Seleccione un tipo</option>";
                 $.each(data, function (i, item) {
                     
                     if (item.selected) {
                         items += "<option value='" + item.Id + "' selected>" + item.tipos + "</option>";
                         
                     }

                     else {

                         items += "<option value='" + item.Id + "'>" + item.tipos + "</option>";


                     }

                 });


                 $('#TiposId').html(items);



            });
        




    });