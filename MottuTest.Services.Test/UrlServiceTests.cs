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
            _ = await _sut.ShortUrl("someUrl", _httpRequest.Object);

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
            _ = await _sut.ShortUrl("someUrl", _httpRequest.Object);

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
            _ = await _sut.ShortUrl("someUrl", _httpRequest.Object);

            //Assert
            _commands.Verify(c => c.InsertUrl(It.IsAny<UrlDto>()), Times.Never, "InsertUrl should not be called");
            _queries.Verify(q => q.GetUrlByOriginalUrl(It.IsAny<string>()), Times.Once, "GetUrlByOriginalUrl should be called once");
        }

        [Fact(DisplayName = "TopUrls should return a list of Urls")]
        public async Task TopUrls_Should_Return_a_list_of_Urls()
        {
            //Arrange
            var urlMockList = new List<UrlDto>
      {
        new UrlDto
        {
          Id = 1,
          Hits = 0,
          OriginalUrl = "www.originalUrl.com",
          ShortUrl = "www.shortUrl.com"
        },
        new UrlDto
        {
          Id = 2,
          Hits = 0,
          OriginalUrl = "www.originalUrl2.com",
          ShortUrl = "www.shortUrl2.com"
        }
      };
            _queries.Setup(q => q.GetTopUrls(It.IsAny<int>())).ReturnsAsync(urlMockList);
            var qty = 2;

            //Act
            _ = await _sut.TopUrls(qty);

            //Assert
            _queries.Verify(q => q.GetTopUrls(qty), Times.Once, "GetTopUrls should be called once");
            _translator.Verify(t => t.ToUrl(It.IsAny<UrlDto>()), Times.Exactly(2), "ToUrl should be called once per urlDto returned");
        }

        [Fact(DisplayName = "ValidateUrl should return true on an existing url")]
        public async Task ValidateUrl_Should_Return_true_on_an_existing_Url()
        {
            //Arrange
            var mockUrl = new UrlDto
            {
                Id = 1,
                Hits = 0,
                OriginalUrl = "www.originalUrl.com",
                ShortUrl = "www.shortUrl.com"
            };
            _queries.Setup(q => q.GetUrlByShortUrl("www.someurl.com")).ReturnsAsync(mockUrl);

            //Act
            var validated = await _sut.ValidateUrl("www.someurl.com");

            //Assert
            Assert.True(validated);
        }

        [Fact(DisplayName = "ValidateUrl should return false on an non-existing url")]
        public async Task ValidateUrl_Should_Return_false_on_an_non_existing_Url()
        {
            //Arrange
            //Act
            var validated = await _sut.ValidateUrl("www.someurl.com");

            //Assert
            Assert.False(validated);
        }

        [Fact(DisplayName = "accessShortUrl should increment hits on an existing URL")]
        public async Task AccessShortUrl_Should_Increment_Hits_On_An_Existing_Url()
        {
            //Arrange
            var mockShortUrl = "www.someshorturl.com";
            var mockUrl = new UrlDto
            {
                Id = 1,
                Hits = 0,
                OriginalUrl = "www.originalUrl.com",
                ShortUrl = "www.shortUrl.com"
            };
            _queries.Setup(q => q.GetUrlByShortUrl(mockShortUrl)).ReturnsAsync(mockUrl);

            //Act
            _ = await _sut.accessShortUrl(mockShortUrl);

            //Assert
            _queries.Verify(q => q.GetUrlByShortUrl(mockShortUrl), Times.Once, "GetUrlByShortUrl should be called once with the shortUrl as parameter");
            _commands.Verify(c => c.IncrementHitByShortUrl(It.IsAny<UrlDto>()), Times.Once, "IncrementHitByShortUrl should be called once");
            _translator.Verify(t => t.ToUrl(It.IsAny<UrlDto>()), Times.Once, "ToUrl should be called once");

        }

        [Fact(DisplayName = "accessShortUrl should not increment hits on a non-existing URL")]
        public async Task AccessShortUrl_Should_Not_Increment_Hits_On_A_Non_Existing_Url()
        {
            //Arrange
            var mockShortUrl = "www.someshorturl.com";

            //Act
            _ = await _sut.accessShortUrl(mockShortUrl);

            //Assert
            _queries.Verify(q => q.GetUrlByShortUrl(mockShortUrl), Times.Once, "GetUrlByShortUrl should be called once with the shortUrl as parameter");
            _commands.Verify(c => c.IncrementHitByShortUrl(It.IsAny<UrlDto>()), Times.Never, "IncrementHitByShortUrl should not be called");
            _translator.Verify(t => t.ToUrl(It.IsAny<UrlDto>()), Times.Never, "ToUrl should not be called");
        }

        [Fact(DisplayName = "shortened URL must have the minimun lenght possible")]
        public async Task ShortUrl_Should_Have_The_Minimun_Lenght_Possible()
        {
            //Arrange
            _commands.Setup(c => c.InsertUrl(It.IsAny<UrlDto>())).ReturnsAsync(1);
            var longUrl = "www.somelongurl.com";
            _translator.Setup(t => t.ToUrl(It.IsAny<UrlDto>())).Returns((UrlDto dto) => new Url
            {
                OriginalUrl = dto.OriginalUrl,
                ShortUrl = dto.ShortUrl,
                Hits = dto.Hits
            });

            //Act
            Url shortUrl = await _sut.ShortUrl(request: _httpRequest.Object, url: longUrl);

            //Assert
            Assert.True(shortUrl.ShortUrl.Length == 5, "Shortened URL length should be 1 character long"); //1 character for the code plus 4 for the prefix ("///:")

        } 
    }
    }
