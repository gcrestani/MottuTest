using MottuTest.Model.Models;
using MottuTest.Model.Translators;

namespace MottuTest.Model.Tests
{
  public class ToUrlEntityTranslatorTest
  {
    private readonly ToUrlEntityTranslator _sut;
    public ToUrlEntityTranslatorTest()
    {
      _sut = new ToUrlEntityTranslator();
    }

    [Fact (DisplayName = "ToUrl Should return a valid Url")]
    public void ToUrl_Should_return_a_valid_Url()
    {
      //Arrange
      var mockUrl = new UrlDto
      {
        Hits = 1,
        OriginalUrl = "www.originalurl.com",
        ShortUrl = "www.shorturl.com"
      };

      //Act
      var returnedUrl = _sut.ToUrl(mockUrl);

      //Assert
      Assert.Equal(mockUrl.Hits,returnedUrl.Hits);
      Assert.Equal(mockUrl.OriginalUrl,returnedUrl.OriginalUrl);
      Assert.Equal(mockUrl.ShortUrl, returnedUrl.ShortUrl);

    }
  }
}