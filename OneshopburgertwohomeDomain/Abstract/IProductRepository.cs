using OneshopburgertwohomeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneshopburgertwohomeDomain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products  { get; }
    }
}
