using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video_Game_Library.Models;

namespace Video_Game_Library.Data
{
    public interface IVideoGameDAL
    {
        IEnumerable<Game> GetCollection();
        IEnumerable<Game> SearchForGames(string key);
        IEnumerable<Game> FilterCollection(string genre, string platform, string rating);
        void AddGame(Game game);
        void DeleteGame(int index);
    }
}
