using MottuTest.Api.DataStore.Postgres.DataAccess;
using MottuTest.Model.Dtos;
using MottuTest.Model.Models;
using MottuTest.Model.Translators;

namespace MottuTest.Api.Services
{

  public interface IUrlService
  {
    Task<Url> ShortUrl(string url, HttpRequest request);
    Task<List<Url>> TopUrls(int qty);
    Task<bool> ValidateUrl(string url);
    Task<Url> accessShortUrl(string shortUrl);

  }
  public class UrlService : IUrlService
  {
    private readonly ILogger<UrlService> _logger;
    private readonly ICommands _commands;
    private readonly IQueries _queries;
    private readonly IToUrlEntityTranslator _translator;

    public UrlService(ILogger<UrlService> logger, ICommands commands, IQueries queries, IToUrlEntityTranslator translator)
    {
      _logger = logger;
      _commands = commands;
      _queries = queries;
      _translator = translator;
    }

    public async Task<Url> ShortUrl(string url, HttpRequest request)
    {
      var existingUrl = await _queries.GetUrlByOriginalUrl(url);
      if (existingUrl != null)
      {
        return _translator.ToUrl(existingUrl);
      }
      
      var urlId = 0;
      UrlDto shortUrl = new UrlDto();
      while (urlId == 0)
      {
        var urlCode = Path.GetRandomFileName().Replace(".", "").Substring(0, 5);
        shortUrl = new UrlDto
        {
          Hits = 0,
          ShortUrl = $"{request.Scheme}://{request.Host}/{urlCode}",
          OriginalUrl = url,
        };
        urlId = await _commands.InsertUrl(shortUrl);
      }
      //send to RabbitMq
      
      return _translator.ToUrl(shortUrl);
    }

    public async Task<List<Url>> TopUrls(int qty)
    {
      var listUrlDto =  await _queries.GetTopUrls(qty);
      var listUrl = new List<Url>();
      foreach (var item in listUrlDto)
      {
        listUrl.Add(_translator.ToUrl(item));
      }
      return listUrl;
    }

    public async Task<bool> ValidateUrl(string shortUrl)
    {
      var url = await _queries.GetUrlByShortUrl(shortUrl);
      return (url!=null);
    }

    public async Task<Url> accessShortUrl(string shortUrl)
    {
      var urlDto = await _queries.GetUrlByShortUrl(shortUrl);
      if (urlDto == null)
        return null;
      _ = await _commands.IncrementHitByShortUrl(urlDto);
      return _translator.ToUrl(urlDto);
    }
  }
}
