using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using a_product_catalog.Data;
using a_product_catalog.Models;
using Microsoft.AspNetCore.Authorization;

namespace a_product_catalog.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }



        [AllowAnonymous]
        
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10; // Number of products to display per page
            if (page == null) { page = 1; }// Get the requested page number or default to 1
            int pageNumber =(int) page ; 

            var products = await _context.Products
                .OrderBy(p => p.Name) // You can order by a productName property
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Calculate the total number of pages will be in the paginated bar
            var totalProducts = await _context.Products.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            if (products == null)
            {
                return Problem("Entity set 'ProductDbContext.Products' is null.");
            }

            // Pass pagination information to the view
            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPages"] = totalPages;

            return View(products);
        }






        // GET: Products/Details/5

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        #region Create


        [Authorize(Roles ="Admin")]
        #region GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region POST: Products/Create

        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,StockQuantity,ExpirationDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        #endregion

        #endregion


        [Authorize(Roles = "Admin,StockWorker")]

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        
        [HttpPost]
        
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,StockQuantity,ExpirationDate")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                    product.ExpirationDate = product.ExpirationDate.Date;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
               
                  
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        #region delete

        #region GET: Products/Delete

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        #endregion

        #region POST: Products/Delete
        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ProductDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #endregion

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
