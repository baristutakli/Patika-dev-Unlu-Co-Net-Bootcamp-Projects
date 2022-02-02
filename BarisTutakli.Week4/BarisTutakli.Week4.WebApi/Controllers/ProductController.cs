using BarisTutakli.Week4.WebApi.Business;
using BarisTutakli.Week4.WebApi.Business.ViewModels;
using BarisTutakli.Week4.WebApi.Models;
using BarisTutakli.Week4.WebApi.Services.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BarisTutakli.Week4.WebApi.Controllers
{

    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        // Kullanıcılar ürünlerin listesini görüntüleyebilir
        [Authorize(Roles = Roles.User)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            return Ok(result.Result);
        }


        // Herkes sınırlı sayıda ürüne ulaşabilir
        [HttpGet("demo")]
        public IActionResult GetLimitedProducts()
        {
            var result = _productService.GetAll().Result.GetRange(0, 1);
            return Ok(result);
        }


        // Sadece admin yetkisine sahip olan üye ürün ekleyebilir
        [TypeFilter(typeof(CreateProductActionFilter))]
        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public IActionResult Add(ProductCreateViewModel vm)
        {
            var result = _productService.Add(vm);
            if (result.Result < 1)
            {
                return BadRequest(new Response { Status = "Failed" });
            }
            return Ok(new Response { Status = "Success", Message = "One item Created" });
        }

        /// <summary>
        /// Belirtilen id değerine göre ürün getir
        /// api/products/id.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>.</returns>
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var result = _productService.GetById(new ProductDetailQuery{  Id= id });
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result.Result);// return 204 
        }


        /// <summary>
        ///  Sadece admin yetkisine sahip olan üye ürün ekleyebilir
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="updateProductModel">The updateProductModel<see cref="ProductUpdateModel"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [Authorize(Roles = Roles.Admin)]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductUpdateModel updateProductModel)
        {
            var result =_productService.Update(id, updateProductModel);
            if (result.Result>0)
            {
                return Ok(new Response {  Status="Success"});
            }
            return StatusCode(StatusCodes.Status400BadRequest,new Response { Status="Error"});

           
        }


        /// <summary>
        /// Delete a specific product 
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result= await _productService.Delete(new ProductDetailQuery { Id=id});
            if (result>0)
            {
                return Ok(result);
            }
            return BadRequest();//200
        }




        ///// <summary>
        ///// Update the category of a product
        ///// </summary>
        ///// <param name="id">The id<see cref="int"/>.</param>
        ///// <param name="updateProductCategoryViewModel">The updateProductCategoryViewModel<see cref="UpdateProductCategoryViewModel"/>.</param>
        ///// <returns>The <see cref="IActionResult"/>.</returns>
        //[HttpPatch("{id}")]
        //public IActionResult UpdateProductCategory(int id, [FromBody] UpdateProductCategoryViewModel updateProductCategoryViewModel)
        //{


        //    return Ok();
        //}
    }
}
