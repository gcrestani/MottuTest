using Microsoft.AspNetCore.Mvc;
using MottuTest.Api.Services;
using MottuTest.Model.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MottuTest.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UrlController : ControllerBase
  {
    private readonly ILogger<UrlController> _logger;
    private readonly IUrlService _urlService;

    public UrlController(ILogger<UrlController> logger, IUrlService urlService)
    {
      _logger = logger;
      _urlService = urlService;
    }
    
    [HttpPost("shortUrl")]
    [SwaggerOperation(
      Summary ="Shorten a URL",
      Description = "Returns a shortened URL"
    )]
    [SwaggerResponse(200, "Return a shortened URL", typeof(Urls))]
    [SwaggerResponseAttribute(200,type:typeof(Urls))]
    public async Task<IActionResult> shortUrl(string url)
    {
      if (string.IsNullOrEmpty(url))
      {
        throw new ArgumentException();
      }

      var shortenedUrl = await _urlService.ShortUrl(url);
      return Ok(shortenedUrl);
    }
    
    [HttpPost("topUrls")]
    [SwaggerOperation(
      Summary = "Return an ordered list of URL",
      Description = "Return a list of URL ordered by access desc"
    )]
    [SwaggerResponse(200, "Return a list of URL", typeof(List<Urls>))]
    [SwaggerResponseAttribute(200, type: typeof(List<Urls>))]
    public async Task<IActionResult> topUrls(int qty)
    {
      if (qty<=0)
      {
        throw new ArgumentException();
      }
      var urlList = await _urlService.TopUrls(qty);
      
      return Ok(urlList);
    }

    [HttpPost("validateUrl")]
    [SwaggerOperation(
      Summary = "Return a bool indicating if the URL is valid",
      Description = "Return a bool indicating if the URL is valid"
    )]
    [SwaggerResponse(200, "Return a bool indicating if the URL is valid", typeof(bool))]
    [SwaggerResponseAttribute(200, type: typeof(bool))]
    public async Task<IActionResult> validateUrl (string shortUrl)
    {
      if (string.IsNullOrEmpty(shortUrl))
      {
        throw new ArgumentException();
      }
      var isUrlValid= await _urlService.ValidateUrl(shortUrl);
      
      return Ok(isUrlValid);
    }

    [HttpPost("accessUrl")]
    public async Task<IActionResult> accessUrl(string shortUrlCheck)
    {
      return Ok();
    }
  }
}
