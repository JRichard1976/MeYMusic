using MeMyMusicData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
namespace MeMyMusicData.Services
{
    public  class MyArtistService
    {
        public readonly DataContext _context;
        public MyArtistService(ILogger<MyArtistService> logger,DataContext dataContext) {
            _context = dataContext;
        }

        public List<MyArtist> GetArtistsByGenre(int GenreId) {
            var myArtist =  _context.myArtists.Where(x => x.MyGenreId == GenreId).ToList();
            return myArtist;
        }
    }
}
