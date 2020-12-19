using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPFinal.Models;

namespace ASPFinal.Controllers
{
    public class BankProductsController : Controller
    {
        private readonly AppDbContext _context;

        public BankProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BankProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.BankProducts.ToListAsync());
        }

        // GET: BankProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankProduct = await _context.BankProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (bankProduct == null)
            {
                return NotFound();
            }

            return View(bankProduct);
        }

        // GET: BankProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Balance,Description")] BankProduct bankProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankProduct);
        }

        // GET: BankProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankProduct = await _context.BankProducts.FindAsync(id);
            if (bankProduct == null)
            {
                return NotFound();
            }
            return View(bankProduct);
        }

        // POST: BankProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Balance,Description")] BankProduct bankProduct)
        {
            if (id != bankProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankProductExists(bankProduct.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bankProduct);
        }

        // GET: BankProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankProduct = await _context.BankProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (bankProduct == null)
            {
                return NotFound();
            }

            return View(bankProduct);
        }

        // POST: BankProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankProduct = await _context.BankProducts.FindAsync(id);
            _context.BankProducts.Remove(bankProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankProductExists(int id)
        {
            return _context.BankProducts.Any(e => e.ProductId == id);
        }
    }
}
