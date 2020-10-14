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
    public class ClientContactsController : Controller
    {
        private readonly contactContext _context;

        public ClientContactsController(contactContext context)
        {
            _context = context;
        }

        // GET: ClientContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: ClientContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ClientContact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.clientId == id);
            if (ClientContact == null)
            {
                return NotFound();
            }

            return View(ClientContact);
        }

        // GET: ClientContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("clientId,firstName,lastName,phoneNumber,emailAddress,preferredContact")] ClientContact clientContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientContact);
        }

        // GET: ClientContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ClientContact = await _context.Contacts.FindAsync(id);
            if (ClientContact == null)
            {
                return NotFound();
            }
            return View(ClientContact);
        }

        // POST: ClientContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("clientId,firstName,lastName,phoneNumber,emailAddress,preferredContact")] ClientContact ClientContact)
        {
            if (id != ClientContact.clientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ClientContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientContactExists(ClientContact.clientId))
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
            return View(ClientContact);
        }

        // GET: ClientContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ClientContact = await _context.Contacts
                .FirstOrDefaultAsync(m => m.clientId == id);
            if (ClientContact == null)
            {
                return NotFound();
            }

            return View(ClientContact);
        }

        // POST: ClientContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ClientContact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(ClientContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientContactExists(int id)
        {
            return _context.Contacts.Any(e => e.clientId == id);
        }
    }
}
