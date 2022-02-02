namespace BarisTutakli.WebApi.Controllers
{
    using BarisTutakli.WebApi.Common;
    using BarisTutakli.WebApi.DbOperations;
    using BarisTutakli.WebApi.Models.Concrete;
    using BarisTutakli.WebApi.ProductOperations.CreateProduct;
    using BarisTutakli.WebApi.ProductOperations.DeleteProduct;
    using BarisTutakli.WebApi.ProductOperations.GetProductDetail;
    using BarisTutakli.WebApi.ProductOperations.GetProducts;
    using BarisTutakli.WebApi.ProductOperations.ListProducts;
    using BarisTutakli.WebApi.ProductOperations.UpdateProduct;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="ProductController" />.
    /// </summary>
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ECommerceDbContext _context;

        public ProductController(ECommerceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all produtcs
        /// api/products.
        /// </summary>
        /// <returns>.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            GetProductsQuery query = new GetProductsQuery(_context, new CustomMapper());
            var result = query.Handle();

            return Ok(result);
        }

        /// <summary>
        /// Get one specific produtc by id
        /// api/products/id.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>.</returns>
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            GetProductDetailQuery query = new GetProductDetailQuery(_context, new CustomMapper());
            query.ProductId = id;

            var result = query.Handle();
            if (result is not null)
            {
                return Ok(result);
            }
            return NoContent();// return 204 
        }

        /// <summary>
        /// Create a product
        /// api/products
        /// </summary>
        /// <param name="createProductModel">The createProductModel<see cref="CreateProductModel"/>.</param>
        /// <returns>.</returns>
        [HttpPost()]
        public IActionResult Create([FromBody] CreateProductModel createProductModel)
        {

            CreateProductCommand command = new CreateProductCommand(_context, new CustomMapper());
            CreateProductCommandValidator validator = new CreateProductCommandValidator();
            command.Model = createProductModel;
            validator.ValidateAndThrow(command);
            command.Handle();


            // Return a message and the creation time of the product
            string message = JsonConvert.SerializeObject(new { message = Messages.Added, time = DateTime.Now });
            return Created("Index", message);//201
        }

        /// <summary>
        /// Update a specific product
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="updateProductModel">The updateProductModel<see cref="UpdateProductModel"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProductModel updateProductModel)
        {
            UpdateProductCommand command = new UpdateProductCommand(_context, new CustomMapper());
            UpdateProductCommandValidator validator = new UpdateProductCommandValidator();
            command.ProductId = id;
            command.Model = updateProductModel;
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        /// <summary>
        /// Update the category of a product
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="updateProductCategoryViewModel">The updateProductCategoryViewModel<see cref="UpdateProductCategoryViewModel"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPatch("{id}")]
        public IActionResult UpdateProductCategory(int id, [FromBody] UpdateProductCategoryViewModel updateProductCategoryViewModel)
        {

            UpdateProductCommand command = new UpdateProductCommand(_context, new CustomMapper());
            UpdateProductCommandValidator validator = new UpdateProductCommandValidator();
            command.ProductId = id;
            command.Model = new UpdateProductModel { CategoryId = updateProductCategoryViewModel.CategoryId };
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        /// <summary>
        /// Delete a specific product 
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            DeleteProductCommand command = new DeleteProductCommand(_context);
            DeleteProductCommandValidator validator = new DeleteProductCommandValidator();
            command.ProductId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();//200
        }

        /// <summary>
        /// The SortAscById.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("sortAscById")]
        public IActionResult SortAscById()
        {
            ListProductsByAscOrderQuery query = new ListProductsByAscOrderQuery(_context);
            List<Product> orderedList;
            try
            {
                orderedList = query.Handle();
            }
            catch (Exception)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            if (orderedList.Count == 0)
            {
                return NotFound();
            }
            return Ok(orderedList);
        }

        /// <summary>
        /// The SortDescById.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("sortDescById")]
        public IActionResult SortDescById()
        {
            ListProductsByDescOrderQuery query = new ListProductsByDescOrderQuery(_context);
            List<Product> descOrderedList;
            try
            {
                descOrderedList = query.Handle();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

            if (descOrderedList.Count == 0)
            {
                return NotFound();
            }
            return Ok(descOrderedList);
        }

        /// <summary>
        /// The PostHead.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [HttpHead("{id}")]
        public string PostHead(int id)
        {
            return "merhaba";
        }

        /// <summary>
        /// The HowToReturn401.
        /// </summary>
        /// <param name="authorization">The authorization<see cref="string"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("/panel/{authorization}")]
        public IActionResult HowToReturn401(string authorization)
        {
            if (authorization == "user")
            {
                return Unauthorized();//401
            }
            return Ok();
        }

        /// <summary>
        /// The HowToReturn403.
        /// </summary>
        /// <param name="authorization">The authorization<see cref="string"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("/panel/vip/{authorization}")]
        public IActionResult HowToReturn403(string authorization)
        {
            if (authorization == "user")
            {
                return StatusCode(403);// Forbidden
            }
            return Ok();
        }

        /// <summary>
        /// The HowToReturn503.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("/admin")]
        public IActionResult HowToReturn503()
        {

            return StatusCode(503);
        }


    }
}
