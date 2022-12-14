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

function VerHabilidadesAjax(IDP,IDS) 
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
                    html += "<p>------------------------------------------------------------------------</p>";
                });
                html +="<a href=/Home/AgregarHabilidad?IdPersonaje="+IDP.toString()+"&IdSaga="+IDS.toString()+" class='btn btn-primary'>Agregar Habilidad</a>";
                $("#ModalLargo").html(html);
            
            }
    
    })
}

function VerTransformacionesAjax(IDP,IDS) 
{
    $.ajax({
        url: '/Home/VerTransformacionesAjax',
        data: {IdPersonaje : IDP},
        type: 'POST',
        dataType: 'JSON',
        success:
        function(response)
        {
            console.log(IDS.toString());
            let html = "";
            $("#ModalLargo").html(html);
            if(response.length == 0)
            {
                html += "<p>Este personaje no tiene transformaciones</p>";
            }
            response.forEach(transformacion => {
                html += "<img src=/" + transformacion.fotoTransformacion + ">";
                html += "<p>Nombre: "+ transformacion.nombre + "</p>";
                html += "<p>Multiplicador: " + transformacion.multiplicador + "</p>";
                html += "<p>------------------------------------------------------------------------</p>";
            });
             html +="<a href=/Home/AgregarTransformacion?IdPersonaje="+IDP.toString()+"&IdSaga="+IDS.toString()+" class='btn btn-warning'>Agregar Transformacion</a>";
            $("#ModalLargo").html(html);
        
        }

})
}

