// CombinedControl.js

function showContent(section) {
    document.getElementById('header-box').innerText = section;
    if (section === 'Language') {
        showLanguageControls();
    } else if (section === 'Genre') {
        showGenreControls();
    } else if (section === 'Song') {
        showSongControls();
    } else if (section === 'List') {
        showListControls();
    } else {
        document.getElementById('content-box').innerText = 'Content for ' + section + ' will be displayed here.';
    }
}

// Language Control
function showLanguageControls() {
    $('#content-box').html(`
        <div>
            <button id="create-language-button">Crear un Lenguaje</button>
            <button id="delete-language-button">Eliminar Lenguaje</button>
        </div>
        <div id="language-form" style="display:none;">
            <input type="text" id="language-name" placeholder="Nombre del lenguaje">
            <button id="submit-language-button">Submit</button>
        </div>
        <div id="language-list"></div>
    `);

    $('#create-language-button').click(function() {
        $('#language-form').toggle();
        $('#submit-language-button').off('click').on('click', function() {
            createLanguage();
        });
    });

    $('#delete-language-button').click(function() {
        loadLanguagesForDeletion();
    });
}

function createLanguage() {
    const name = $('#language-name').val();

    $.ajax({
        url: 'http://www.apimusicalreviews.somee.com/Language',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            name: name
        }),
        success: function(response) {
            alert('Lenguaje creado con éxito');
            $('#language-form').hide();
        },
        error: function(error) {
            console.error('Error creando el lenguaje:', error);
            alert('Error al crear el lenguaje');
        }
    });
}

function loadLanguagesForDeletion() {
    $.ajax({
        url: 'http://www.apimusicalreviews.somee.com/Language',
        type: 'GET',
        success: function(response) {
            const languages = response.languages;
            $('#language-list').html('');
            languages.forEach(function(language) {
                $('#language-list').append(`
                    <div>
                        <span>${language.name}</span>
                        <button onclick="deleteLanguage(${language.languageId})">Eliminar</button>
                    </div>
                `);
            });
        },
        error: function(error) {
            console.error('Error cargando los lenguajes:', error);
            alert('Error al cargar los lenguajes');
        }
    });
}

function deleteLanguage(languageId) {
    $.ajax({
        url: `http://www.apimusicalreviews.somee.com/Language/${languageId}`,
        type: 'DELETE',
        success: function(response) {
            alert('Lenguaje eliminado con éxito');
            loadLanguagesForDeletion();
        },
        error: function(error) {
            console.error('Error eliminando el lenguaje:', error);
            alert('Error al eliminar el lenguaje');
        }
    });
}

// Genre Control
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
        url: 'http://www.apimusicalreviews.somee.com/Genre', 
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
        url: 'http://www.apimusicalreviews.somee.com/Genre',
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
        url: `http://www.apimusicalreviews.somee.com/Genre/${genreId}`,
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

// Song Control
function showSongControls() {
    $('#content-box').html(`
        <div>
            <button id="create-song-button">Crear una Canción</button>
            <button id="delete-song-button">Eliminar Canción</button>
            <button id="edit-song-button">Editar Canción</button>
        </div>
        <div id="song-form" style="display:none;">
            <input type="text" id="song-name" placeholder="Nombre de la canción">
            <input type="text" id="song-description" placeholder="Biografía de la canción">
            <input type="date" id="song-release-date" placeholder="Fecha de lanzamiento">
            <button id="submit-song-button">Submit</button>
        </div>
        <div id="song-list"></div>
    `);

    $('#create-song-button').click(function() {
        $('#song-form').toggle();
        $('#submit-song-button').off('click').on('click', function() {
            createSong();
        });
    });

    $('#delete-song-button').click(function() {
        loadSongsForDeletion();
    });

    $('#edit-song-button').click(function() {
        loadSongsForEditing();
    });
}

function createSong() {
    const name = $('#song-name').val();
    const bio = $('#song-description').val();
    const releaseDate = $('#song-release-date').val();
    const musicalElementTypeId = 1;

    $.ajax({
        url: 'http://www.apimusicalreviews.somee.com/Song',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            musicalElementTypeId: musicalElementTypeId,
            name: name,
            bio: bio,
            releaseDate: releaseDate
        }),
        success: function(response) {
            alert('Canción creada con éxito');
            $('#song-form').hide();
        },
        error: function(error) {
            console.error('Error creating song:', error);
            alert('Error al crear la canción');
        }
    });
}



