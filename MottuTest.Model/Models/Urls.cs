﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuTest.Model.Models
{
  public class Urls : BaseEntity
  {
    public double Hits { get; set; }
    public string Url { get; set; }
    public string ShortUrl { get; set; }
  }
}
