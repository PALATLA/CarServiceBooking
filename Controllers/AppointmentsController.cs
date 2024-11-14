using Microsoft.AspNetCore.Mvc;
using CarServiceBooking.Data;
using CarServiceBooking.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarServiceBooking.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly CarServiceContext _context;

        public AppointmentsController(CarServiceContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var appointments = _context.Appointments.ToList();
            return View(appointments);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,ServiceId,AppointmentDate,Status")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Appointment created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }


        // GET: Appointments/Edit/5
        // GET: Appointments/Edit/1
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
            return View(appointment);
        }


        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,UserId,ServiceId,AppointmentDate,Status")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
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
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
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
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}


















//using Microsoft.AspNetCore.Mvc;

//namespace CarServiceBooking.Controllers
//{
//    public class AppointmentsController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
