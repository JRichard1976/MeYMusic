using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeMyMusicData.Models
{
    public class MyBuckectItem
    {
        [Key]
        public int Id { get; set; }

        public MyBucket Bucket { get; set; }

        public MyAlbum Album { get; set; }

        
    }
}
