using OneshopburgertwohomeDomain.Abstract;
using OnlineShopburgertwohomeWebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineShopburgertwohomeWebUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository Repository ;
        public int PageSize = 5;
        public ProductController(IProductRepository Repo)
        {
            Repository = Repo;    
        }
        public ViewResult List(string category,int page = 1) {

           

            ProductsListViewModel model = new ProductsListViewModel
            { 
                 
                Products = Repository.Products
                                .Where(p => category == null || p.Category == category)
                                .OrderBy(p => p.Idproduit)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    currentPage = page,
                    ItemPerPage = PageSize,
                    TotalItems = Repository.Products.Count(),
                },
                CurrentCategory = category
                    
            };

            return View(model);
        }         
        
    }
}