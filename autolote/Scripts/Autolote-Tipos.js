$(function () {
    //Obtener el id del automovil seleccionado
    var id =0;

    if ($('#Id').val()) {
        id = $('#Id').val();

    }


    //llenar la lista de marcas
   
            $.getJSON('/Automovil/ListaTiposPorAutomovil/' + id, function (data) {

                var items = "<option>Seleccione un tipo</option>";
                 $.each(data, function (i, item) {
                     
                     if (item.selected) {
                         items += "<option value='" + item.Id + "' selected>" + item.Tipo + "</option>";
                      
                     }

                     else {

                         items += "<option value='" + item.Id + "'>" + item.Tipo + "</option>";
                

                     }

                 });


                 $('#TiposId').html(items);



            });
        




    });