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
                $("#ModalLargo").html(html);
                response.forEach(habilidad => {
                    html += "<img src=/" + habilidad.fotoHabilidad + ">";
                    html += "<p>Nombre: "+ habilidad.nombre + "</p>";
                    html += "<p>Tipo: " + habilidad.tipo + "</p>";
                });
                $("#ModalLargo").html(html);
            
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
            let html = "";
            $("#ModalLargo").html(html);
            response.forEach(transformacion => {
                html += "<img src=/" + transformacion.fotoTransformacion + ">";
                html += "<p>Nombre: "+ transformacion.nombre + "</p>";
                html += "<p>Multiplicador: " + transformacion.multiplicadorPoder + "</p>";
            });
            $("#ModalLargo").html(html);
        
        }

})
}

