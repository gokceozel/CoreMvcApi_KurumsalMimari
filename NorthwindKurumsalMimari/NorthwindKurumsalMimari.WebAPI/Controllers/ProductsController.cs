using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindKurumsalMimari.Business.Abstract;
using NorthwindKurumsalMimari.Entities.Concrete;

namespace NorthwindKurumsalMimari.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(template:"getall")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (result.Success)
                return Ok(result.Data);
            else
              return  BadRequest(result.Message);
        }

        [HttpGet(template:"getByCategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [HttpGet(template: "getById")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [HttpPost(template: "Add")]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }
    }
}