using DataAccess;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ReportsService
    {
        private readonly SongDAO _songDAO;
        public ReportsService(IConfiguration config)
        {
            _songDAO = new SongDAO(config);
        }

        //public async Task<byte[]> GetSongsReportAsync()
        //{
        //    var songs = await _songDAO.GetAllSongDetailsAsync();

        //    var sb = new StringBuilder();
        //    sb.AppendLine($"We found {songs.Count} songs, heres the info.\n");
        //    sb.AppendLine("SongId,\tName,\tArtist,\tAlbum,\tReleaseDate");
        //    foreach (var song in songs)
        //    {
        //        sb.AppendLine($"{song.MusicalElementId}, {song.Name}, {song.MusicalElement3.ReleaseDate}");
        //    }

        //    var byteArray = Encoding.UTF8.GetBytes(sb.ToString());
        //    return byteArray;
        //}
        public async Task<byte[]> GetSongsReportAsync()
        {
            var songs = await _songDAO.GetAllSongDetailsAsync();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Songs Report");
                worksheet.Cells[1, 1].Value = "SongId";
                worksheet.Cells[1, 2].Value = "Name";
                worksheet.Cells[1, 3].Value = "Bio";
                worksheet.Cells[1, 4].Value = "ReleaseDate";

                for (int i = 0; i < songs.Count; i++)
                {
                    var song = songs[i];
                    worksheet.Cells[i + 2, 1].Value = song.MusicalElementId;
                    worksheet.Cells[i + 2, 2].Value = song.Name;
                    worksheet.Cells[i + 2, 3].Value = song.Bio;
                    worksheet.Cells[i + 2, 4].Value = song.MusicalElement3.ReleaseDate;
                }

                return package.GetAsByteArray();
            }
        }
    }
}
