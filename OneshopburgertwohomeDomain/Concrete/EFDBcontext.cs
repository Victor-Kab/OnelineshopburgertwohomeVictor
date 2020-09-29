using OneshopburgertwohomeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneshopburgertwohomeDomain.Concrete
{
    public class EFDBcontext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
