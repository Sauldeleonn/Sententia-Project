$(document).ready(function() {
    $('#chuckButton').click(function() {
      $.ajax({
        url: 'https://api.chucknorris.io/jokes/random',
        method: 'GET',
        success: function(response) {
          $('#chuckJoke').html(`<p>${response.value}</p>`);
        },
        error: function() {
          $('#chuckJoke').html('<p>No se pudo obtener una broma en este momento. Por favor, inténtalo de nuevo más tarde.</p>');
        }
      });
    });
  });
  