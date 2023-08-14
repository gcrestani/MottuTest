using MottuTest.Model.Models;

namespace MottuTest.Api.Services
{

  public interface IUrlService
  {
    Task<string> ShortUrl(string url);
    Task<List<Urls>> TopUrls(int qty);
    Task<bool> ValidateUrl(string url);
  }
  public class UrlService : IUrlService
  {
    public async Task<string> ShortUrl(string url)
    {
      
      return "not implemented";
    }

    public async Task<List<Urls>> TopUrls(int qty)
    {
      var url = new List<Urls>();
      return url;
    }

    public async Task<bool> ValidateUrl(string url)
    {
      return true;
    }
  }
}
