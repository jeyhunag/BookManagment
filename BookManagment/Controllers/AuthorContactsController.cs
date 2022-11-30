using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookManagment.Models;

namespace BookManagment.Controllers
{
    public class AuthorContactsController : Controller
    {
        private readonly BookDbContext _context;

        public AuthorContactsController(BookDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bookDbContext = _context.AuthorContacts.Include(a => a.Author);
            return View(await bookDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuthorContacts == null)
            {
                return NotFound();
            }

            var authorContact = await _context.AuthorContacts
                .Include(a => a.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorContact == null)
            {
                return NotFound();
            }

            return View(authorContact);
        }

        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContactNumber,Address,AuthorId")] AuthorContact authorContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", authorContact.AuthorId);
            return View(authorContact);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuthorContacts == null)
            {
                return NotFound();
            }

            var authorContact = await _context.AuthorContacts.FindAsync(id);
            if (authorContact == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", authorContact.AuthorId);
            return View(authorContact);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContactNumber,Address,AuthorId")] AuthorContact authorContact)
        {
            if (id != authorContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorContactExists(authorContact.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", authorContact.AuthorId);
            return View(authorContact);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuthorContacts == null)
            {
                return NotFound();
            }

            var authorContact = await _context.AuthorContacts
                .Include(a => a.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorContact == null)
            {
                return NotFound();
            }

            return View(authorContact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuthorContacts == null)
            {
                return Problem("Entity set 'BookDbContext.AuthorContacts'  is null.");
            }
            var authorContact = await _context.AuthorContacts.FindAsync(id);
            if (authorContact != null)
            {
                _context.AuthorContacts.Remove(authorContact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorContactExists(int id)
        {
          return _context.AuthorContacts.Any(e => e.Id == id);
        }
    }
}
