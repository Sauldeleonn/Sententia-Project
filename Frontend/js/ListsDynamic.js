


// Esperar a que el DOM esté completamente cargado
document.addEventListener("DOMContentLoaded", function() {
    console.log("DOM fully loaded and parsed");

    // List Control
    function showListControls() {
        console.log("showListControls called");
        $('#content-boxLists').html(`
            <div>
                <button id="create-list-button">Crear Lista</button>
                <button id="delete-list-button">Eliminar Lista</button>
                <button id="add-song-to-list-button">Agregar Canción a Lista</button>
            </div>
            <div id="list-form" style="display:none;">
                <input type="text" id="list-name" placeholder="Nombre de la lista">
                <input type="text" id="list-description" placeholder="Descripción de la lista">
                <button id="submit-list-button">Submit</button>
            </div>
            <div id="list-list"></div>
        `);

        $('#create-list-button').click(function() {
            console.log("Create list button clicked");
            $('#list-form').toggle();
            $('#submit-list-button').off('click').on('click', function() {
                createList();
            });
        });

        $('#delete-list-button').click(function() {
            console.log("Delete list button clicked");
            loadListsForDeletion();
        });

        $('#add-song-to-list-button').click(function() {
            console.log("Add song to list button clicked");
            showAddSongToListControls();
        });
    }

    function createList() {
        const name = $('#list-name').val();
        const description = $('#list-description').val();
    
        if (name.length > 10) {
            alert('El nombre de la lista no puede tener más de 10 caracteres.');
            return;
        }
    
        console.log('Creating list with name:', name);  // Log the data being sent
    
        $.ajax({
            url: 'http://www.apimusicalreviews.somee.com/List',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                name: name
            }),
            success: function(response) {
                console.log('Server response:', response);  // Log the server's response
                alert('Lista creada con éxito');
                $('#list-form').hide();
            },
            error: function(error) {
                console.error('Error creating list:', error);
                console.log('Response from server:', error.responseText);  // Log the server's response
                alert('Error al crear la lista');
            }
        });
    }
    

    function loadListsForDeletion() {
        console.log("Loading lists for deletion");
        $.ajax({
            url: 'http://www.apimusicalreviews.somee.com/List',
            type: 'GET',
            success: function(lists) {
                $('#list-list').html('');
                lists.forEach(function(list) {
                    $('#list-list').append(`
                        <div>
                            <span>${list.name}</span>
                            <button onclick="deleteList(${list.listId})">Eliminar</button>
                        </div>
                    `);
                });
            },
            error: function(error) {
                console.error('Error loading lists:', error);
                alert('Error al cargar las listas');
            }
        });
    }

    function deleteList(listId) {
        console.log("Deleting list with ID:", listId);
        $.ajax({
            url: `http://www.apimusicalreviews.somee.com/List/${listId}`,
            type: 'DELETE',
            success: function(response) {
                alert('Lista eliminada con éxito');
                loadListsForDeletion();
            },
            error: function(error) {
                console.error('Error deleting list:', error);
                alert('Error al eliminar la lista');
            }
        });
    }

    function showAddSongToListControls() {
        console.log("Showing add song to list controls");
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

    function addSongToList(musicalElementId, listId) {
        console.log("Adding song to list with song ID:", musicalElementId, "and list ID:", listId);
        $.ajax({
            url: `http://www.apimusicalreviews.somee.com/List/AddElement`,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                musicalElementId: musicalElementId,
                listId: listId
            }),
            success: function(response) {
                alert('Canción agregada a la lista con éxito');
            },
            error: function(error) {
                console.error('Error adding song to list:', error);
                alert('Error al agregar la canción a la lista');
            }
        });
    }

    // Llama a la función inicial para mostrar los controles
    showListControls();
});



