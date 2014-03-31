using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Demo.Models
{
    public class Moive
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseTime { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }


       

    }

    public class MoiveDbContext:DbContext
    {
        public DbSet<Moive> Moives { get; set; }
    }



}