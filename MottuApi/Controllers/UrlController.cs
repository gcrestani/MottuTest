using Microsoft.AspNetCore.Mvc;
using MottuTest.Api.Services;
using MottuTest.Model.Dtos;
using MottuTest.Model.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.RegularExpressions;

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
      Summary = "Shorten a URL",
      Description = "Returns a shortened URL"
    )]
    [SwaggerResponse(200, "Return a shortened URL", typeof(Url))]
    [SwaggerResponseAttribute(200, type: typeof(Url))]
    public async Task<IActionResult> shortUrl(string inputUrl)
    {
      if (!validateInputUrl(inputUrl))
      {
        return BadRequest("Invalid URL.");
      }

      var shortenedUrl = await _urlService.ShortUrl(inputUrl, Request) ;
      return Ok(shortenedUrl);
    }

    [HttpPost("topUrls")]
    [SwaggerOperation(
      Summary = "Return an ordered list of URL",
      Description = "Return a list of URL ordered by access desc"
    )]
    [SwaggerResponse(200, "Return a list of URL", typeof(List<Url>))]
    [SwaggerResponseAttribute(200, type: typeof(List<Url>))]
    public async Task<IActionResult> topUrls(int qty)
    {
      if (qty <= 0)
      {
        return BadRequest("Invalid quantity");
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
    public async Task<IActionResult> validateUrl(string inputShortUrl)
    {
      if (!validateInputUrl(inputShortUrl))
      {
        return BadRequest("Invalid URL");
      }
      var isUrlValid = await _urlService.ValidateUrl(inputShortUrl);

      return Ok(isUrlValid);
    }

    [HttpPost("accessUrl")]
    public async Task<IActionResult> accessUrl(string shortUrlCheck)
    {
      return Ok();
    }

    private bool validateInputUrl(string url)
    {
      string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
      Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
      return Rgx.IsMatch(url);
    }
  }
}
