using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeMyMusicData.Models
{
    public class MyBucket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float  TotalAmount { get; set; }
        public bool Paid { get; set; }

    }
}
