$(function(){

    $('#MarcasId').change(function() {

        if ($('#modelosId').val() ) {
            $.getJSON('/Modelos/ListaModelosPorMarca/' + $('#MarcasId').val(),function (data) {

                var items =$('#ModelosId').children()[0].outerHTML;


                $.each(data, function(i,modelo) {

                    items += "<option value ='" + modelo.Id + "'>" + modelo.Modelo + "</option>"


                    });
        
                $('#ModelosId').html(items);
                  
            
            
                });
        }



});
