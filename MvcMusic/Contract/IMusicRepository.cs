using MvcMusic.Models;
using System.Collections.Generic;

namespace MvcMusic.Contract
{
    public interface IMusicRepository
    {
        IEnumerable<Music> GetAll();
        Music GetById(int id);
        void Add(Music music);
        void Update(Music music);
        void Delete(int id);
        void SaveChanges();
    }
}
