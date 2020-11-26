using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orgnzr.Data;
using Orgnzr.Models;
using System.Web;
using System.Net.Mail;

namespace Orgnzr.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly contactContext _context;

        public AppointmentsController(contactContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var contactContext = _context.Appointments.Include(a => a.Client).Include(a => a.Service);
            return View(await contactContext.ToListAsync());
        }

        public async Task<IActionResult> Waitlist()
        {
            var contactContext = _context.Appointments.Include(a => a.Client).Include(a => a.Service);
            return View(await contactContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Client)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(m => m.appointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["clientId"] = new SelectList(_context.Contacts, "clientId", "fullName");
            ViewData["serviceId"] = new SelectList(_context.Services, "serviceID", "serviceName");
            return View();
        }

        // Send email
        public void SendEmail(int emailID, Appointment appointment)
        {
            if (emailID == 1)
            {
                _context.Add(appointment);


                if (_context.Contacts.Find(appointment.clientId).preferredContact.ToString() == "Email")
                {
                    //sending email notificaiton to end user
                    string MAIL_BODY = "An appointment has been created for "
                        + _context.Contacts.Find(appointment.clientId).fullName.ToString() + " on "
                        + appointment.appointmentStartTime.ToShortDateString() + ". <br/> <br/>"
                        + "Service provided: " + _context.Services.Find(appointment.serviceId).serviceName.ToString() + "<br/>"
                        + "Appointment time: " + appointment.appointmentStartTime.ToShortTimeString() + " - "
                        + appointment.appointmentFinishTime.ToShortTimeString();
                    const string MAIL_SUBJECT = "Appointment Reminder";
                    MailMessage mail = new MailMessage();
                    mail.To.Add(_context.Contacts.Find(appointment.clientId).emailAddress.ToString());
                    mail.From = new MailAddress("OrgnzrCorp@gmail.com");
                    mail.Subject = MAIL_SUBJECT;
                    mail.Body = MAIL_BODY;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("OrgnzrCorp", "Hunky7139dory");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            else if (emailID == 2)
            {
                string MAIL_BODY = "An appointment has been deleted for "
                      + _context.Contacts.Find(appointment.clientId).fullName.ToString() + " on "
                      + appointment.appointmentStartTime.ToShortDateString() + ". <br/> <br/>"
                      + "Service provided: " + _context.Services.Find(appointment.serviceId).serviceName.ToString() + "<br/>"
                      + "Appointment time: " + appointment.appointmentStartTime.ToShortTimeString() + " - "
                        + appointment.appointmentFinishTime.ToShortTimeString();
                const string MAIL_SUBJECT = "Appointment Cancellation";
                MailMessage mail = new MailMessage();
                mail.To.Add(_context.Contacts.Find(appointment.clientId).emailAddress.ToString());
                mail.From = new MailAddress("OrgnzrCorp@gmail.com");
                mail.Subject = MAIL_SUBJECT;
                mail.Body = MAIL_BODY;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("OrgnzrCorp", "Hunky7139dory");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            else if (emailID == 3)
            {
                string MAIL_BODY = "An appointment has been edited for "
                      + _context.Contacts.Find(appointment.clientId).fullName.ToString() + " on "
                      + appointment.appointmentStartTime.ToShortDateString() + ". <br/> <br/>"
                      + "Service provided: " + _context.Services.Find(appointment.serviceId).serviceName.ToString() + "<br/>"
                      + "Appointment time: " + appointment.appointmentStartTime.ToShortTimeString() + " - "
                        + appointment.appointmentFinishTime.ToShortTimeString();
                const string MAIL_SUBJECT = "Appointment Update";
                MailMessage mail = new MailMessage();
                mail.To.Add(_context.Contacts.Find(appointment.clientId).emailAddress.ToString());
                mail.From = new MailAddress("OrgnzrCorp@gmail.com");
                mail.Subject = MAIL_SUBJECT;
                mail.Body = MAIL_BODY;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("OrgnzrCorp", "Hunky7139dory");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            
        }
        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("appointmentID,appointmentStartTime,appointmentFinishTime,clientId,serviceId,waitlistAppt")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                SendEmail(1, appointment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["clientId"] = new SelectList(_context.Contacts, "clientId", "fullName", appointment.clientId);
            ViewData["serviceId"] = new SelectList(_context.Services, "serviceID", "serviceName", appointment.serviceId);
            return View(appointment);
        }
        public ActionResult AddToWaitlistAsync(int id)
        {
            var appointment = _context.Appointments.Find(id);
            appointment.waitlistAppt = 0;
            _context.SaveChanges();
            return Redirect("https://localhost:44328/Appointments/Waitlist");
        }
        public ActionResult RemoveFromWaitlistAsync(int id)
        {
            var appointment = _context.Appointments.Find(id);
            appointment.waitlistAppt = waitlistAppt.No;
            _context.SaveChanges();
            return Redirect("https://localhost:44328/Appointments");
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["clientId"] = new SelectList(_context.Contacts, "clientId", "fullName", appointment.clientId);
            ViewData["serviceId"] = new SelectList(_context.Services, "serviceID", "serviceName", appointment.serviceId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("appointmentID,appointmentStartTime,appointmentFinishTime,clientId,serviceId,waitlistAppt")] Appointment appointment)
        {
            if (id != appointment.appointmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SendEmail(3, appointment);
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.appointmentID))
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
            ViewData["clientId"] = new SelectList(_context.Contacts, "clientId", "fullName", appointment.clientId);
            ViewData["serviceId"] = new SelectList(_context.Services, "serviceID", "serviceName", appointment.serviceId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Client)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(m => m.appointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }
  
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            SendEmail(2, appointment);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.appointmentID == id);
        }
    }
}
