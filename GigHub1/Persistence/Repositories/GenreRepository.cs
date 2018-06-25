using GigHub1.Core.Models;
using GigHub1.Core.Repositories;
using GigHub1.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace GigHub1.Persistance.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}