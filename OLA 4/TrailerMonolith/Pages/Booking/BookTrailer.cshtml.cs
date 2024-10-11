using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrailerMonolith.Data;
using TrailerMonolith.Models;
using TrailerMonolith.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrailerMonolith.Pages.Booking
{
    public class BookTrailerModel : PageModel
    {
        private readonly BookingService _bookingService;
        private readonly TrailerMonolithContext _context;

        public BookTrailerModel(BookingService bookingService, TrailerMonolithContext context)
        {
            _bookingService = bookingService;
            _context = context;
        }

        [BindProperty]
        public int TrailerID { get; set; }
        [BindProperty]
        public bool PurchaseInsurance { get; set; }

        public List<SelectListItem> TrailerList { get; set; } = new List<SelectListItem>();
        public RentalModel? BookingResult { get; set; }

        public void OnGet()
        {
            TrailerList = _context.Trailer
                .Where(t => t.IsAvailable)
                .Select(t => new SelectListItem
                {
                    Value = t.TrailerID.ToString(),
                    Text = $"{t.Location} (ID: {t.TrailerID})"
                })
                .ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                BookingResult = _bookingService.BookTrailer(TrailerID, PurchaseInsurance);
                return Page();
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
