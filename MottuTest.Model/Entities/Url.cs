using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuTest.Model.Models
{
  public class UrlDto : BaseEntity
  {
    public int Hits { get; set; }
    public string OriginalUrl { get; set; }
    public string ShortUrl { get; set; }
  }
}
