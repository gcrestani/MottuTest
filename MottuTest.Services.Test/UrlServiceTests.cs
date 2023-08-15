using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using MottuTest.Api.DataStore.Postgres.DataAccess;
using MottuTest.Api.Services;
using MottuTest.Model.Dtos;
using MottuTest.Model.Models;
using MottuTest.Model.Translators;
using Xunit;

namespace MottuTest.Services.Test
{
  public class Tests
  {
    readonly UrlService _sut;
    private readonly Mock<ILogger<UrlService>> _logger;
    private readonly Mock<ICommands> _commands;
    private readonly Mock<IQueries> _queries;
    private readonly Mock<IToUrlEntityTranslator> _translator;
    private readonly Mock<HttpRequest> _httpRequest;

    public Tests()
    {
      _commands = new();
      _logger = new();
      _queries = new();
      _translator = new();
      _httpRequest = new();
      _sut = new UrlService(_logger.Object, _commands.Object, _queries.Object, _translator.Object);
    }

    [Fact(DisplayName = "ShortUrl should return a valid Url")]
    public async Task ShortUrl_Should_Return_a_valid_Url()
    {
      //Arrange
      _commands.Setup(c => c.InsertUrl(It.IsAny<UrlDto>())).ReturnsAsync(1);
      _httpRequest.Setup(r => r.Scheme).Returns("someUrlScheme");

      //Act
      var returnedUrl = await _sut.ShortUrl("someUrl", _httpRequest.Object);

      //Assert
      _commands.Verify(c => c.InsertUrl(It.IsAny<UrlDto>()), Times.Once, "InsertUrl should be called once");
      _queries.Verify(q => q.GetUrlByOriginalUrl(It.IsAny<string>()), Times.Once, "GetUrlByOriginalUrl should be called once");
    }

    [Fact(DisplayName = "ShortUrl should return a valid Url after retrying if the first randomCode is already on database")]
    public async Task ShortUrl_Should_Return_a_valid_Url_after_retrying()
    {
      //Arrange
      _commands.SetupSequence(c => c.InsertUrl(It.IsAny<UrlDto>())).ReturnsAsync(0).ReturnsAsync(1);
      _httpRequest.Setup(r => r.Scheme).Returns("someUrlScheme");

      //Act
      var returnedUrl = await _sut.ShortUrl("someUrl", _httpRequest.Object);

      //Assert
      _commands.Verify(c => c.InsertUrl(It.IsAny<UrlDto>()), Times.Exactly(2), "InsertUrl should be called twice");
      _queries.Verify(q => q.GetUrlByOriginalUrl(It.IsAny<string>()), Times.Once, "GetUrlByOriginalUrl should be called once");
    }

    [Fact(DisplayName = "ShortUrl should return an existing url from database")]
    public async Task ShortUrl_Should_Return_an_existing_Url_from_database()
    {
      //Arrange
      _queries.Setup(q => q.GetUrlByOriginalUrl(It.IsAny<string>())).ReturnsAsync(new UrlDto { OriginalUrl = "existingUrl" });

      //Act
      var returnedUrl = await _sut.ShortUrl("someUrl", _httpRequest.Object);

      //Assert
      _commands.Verify(c => c.InsertUrl(It.IsAny<UrlDto>()), Times.Never, "InsertUrl should not be called");
      _queries.Verify(q => q.GetUrlByOriginalUrl(It.IsAny<string>()), Times.Once, "GetUrlByOriginalUrl should be called once");
    }
  }
}