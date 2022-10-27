function VerInfoSagas(IDS) 
{
    $.ajax({
        url: '/Home/VerInfoSagasAjax',
        data: {IdSaga : IDS},
        type: 'POST',
        dataType: 'JSON',
        success:
            function(response)
            {
                $("#Titulo").html("Info: ")
                $("#DescripcionSaga").html("Informacion: " + response.informacion);

            }
    
    })
}

function VerHabilidades(IDP) 
{
    $.ajax({
        url: '/Home/VerHabilidadesAjax',
        data: {IdPersonaje : IDP},
        type: 'POST',
        dataType: 'JSON',
        success:
            function(response)
            {
                var datos = "";
                response.forEach(habilidad => {
                    datos += '<li> Habilidades ' + habilidad.nombre + '</li>'; 
                    datos += '<img src="' + habilidad.fotoHabilidad + '">';
                    datos += '<li>' + habilidad.tipo + '</li>'
                });
                $("#Titulo").html("Habilidades: ")
                $("#DescripcionHabilidad").html(datos);
            }
    
    })
}

function VerTransformaciones(IDP) 
{
    $.ajax({
        url: '/Home/VerTransformacionesAjax',
        data: {IdPersonaje : IDP},
        type: 'POST',
        dataType: 'JSON',
        success:
            function(response)
            {
                var transformacion = "";
                response.forEach(element => {
                temp += element.numeroTemporada + " " + element.tituloTemporada + "<br/>";
      });
                $("#Titulo").html("Temporadas: ");
                $("#DescripcionSerie").html(temp);

            }
    
    })
}

