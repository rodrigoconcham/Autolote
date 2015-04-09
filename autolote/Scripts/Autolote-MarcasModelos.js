$(function () {

    //Evento change del dropdownlist de marca
    $('#MarcasId').change(function () {

        if ($('#ModelosId').val()) {
            $.getJSON('/Modelos/ListaModelosPorMarca/' + $('#MarcasId').val(), function (data) {

                var items = $('#ModelosId').children()[0].outerHTML;


                $.each(data, function (i, modelo) {

                    items += "<option value ='" + modelo.Id + "'>" + modelo.Modelo + "</option>";


                });

                $('#ModelosId').html(items);



            });
        }



    });
    //Obtener el Id de la marca seleccionada
    var id = 0;


    if ($('#Id').val()) {
        id = $('#Id').val();

    }

    //llenar la lista de marcas
    $.getJSON('/Marcas/ListaMarcas/' + id, function (data) {

        var items = $('#MarcasId')[0].innerHTML;
        $.each(data, function (i, marca) {

            if (marca.selected) {
                items += "<option value='" + marca.Id + "' selected>" + marca.Marca + "</option>";
                MostrarModelosPorMarca();
            }

            else {

                items += "<option value='" + marca.Id + "'>" + marca.Marca + "</option>";


            }


        });

        $('#MarcasId').html(items);



    });



    function MostrarModelosPorMarca() {

        $.getJSON('/Automovil/ListaModelosPorAutomovil/' + $('#Id').val(), function (data) {

            var items = $('#ModelosId')[0].innerHTML;
            $.each(data, function (i, modelo) {

                if (modelo.selected) {
                    items += "<option value='" + modelo.Id + "' selected>" + modelo.Modelo + "</option>";
              
                }

                else {

                    items += "<option value='" + modelo.Id + "'>" + modelo.Model + "</option>";


                }


            });

            $('#ModelosId').html(items);




        });
   

        }
 





});