function loadSongsForDeletion() {
    $.ajax({
        url: 'http://www.apimusicalreviews.somee.com/Song',
        type: 'GET',
        success: function(response) {
            const songs = response.songs;
            $('#song-list').html('');
            songs.forEach(function(song) {
                $('#song-list').append(`
                    <div>
                        <span>${song.name}</span>
                        <button onclick="deleteSong(${song.musicalElementId})">Eliminar</button>
                    </div>
                `);
            });
        },
        error: function(error) {
            console.error('Error loading songs:', error);
            alert('Error al cargar las canciones');
        }
    });
}

function deleteSong(musicalElementId) {
    $.ajax({
        url: `http://www.apimusicalreviews.somee.com/Song/${musicalElementId}`,
        type: 'DELETE',
        success: function(response) {
            alert('Canción eliminada con éxito');
            loadSongsForDeletion();
        },
        error: function(error) {
            console.error('Error deleting song:', error);
            alert('Error al eliminar la canción');
        }
    });
}

function loadSongsForEditing() {
    $.ajax({
        url: 'http://www.apimusicalreviews.somee.com/Song',
        type: 'GET',
        success: function(response) {
            const songs = response.songs;
            $('#song-list').html('');
            songs.forEach(function(song) {
                $('#song-list').append(`
                    <div>
                        <span>${song.name}</span>
                        <button onclick="editSong(${song.musicalElementId})">Editar</button>
                    </div>
                `);
            });
        },
        error: function(error) {
            console.error('Error loading songs:', error);
            alert('Error al cargar las canciones');
        }
    });
}

function editSong(musicalElementId) {
    $.ajax({
        url: `http://www.apimusicalreviews.somee.com/Song/${musicalElementId}`,
        type: 'GET',
        success: function(song) {
            $('#song-form').show();
            $('#song-name').val(song.name);
            $('#song-description').val(song.bio);
            $('#song-release-date').val(song.releaseDate);

            $('#submit-song-button').off('click').on('click', function() {
                updateSong(musicalElementId);
            });
        },
        error: function(error) {
            console.error('Error fetching song details:', error);
            alert('Error al obtener los detalles de la canción');
        }
    });
}

function updateSong(musicalElementId) {
    const name = $('#song-name').val();
    const bio = $('#song-description').val();
    const releaseDate = $('#song-release-date').val();
    const musicalElementTypeId = 1;

    $.ajax({
        url: `http://www.apimusicalreviews.somee.com/Song/${musicalElementId}`,
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify({
            musicalElementId: musicalElementId,
            musicalElementTypeId: musicalElementTypeId,
            name: name,
            bio: bio,
            releaseDate: releaseDate
        }),
        success: function(response) {
            alert('Canción actualizada con éxito');
            $('#song-form').hide();
            loadSongsForEditing();
        },
        error: function(error) {
            console.error('Error updating song:', error);
            alert('Error al actualizar la canción');
        }
    });
}


function showAddSongToListControls() {
    $.when(
        $.ajax({ url: 'http://www.apimusicalreviews.somee.com/Song', type: 'GET' }),
        $.ajax({ url: 'http://www.apimusicalreviews.somee.com/List', type: 'GET' })
    ).done(function(songsResponse, listsResponse) {
        const songs = songsResponse[0].songs;
        const lists = listsResponse[0].lists;

        $('#content-boxLists').html(`
            <div>
                <label for="select-song">Seleccione una Canción:</label>
                <select id="select-song">
                    ${songs.map(song => `<option value="${song.musicalElementId}">${song.name}</option>`).join('')}
                </select>
            </div>
            <div>
                <label for="select-list">Seleccione una Lista:</label>
                <select id="select-list">
                    ${lists.map(list => `<option value="${list.listId}">${list.name}</option>`).join('')}
                </select>
            </div>
            <button id="submit-add-song-button">Agregar</button>
        `);

        $('#submit-add-song-button').click(function() {
            const selectedSongId = $('#select-song').val();
            const selectedListId = $('#select-list').val();
            addSongToList(selectedSongId, selectedListId);
        });
    }).fail(function(error) {
        console.error('Error loading songs or lists:', error);
        alert('Error al cargar canciones o listas');
    });
}
