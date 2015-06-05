using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using DataLayer.Entities;

namespace DataLayer
{
    public class FinanceContext : DbContext
    {
        public FinanceContext()
            : base("name=FinanceContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<PortfolioHistory> PortfolioHistories { get; set; }
    }
}
