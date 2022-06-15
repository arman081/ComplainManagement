using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComplainManagement.MVC.Models;
using ComplainManagement.MVC.Persistance;
using Microsoft.AspNetCore.Http;

namespace ComplainManagement.MVC.Controllers
{
    public class ComplainEntryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComplainEntryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ComplainEntry
        public async Task<IActionResult> Index()
        {
           var UserName = HttpContext.Session.GetString("UserName");
            if (UserName==null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainTypeName");
            var applicationDbContext = _context.ComplainAndSolutions.Include(c => c.ComplainType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ComplainEntry/Details/5
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

        // GET: ComplainEntry/Create
        public IActionResult Create()
        {
            var UserName = HttpContext.Session.GetString("UserName");
            if (UserName == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainTypeName");
            return View();
        }

        // POST: ComplainEntry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComplainId,CustomerName,CustomerMobile,ComplainDetails,ComplainStatus,Solution,ComplainTypeId")] ComplainAndSolution complainAndSolution)
        {
            if (ModelState.IsValid)
            {
                complainAndSolution.ComplainNo = GenerateComplainNo(complainAndSolution.ComplainTypeId);
                complainAndSolution.ComplainStatus = "New";
                complainAndSolution.ComplainDate = DateTime.Now;
                _context.Add(complainAndSolution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainTypeName", complainAndSolution.ComplainTypeId);
            return View(complainAndSolution);
        }
        private string GenerateComplainNo( int ComplainTypeId)
        {
            var complainTypeCode = _context.ComplainTypes.Where(t => t.ComplainTypeId == ComplainTypeId).FirstOrDefault().ComplainTypeName.Substring(0,3).ToUpper();
            var totalComplainsForThisType = _context.ComplainAndSolutions.Where(t => t.ComplainTypeId == ComplainTypeId).Count();

            string ComplainSL = "";
            if (totalComplainsForThisType<10)
            {
                ComplainSL = "00" + (totalComplainsForThisType + 1).ToString();
            }else if (totalComplainsForThisType > 9 && totalComplainsForThisType < 100)
            {
                ComplainSL = "0" + (totalComplainsForThisType + 1).ToString();
            }
            else if (totalComplainsForThisType > 99)
            {
                ComplainSL =  (totalComplainsForThisType + 1).ToString();
            }

            string ComplainNo = complainTypeCode + ComplainSL;
            return ComplainNo;

        }

        // GET: ComplainEntry/Edit/5
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

        // POST: ComplainEntry/Edit/5
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainTypeName", complainAndSolution.ComplainTypeId);
            return View(complainAndSolution);
        }

        // GET: ComplainEntry/Delete/5
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

        // POST: ComplainEntry/Delete/5
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
