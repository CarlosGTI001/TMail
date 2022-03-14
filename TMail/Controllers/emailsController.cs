using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMail.Data;
using TMail.Models;
using Microsoft.AspNetCore.Identity;

namespace TMail.Controllers
{
    public class emailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public emailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: emails
        public async Task<IActionResult> Index(string? para)
        {
            return View(await _context.email.Where(s => s.para == para).ToListAsync());
        }

        // GET: emails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.email
                .FirstOrDefaultAsync(m => m.id == id);
            if (email == null)
            {
                return View();
            }

            return View(email);
        }

        // GET: emails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: emails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,de,para,fecha,asunto,cuerpo")] email email)
        {
            if (ModelState.IsValid)
            {
                _context.Add(email);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(email);
        }

        // GET: emails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.email.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }
            return View(email);
        }

        // POST: emails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,de,para,fecha,asunto,cuerpo")] email email)
        {
            if (id != email.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(email);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!emailExists(email.id))
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
            return View(email);
        }

        // GET: emails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.email
                .FirstOrDefaultAsync(m => m.id == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // POST: emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var email = await _context.email.FindAsync(id);
            _context.email.Remove(email);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool emailExists(int id)
        {
            return _context.email.Any(e => e.id == id);
        }
    }
}
