using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComplainManagement.MVC.Models;
using ComplainManagement.MVC.Persistance;

namespace ComplainManagement.MVC.Controllers
{
    public class SolutionEntryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolutionEntryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SolutionEntry
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ComplainAndSolutions.Include(c => c.ComplainType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SolutionEntry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complainAndSolution = await _context.ComplainAndSolutions
                .Include(c => c.ComplainType)
                .FirstOrDefaultAsync(m => m.ComplainId == id);
            if (complainAndSolution == null)
            {
                return NotFound();
            }

            return View(complainAndSolution);
        }

        // GET: SolutionEntry/Create
        public IActionResult Create(int ComplainId)
        {
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainTypeName");
            return View();
        }

        // POST: SolutionEntry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComplainId,CustomerName,CustomerMobile,ComplainDetails,ComplainStatus,Solution,ComplainTypeId")] ComplainAndSolution complainAndSolution)
        {
            if (ModelState.IsValid)
            {
                complainAndSolution.ComplainStatus = "Resolved";
                _context.Add(complainAndSolution);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                //return LocalRedirect("/ComplainEntry/Index");
                return RedirectToAction("Index", "ComplainEntry");
            }
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainTypeName", complainAndSolution.ComplainTypeId);
            return View(complainAndSolution);
           
        }

        // GET: SolutionEntry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complainAndSolution = await _context.ComplainAndSolutions.FindAsync(id);
            
            if (complainAndSolution == null)
            {
                return NotFound();
            }
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainTypeName", complainAndSolution.ComplainTypeId);
            return View(complainAndSolution);
        }

        // POST: SolutionEntry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComplainId,CustomerName,CustomerMobile,ComplainDetails,ComplainStatus,Solution,ComplainTypeId")] ComplainAndSolution complainAndSolution)
        {
            if (id != complainAndSolution.ComplainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    complainAndSolution.ComplainStatus = "Resolved";
                    complainAndSolution.SolutionDate = DateTime.Now;
                    _context.Update(complainAndSolution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplainAndSolutionExists(complainAndSolution.ComplainId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return LocalRedirect("/ComplainEntry/Index");
            }
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainTypeName", complainAndSolution.ComplainTypeId);
            return View(complainAndSolution);
        }

        // GET: SolutionEntry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complainAndSolution = await _context.ComplainAndSolutions
                .Include(c => c.ComplainType)
                .FirstOrDefaultAsync(m => m.ComplainId == id);
            if (complainAndSolution == null)
            {
                return NotFound();
            }

            return View(complainAndSolution);
        }

        // POST: SolutionEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complainAndSolution = await _context.ComplainAndSolutions.FindAsync(id);
            _context.ComplainAndSolutions.Remove(complainAndSolution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplainAndSolutionExists(int id)
        {
            return _context.ComplainAndSolutions.Any(e => e.ComplainId == id);
        }
    }
}
