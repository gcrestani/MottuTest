using Microsoft.EntityFrameworkCore;
using MottuTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuTest.Api.DataStore.Postgres
{
  public class Context:DbContext
  {
    public Context(DbContextOptions<Context> options):base(options){}

    public DbSet<UrlDto> Urls { get; set; }
  }
}
