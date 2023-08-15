using MottuTest.Model.Dtos;
using MottuTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuTest.Model.Translators
{
  public interface IToUrlEntityTranslator
  {
    public Url ToUrl(UrlDto urlDto);
  }
  public class ToUrlEntityTranslator : IToUrlEntityTranslator
  {
    public Url ToUrl(UrlDto urlDto)
    {
      return new Url
      {
        Hits = urlDto.Hits,
        OriginalUrl = urlDto.OriginalUrl,
        ShortUrl = urlDto.ShortUrl
      };
    }
  }
}
