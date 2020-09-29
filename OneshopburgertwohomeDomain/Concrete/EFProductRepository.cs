using OneshopburgertwohomeDomain.Abstract;
using OneshopburgertwohomeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
                try
                {
                    return context.Products;
                }
                catch (DbEntityValidationException dbex)
                {

                    throw;
                }
                }
        }
    }
}
 