using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuTest.Model.Dtos
{
  public class Url
  {
    public string OriginalUrl { get; set; }
    public string ShortUrl { get; set; }
    public int Hits { get; set; }
  }
}
