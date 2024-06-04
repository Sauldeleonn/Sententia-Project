$(document).ready(function() {
    $('.download-button').click(function() {
        $.ajax({
            url: 'http://www.apimusicalreviews.somee.com/Reports/SongReport',
            type: 'GET',
            xhrFields: {
                responseType: 'blob' // Importante para manejar la respuesta como un blob
            },
            success: function(data) {
                // Crear un enlace temporal para descargar el archivo
                var a = document.createElement('a');
                var url = window.URL.createObjectURL(data);
                a.href = url;
                a.download = 'SongReport.xlsx'; // Nombre del archivo que se descargará
                document.body.append(a);
                a.click();
                window.URL.revokeObjectURL(url);
                alert('Reporte descargado con éxito');
            },
            error: function(error) {
                console.error('Error al descargar el reporte:', error);
                alert('Error al descargar el reporte');
            }
        });
    });
});
