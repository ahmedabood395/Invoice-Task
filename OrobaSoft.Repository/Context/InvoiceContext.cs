using Microsoft.EntityFrameworkCore;
using OrobaSoft.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrobaSoft.Repository.Context
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options) 
        { 
        }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
