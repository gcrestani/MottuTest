using Microsoft.EntityFrameworkCore;
using MottuTest.Model.Models;

namespace MottuTest.Api.DataStore.Postgres
{
  public class Context : DbContext
  {
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<UrlDto> Urls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<UrlDto>().HasData(
          new UrlDto
          {
            Id = 23094,
            Hits = 5,
            OriginalUrl = "http://globo.com",
            ShortUrl = "http://chr.dc/9dtr4"

          },
          new UrlDto
          {
            Id = 76291,
            Hits = 4,
            OriginalUrl = "http://google.com",
            ShortUrl = "http://chr.dc/aUx71"

          },
          new UrlDto
          {
            Id = 66761,
            Hits = 7,
            OriginalUrl = "http://terra.com.br",
            ShortUrl = "http://chr.dc/u9jh3"
          },
          new UrlDto
          {
            Id = 70001,
            Hits = 1,
            OriginalUrl = "http://facebook.com",
            ShortUrl = "http://chr.dc/qy61p"
          },
          new UrlDto
          {
            Id = 21220,
            Hits = 2,
            OriginalUrl = "http://diariocatarinense.com.br",
            ShortUrl = "http://chr.dc/87itr"
          },
          new UrlDto
          {
            Id = 10743,
            Hits = 0,
            OriginalUrl = "http://uol.com.br",
            ShortUrl = "http://chr.dc/y81xc"
          },
          new UrlDto
          {
            Id = 19122,
            Hits = 2,
            OriginalUrl = "http://chaordic.com.br",
            ShortUrl = "http://chr.dc/qy5k9"
          },
          new UrlDto
          {
            Id = 55324,
            Hits = 4,
            OriginalUrl = "http://youtube.com",
            ShortUrl = "http://chr.dc/1w5tg"
          },
          new UrlDto
          {
            Id = 70931,
            Hits = 5,
            OriginalUrl = "http://twitter.com",
            ShortUrl = "http://chr.dc/7tmv1"
          },
          new UrlDto
          {
            Id = 87112,
            Hits = 2,
            OriginalUrl = "http://bing.com",
            ShortUrl = "http://chr.dc/9opw2"
          }
      );
    }
  }
}
