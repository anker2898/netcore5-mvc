using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoNetCore5.Data;
using CursoNetCore5.Models;

namespace CursoNetCore5.Controllers
{
    public class IncomeExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncomeExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IncomeExpenses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IncomeExpenses.Include(i => i.Categories);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IncomeExpenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeExpenses = await _context.IncomeExpenses
                .Include(i => i.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeExpenses == null)
            {
                return NotFound();
            }

            return View(incomeExpenses);
        }

        // GET: IncomeExpenses/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "NombreCatergoria");
            return View();
        }

        // POST: IncomeExpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Fecha,Valor")] IncomeExpenses incomeExpenses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incomeExpenses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "NombreCatergoria", incomeExpenses.CategoryId);
            return View(incomeExpenses);
        }

        // GET: IncomeExpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeExpenses = await _context.IncomeExpenses.FindAsync(id);
            if (incomeExpenses == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "NombreCatergoria", incomeExpenses.CategoryId);
            return View(incomeExpenses);
        }

        // POST: IncomeExpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Fecha,Valor")] IncomeExpenses incomeExpenses)
        {
            if (id != incomeExpenses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeExpenses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeExpensesExists(incomeExpenses.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "NombreCatergoria", incomeExpenses.CategoryId);
            return View(incomeExpenses);
        }

        // GET: IncomeExpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeExpenses = await _context.IncomeExpenses
                .Include(i => i.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incomeExpenses == null)
            {
                return NotFound();
            }

            return View(incomeExpenses);
        }

        // POST: IncomeExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incomeExpenses = await _context.IncomeExpenses.FindAsync(id);
            _context.IncomeExpenses.Remove(incomeExpenses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeExpensesExists(int id)
        {
            return _context.IncomeExpenses.Any(e => e.Id == id);
        }
    }
}
