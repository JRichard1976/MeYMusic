using MeMyMusicData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace MeMyMusicData
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        

        }

        public DbSet<MyAlbum> myAlbums { get; set; } = default!;

        public DbSet<MyGenre> myGenres { get; set; } = default!;

        public DbSet<MyBucket> myBuckets { get; set; } = default!;

        public DbSet<MyBuckectItem> myBuckectItems { get; set; } = default!;


        public DbSet<MyArtist> myArtists { get; set; } = default!;
    }
}
