using MvcMusic.Contract;
using MvcMusic.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcMusic.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MusicRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Music> GetAll()
        {
            return _dbContext.Musics.ToList();
        }

        public Music GetById(int id)
        {
            return _dbContext.Musics.Find(id);
        }

        public void Add(Music music)
        {
            _dbContext.Musics.Add(music);
        }

        public void Update(Music music)
        {
            _dbContext.Musics.Update(music);
        }

        public void Delete(int id)
        {
            var music = _dbContext.Musics.Find(id);
            if (music != null)
                _dbContext.Musics.Remove(music);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
