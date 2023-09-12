using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeMyMusicData.Models
{
    public  class MyAlbum
    {
        [Key]
        public int Id { get; set; }
        public int Genre { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public float NetPrice { get; set; }
        public float Vat { get; set; }
        public int ArtistId { get; set; }
        [NotMapped]
        public float GrossPrice { get; set; }



    }
}
