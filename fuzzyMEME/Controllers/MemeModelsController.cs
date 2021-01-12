using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fuzzyMEME.Data;
using fuzzyMEME.Models;

namespace fuzzyMEME.Controllers
{
    public class MemeModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemeModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MemeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.MemeModel.ToListAsync());
        }

        // GET: MemeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memeModel = await _context.MemeModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memeModel == null)
            {
                return NotFound();
            }

            return View(memeModel);
        }

        // GET: MemeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MemeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MemeBase,MemeExtra")] MemeModel memeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memeModel);
        }

        // GET: MemeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memeModel = await _context.MemeModel.FindAsync(id);
            if (memeModel == null)
            {
                return NotFound();
            }
            return View(memeModel);
        }

        // POST: MemeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MemeBase,MemeExtra")] MemeModel memeModel)
        {
            if (id != memeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemeModelExists(memeModel.Id))
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
            return View(memeModel);
        }

        // GET: MemeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memeModel = await _context.MemeModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memeModel == null)
            {
                return NotFound();
            }

            return View(memeModel);
        }

        // POST: MemeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memeModel = await _context.MemeModel.FindAsync(id);
            _context.MemeModel.Remove(memeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemeModelExists(int id)
        {
            return _context.MemeModel.Any(e => e.Id == id);
        }
    }
}
