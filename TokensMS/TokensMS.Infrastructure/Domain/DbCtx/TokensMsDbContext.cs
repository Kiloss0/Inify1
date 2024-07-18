﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokensMS.Infrastructure.Domain.Entities;

namespace TokensMS.Infrastructure.Domain.DbCtx
{
    public class TokensMsDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("TokensMsDb"));
        }

        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Token> Tokens { get; set; }

    }
}