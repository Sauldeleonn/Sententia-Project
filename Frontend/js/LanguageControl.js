// LanguageControl.js

function showContent(section) {
    document.getElementById('header-box').innerText = section;
    if (section === 'Language') {
        showLanguageControls();
    } else {
        document.getElementById('content-box').innerText = 'Content for ' + section + ' will be displayed here.';
    }
}

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
        url: 'https://localhost:7090/Language',
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
        url: 'https://localhost:7090/Language',
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
        url: `https://localhost:7090/Language/${languageId}`,
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
