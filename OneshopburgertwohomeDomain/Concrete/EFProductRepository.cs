using OneshopburgertwohomeDomain.Abstract;
using OneshopburgertwohomeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace OneshopburgertwohomeDomain.Concrete
{
   
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDBcontext context = new EFDBcontext();
        public IEnumerable<Product> Products 
        {
            get {
                   return context.Products;
                }
        }
    }
}
 