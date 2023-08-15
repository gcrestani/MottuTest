using MottuTest.Model.Dtos;
using MottuTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuTest.Api.DataStore.Postgres.DataAccess
{
  public interface ICommands
  {
    Task<int> InsertUrl(UrlDto url);
  }
  public class Commands :ICommands
  {
    private readonly Context _context;
    private readonly IQueries _queries;

    public Commands(Context context, IQueries queries)
    {
      _context = context;
      _queries = queries;
    }

    public async Task<int> InsertUrl(UrlDto url)
    {
      var existingUrl = await _queries.GetUrlByShortUrl(url.ShortUrl);
      if (existingUrl != null)
      {
        return 0;
      }
      url.CreatedAt = DateTime.UtcNow;
      _context.Add(url);
      await _context.SaveChangesAsync();
      return url.Id;
    }
  }
}
