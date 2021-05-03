using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Module_4_Task_6.Models;

namespace Module_4_Task_6.Services
{
    public class SongService
    {
        private readonly ApplicationContext _context;

        public SongService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Song>> GetSongsWithTitleAndGenre()
        {
            var songs = await _context.Songs.AsNoTracking()
                .Select(s => new Song
                {
                    Title = s.Title,
                    Artists = s.Artists.Select(a => new Artist { Name = a.Name }),
                    Genre = s.Genre.Title
                }).ToListAsync();

            return songs;
        }

        public async Task<IReadOnlyCollection<GenreStatistics>> GetSongsByGenre()
        {
            var songs = await _context.Songs.AsNoTracking()
                .GroupBy(s => s.Genre.Title)
                .Select(grouped => new GenreStatistics
                {
                    Genre = grouped.Key,
                    SongCount = grouped.Count()
                }).ToListAsync();

            return songs;
        }

        public async Task<IReadOnlyCollection<Entities.Song>> GetSongsCreatedBeforeYoungestArtistBirthDate()
        {
            var youngestArtistBirthDate = await _context.Artists.MinAsync(a => a.DateOfBirth);

            var songs = await _context.Songs.AsNoTracking()
                .Where(s => s.ReleasedDate < youngestArtistBirthDate)
                .ToListAsync();

            return songs;
        }
    }
}
