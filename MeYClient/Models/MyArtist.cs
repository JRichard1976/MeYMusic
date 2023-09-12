using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeYClient.Models
{
    public class MyArtist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WikiLink { get; set; }
        public int MyGenreId { get; set; }

        public string Image { get; set; }

        public string Notes { get; set; }

    }
}
