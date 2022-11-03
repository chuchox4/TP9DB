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

function VerHabilidadesAjax(IDP) 
{
    $.ajax({
        url: '/Home/VerHabilidadesAjax',
        data: {IdPersonaje : IDP},
        type: 'POST',
        dataType: 'JSON',
        success:
            function(response)
            {
                let html = "";
                response.forEach(habilidad => {
                    html += "<img src=/" + habilidad.fotoHabilidad + ">";
                    html += "<p>Nombre: "+ habilidad.nombre + "</p>";
                    html += "<p>Tipo: " + habilidad.tipo + "</p>";
                });
                $("#TextoModalHabilidades").html(html);
            
            }
    
    })
}

function VerTransformacionesAjax(IDP) 
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

