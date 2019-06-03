using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_API.Models;

namespace Products_API.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public LibraryContext _context { get; set; }
        public ProductsController(LibraryContext ctxt)
        {
            _context = ctxt;
        }

        // GET: api/v1/products
        [HttpGet]
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        // GET: api/v1/products/5
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Product> GetProduct(int id)
        {
            var theProduct = _context.Products.SingleOrDefault(pr => pr.Id == id);
            if (theProduct == null)
                return NotFound();

            return theProduct;
        }

        // DELETE: api/v1/products/5
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var theProduct = _context.Products.Find(id);
            if (theProduct == null)
                return NotFound();

            _context.Products.Remove(theProduct);
            _context.SaveChanges();             // DO NOT FORGET !!!
            return NoContent();
        }

        // POST: api/v1/products
        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody]Product product)
        {
            // product toevoegen
            _context.Products.Add(product);
            _context.SaveChanges();

            //return product met ID
            return Created("", product);
        }

        // PUT: api/v1/products/5
        [Route("{id}")]
        [HttpPut]
        public ActionResult<Product> UpdateProduct([FromBody]Product product)
        {
            //product updaten
            _context.Products.Update(product);
            _context.SaveChanges();

            //return product met ID
            return Created("", product);
        }
    }
}
