﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DriverLines.Data;
using DriverLines.Data.Tables;

namespace DriverLines.Controllers
{
    public class DriversController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriversController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Drivers
        public IActionResult Index(string searchTerm)
        {
            var drivers = _context.Dravers.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                drivers = drivers.Where(d =>
                    d.DriverName.Contains(searchTerm) ||
                    d.PhoneNumber.Contains(searchTerm) ||
                    d.VehicleType.Contains(searchTerm) ||
                    d.VehicleNumber.Contains(searchTerm));
            }

            return View(drivers.ToList());
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drivers = await _context.Dravers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drivers == null)
            {
                return NotFound();
            }

            return View(drivers);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DriverName,PhoneNumber,VehicleType,VehicleNumber,TotalSeats,RemainingSeats,Areas,Notes,HasAC,ManufactureYear,LineType,LineCode,IsActive")] Drivers drivers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drivers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drivers);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drivers = await _context.Dravers.FindAsync(id);
            if (drivers == null)
            {
                return NotFound();
            }
            return View(drivers);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DriverName,PhoneNumber,VehicleType,VehicleNumber,TotalSeats,RemainingSeats,Areas,Notes,HasAC,ManufactureYear,LineType,LineCode,IsActive")] Drivers drivers)
        {
            if (id != drivers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drivers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriversExists(drivers.Id))
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
            return View(drivers);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drivers = await _context.Dravers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drivers == null)
            {
                return NotFound();
            }

            return View(drivers);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drivers = await _context.Dravers.FindAsync(id);
            if (drivers != null)
            {
                _context.Dravers.Remove(drivers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriversExists(int id)
        {
            return _context.Dravers.Any(e => e.Id == id);
        }
    }
}
