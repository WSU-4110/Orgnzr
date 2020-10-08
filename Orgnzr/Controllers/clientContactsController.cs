using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orgnzr.Data;
using Orgnzr.Models;

namespace Orgnzr.Controllers
{
    public class clientContactsController : Controller
    {
        private readonly contactContext _context;

        public clientContactsController(contactContext context)
        {
            _context = context;
        }

        // GET: clientContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: clientContacts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientContact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.phoneNumber == id);
            if (clientContact == null)
            {
                return NotFound();
            }

            return View(clientContact);
        }

        // GET: clientContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: clientContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("firstName,lastName,phoneNumber,emailAddress,preferredContact")] clientContact clientContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientContact);
        }

        // GET: clientContacts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientContact = await _context.Contacts.FindAsync(id);
            if (clientContact == null)
            {
                return NotFound();
            }
            return View(clientContact);
        }

        // POST: clientContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("firstName,lastName,phoneNumber,emailAddress,preferredContact")] clientContact clientContact)
        {
            if (id != clientContact.phoneNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!clientContactExists(clientContact.phoneNumber))
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
            return View(clientContact);
        }

        // GET: clientContacts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientContact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.phoneNumber == id);
            if (clientContact == null)
            {
                return NotFound();
            }

            return View(clientContact);
        }

        // POST: clientContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var clientContact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(clientContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool clientContactExists(string id)
        {
            return _context.Contacts.Any(e => e.phoneNumber == id);
        }
    }
}
