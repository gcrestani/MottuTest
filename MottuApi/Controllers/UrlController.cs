using Microsoft.AspNetCore.Mvc;

namespace MottuTest.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UrlController : ControllerBase
  {
    private readonly ILogger<UrlController> _logger;

    public UrlController(ILogger<UrlController> logger)
    {
      _logger = logger;
    }
    
    [HttpPost]
    [Route("/{url}")]
    public async Task<IActionResult> shortUrl(string url)
    {
      return Ok(Url);
    }
    
    [HttpPost]
    [Route("/{qty}")]
    public async Task<IActionResult> topUrls(int qty)
    {
      return Ok(qty);
    }

    [HttpPost]
    [Route("/{shortUrl}")]
    public async Task<IActionResult> validateUrl (string shortUrl)
    {
      return Ok(true);
    }

    [HttpPost]
    [Route("/{shortUrlCheck}")]
    public async Task<IActionResult> accessUrl(string shortUrlCheck)
    {
      return Ok();
    }
  }
}
