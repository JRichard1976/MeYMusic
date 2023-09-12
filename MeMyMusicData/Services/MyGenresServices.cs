using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using MeMyMusicData.Models;
using Microsoft.EntityFrameworkCore;

namespace MeMyMusicData.Services
{
    public class MyGenresServices
    {
        private readonly DataContext _context;
        private readonly ILogger<MyGenresServices> _logger;
        public MyGenresServices(ILogger<MyGenresServices> logger, DataContext dataContext) {
            _context = dataContext;
            _logger = logger;
        }

        public List<MyGenre> GelAllGenres()
        {
            return _context.myGenres.ToList();
        }
    }
}
