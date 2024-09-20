﻿using A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace A2.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext() : base("name=GameDbContext") { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }


    }
}