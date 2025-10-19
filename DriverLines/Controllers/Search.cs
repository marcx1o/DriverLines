using Microsoft.AspNetCore.Mvc;
using DriverLines.Data;
using System.Linq;

namespace DriverLines.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                ViewBag.Message = "يرجى إدخال كلمة للبحث 🔍";
                return View("Index");
            }

            keyword = keyword.Trim();

            // بحث بالسواق
            var driverResults = _context.Dravers
                .Where(d =>
                    d.DriverName.Contains(keyword) ||
                    d.PhoneNumber.Contains(keyword) ||
                    d.VehicleType.Contains(keyword) ||
                    d.VehicleNumber.Contains(keyword) ||
                    d.Areas.Contains(keyword) ||
                    d.Notes.Contains(keyword)
                )
                .ToList();

            // بحث بالخطوط
            var lineResults = _context.Line
                .Where(l =>
                    l.Area.Contains(keyword) ||
                    l.VehicleType.Contains(keyword) ||
                    l.VehicleNumber.Contains(keyword) ||
                    l.Notes.Contains(keyword)
                )
                .ToList();

            ViewBag.Keyword = keyword;
            ViewBag.DriverResults = driverResults;
            ViewBag.LineResults = lineResults;

            return View();
        }
    }
}