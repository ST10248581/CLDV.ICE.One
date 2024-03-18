using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ICE_One.Data;
using MVC_ICE_One.Models;

namespace MVC_ICE_One.Controllers
{
    public class WorkItemModelsController : Controller
    {
        private readonly MVC_ICE_OneContext _context;

        public WorkItemModelsController(MVC_ICE_OneContext context)
        {
            _context = context;
        }

        // GET: WorkItemModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkItemModel.ToListAsync());
        }

        // GET: WorkItemModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemModel = await _context.WorkItemModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItemModel == null)
            {
                return NotFound();
            }

            return View(workItemModel);
        }

        // GET: WorkItemModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkItemModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkTitle,CreatorName,UploadDate,Price")] WorkItemModel workItemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workItemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workItemModel);
        }

        // GET: WorkItemModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemModel = await _context.WorkItemModel.FindAsync(id);
            if (workItemModel == null)
            {
                return NotFound();
            }
            return View(workItemModel);
        }

        // POST: WorkItemModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkTitle,CreatorName,UploadDate,Price")] WorkItemModel workItemModel)
        {
            if (id != workItemModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workItemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkItemModelExists(workItemModel.Id))
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
            return View(workItemModel);
        }

        // GET: WorkItemModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemModel = await _context.WorkItemModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItemModel == null)
            {
                return NotFound();
            }

            return View(workItemModel);
        }

        // POST: WorkItemModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workItemModel = await _context.WorkItemModel.FindAsync(id);
            if (workItemModel != null)
            {
                _context.WorkItemModel.Remove(workItemModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkItemModelExists(int id)
        {
            return _context.WorkItemModel.Any(e => e.Id == id);
        }
    }
}
