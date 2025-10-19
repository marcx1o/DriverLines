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
    public class LinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinesController(ApplicationDbContext context)
        {
            _context = context;
        }

    }

        // GET: Lines


namespace DriverLines.Controllers
    {
        public class LinesController : Controller
        {
            private readonly ApplicationDbContext _context;

            public LinesController(ApplicationDbContext context)
            {
                _context = context;
            }

            public IActionResult Index(string searchString)
            {
                var lines = from l in _context.Line
                            select l;

                if (!string.IsNullOrEmpty(searchString))
                {
                    lines = lines.Where(l =>
                        l.Area.Contains(searchString) ||
                        l.VehicleType.Contains(searchString) ||
                        l.VehicleNumber.Contains(searchString) ||
                        l.Phone.Contains(searchString) ||
                        l.Notes.Contains(searchString));
                }

                ViewBag.CurrentFilter = searchString;
                return View(lines.ToList());
            }


            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var line = await _context.Line
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (line == null)
                {
                    return NotFound();
                }

                return View(line);
            }

            // GET: Lines/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Lines/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Area,VehicleType,VehicleNumber,Capacity,RemainingSeats,DriverName,Phone,Notes,Year,GenderType,Cooling")] Line line)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(line);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(line);
            }

            // GET: Lines/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var line = await _context.Line.FindAsync(id);
                if (line == null)
                {
                    return NotFound();
                }
                return View(line);
            }

            // POST: Lines/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Area,VehicleType,VehicleNumber,Capacity,RemainingSeats,DriverName,Phone,Notes,Year,GenderType,Cooling")] Line line)
            {
                if (id != line.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(line);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LineExists(line.Id))
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
                return View(line);
            }

            // GET: Lines/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var line = await _context.Line
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (line == null)
                {
                    return NotFound();
                }

                return View(line);
            }

            // POST: Lines/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var line = await _context.Line.FindAsync(id);
                if (line != null)
                {
                    _context.Line.Remove(line);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool LineExists(int id)
            {
                return _context.Line.Any(e => e.Id == id);
            }
        }
    }
}


