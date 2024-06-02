$(document).ready(function () {
    $.ajax({
      url: "https://localhost:7090/Song/Popular",
      type: "GET",
      success: function (data) {
        const songsContainer = $("#songs-container");
        data.songs.forEach((song, index) => {
          const songDiv = $(`
            <div>
              <div class="content">
                <h2>${song.name}</h2>
                <span>${song.bio}</span>
              </div>
            </div>
          `);
          songsContainer.append(songDiv);
  
          // Opcional: actualizar el fondo de cada canción si es necesario
          songDiv.css("background-image", `url('https://path/to/image/${index}.jpg')`);
        });
      },
      error: function (error) {
        console.error("Error fetching songs:", error);
      }
    });
  });
  