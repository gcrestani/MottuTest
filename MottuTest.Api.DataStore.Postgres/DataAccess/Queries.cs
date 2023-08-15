using Microsoft.EntityFrameworkCore;
using MottuTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuTest.Api.DataStore.Postgres.DataAccess
{
  public interface IQueries
  {
    Task<UrlDto> GetUrlByOriginalUrl(string originalUrl);
    Task<UrlDto> GetUrlByShortUrl(string shortUrl);
    Task<List<UrlDto>> GetTopUrls(int qty);
  }
  public class Queries : IQueries
  {

    private readonly Context _context;
    
    public Queries(Context context)
    {
      _context = context;
    }

    public async Task<List<UrlDto>> GetTopUrls(int qty)
    {
      return _context.Urls
      .OrderByDescending(u => u.Hits)
      .Take(qty)
      .ToList();
    }

    public async Task<UrlDto> GetUrlByOriginalUrl(string originalUrl)
    {
      return await _context.Urls
        .Where(u => u.OriginalUrl == originalUrl)
        .FirstOrDefaultAsync();
    }
    public async Task<UrlDto> GetUrlByShortUrl(string shortUrl)
    {
      return await _context.Urls
        .Where(u => u.ShortUrl == shortUrl)
        .FirstOrDefaultAsync();
    }
  }
}
