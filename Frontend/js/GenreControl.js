// GenreControl.js

function showContent(section) {
    document.getElementById('header-box').innerText = section;
    if (section === 'Genre') {
        showGenreControls();
    } else {
        document.getElementById('content-box').innerText = 'Content for ' + section + ' will be displayed here.';
    }
}

function showGenreControls() {
    $('#content-box').html(`
        <div>
            <button id="create-genre-button">Crear un Género</button>
            <button id="delete-genre-button">Eliminar Género</button>
        </div>
        <div id="genre-form" style="display:none;">
            <input type="text" id="genre-name" placeholder="Nombre del género">
            <input type="text" id="genre-description" placeholder="Descripción del género">
            <button id="submit-genre-button">Submit</button>
        </div>
        <div id="genre-list"></div>
    `);

    $('#create-genre-button').click(function() {
        $('#genre-form').toggle();
        $('#submit-genre-button').off('click').on('click', function() {
            createGenre();
        });
    });

    $('#delete-genre-button').click(function() {
        loadGenresForDeletion();
    });
}

function createGenre() {
    const name = $('#genre-name').val();
    const description = $('#genre-description').val();

    $.ajax({
        url: 'https://localhost:7090/Genre', 
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            name: name,
            description: description
        }),
        success: function(response) {
            alert('Género creado con éxito');
            $('#genre-form').hide();
        },
        error: function(error) {
            console.error('Error creating genre:', error);
            alert('Error al crear el género');
        }
    });
}

function loadGenresForDeletion() {
    $.ajax({
        url: 'https://localhost:7090/Genre',
        type: 'GET',
        success: function(genres) {
            $('#genre-list').html('');
            genres.forEach(function(genre) {
                $('#genre-list').append(`
                    <div>
                        <span>${genre.name}</span>
                        <button onclick="deleteGenre(${genre.genreId})">Eliminar</button>
                    </div>
                `);
            });
        },
        error: function(error) {
            console.error('Error loading genres:', error);
            alert('Error al cargar los géneros');
        }
    });
}

function deleteGenre(genreId) {
    $.ajax({
        url: `https://localhost:7090/Genre/${genreId}`,
        type: 'DELETE',
        success: function(response) {
            alert('Género eliminado con éxito');
            loadGenresForDeletion();
        },
        error: function(error) {
            console.error('Error deleting genre:', error);
            alert('Error al eliminar el género');
        }
    });
}
