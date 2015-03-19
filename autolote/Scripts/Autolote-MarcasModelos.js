$(function () {

    $('#MarcasId').change(function () {

        if ($('#modelosId').val()) {
            $.getJSON('/Modelos/ListaModelosPorMarca/' + $('#MarcasId').val(), function (data) {

                var items = $('#ModelosId').children()[0].outerHTML;


                $.each(data, function (i, modelo) {

                    items += "<option value ='" + modelo.Id + "'>" + modelo.Modelo + "</option>"


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


    $.getJSON('/Marcas/ListaMarcas/' + id, function (data) {

        var items = $('#MarcasId')[0].innerHTML;
        $.each(data, function (i, marca) {

            if (marca.selected) {
                items += "<option value='" + marca.id + "' selected>" + marca.Marca + "</option>";
                MostrarModelosPorMarca();
            }

            else {

                items += "<option value='" + marca.id + "'>" + marca.Marca + "</option>";


            }


        });

        $('#MarcasId').html(items);



    });



    function MostrarModelosPorMarca() {

        $.getJSON('/Marcas/ListaModelosPorAutomovil/' + $('#Id').val(), function (data) {

            var items = $('#ModelosId')[0].innerHTML;
            $.each(data, function (i, marca) {

                if (marca.selected) {
                    items += "<option value='" + marca.id + "' selected>" + marca.Marca + "</option>";
                    MostrarModelosPorMarca();
                }

                else {

                    items += "<option value='" + marca.id + "'>" + marca.Marca + "</option>";


                }


            });

            $('#ModelosId').html(items);




        });
   

        }
 





});