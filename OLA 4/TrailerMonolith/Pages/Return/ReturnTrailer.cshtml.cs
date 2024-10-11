using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrailerMonolith.Models;
using TrailerMonolith.Services;

namespace TrailerMonolith.Pages.Return
{
    public class ReturnTrailerModel : PageModel
    {
        private readonly BookingService _bookingService;

        public ReturnTrailerModel(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty]
        public int RentalID { get; set; }
        public PaymentModel? ReturnResult { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _bookingService.ReturnTrailer(RentalID);
                // You can add logic to fetch the payment details if needed
                ReturnResult = new PaymentModel { RentalID = RentalID }; // This is a placeholder
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
