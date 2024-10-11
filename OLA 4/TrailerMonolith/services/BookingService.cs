using TrailerMonolith.Data;
using TrailerMonolith.Models;


namespace TrailerMonolith.Services
{
    public class BookingService
    {
        private readonly TrailerMonolithContext _context;

        public BookingService(TrailerMonolithContext context)
        {
            _context = context;
        }

        public RentalModel BookTrailer(int trailerId, bool purchaseInsurance)
        {
            var trailer = _context.Trailer.Find(trailerId);
            if (trailer == null || !trailer.IsAvailable)
                throw new InvalidOperationException("Trailer is not available.");

            DateTime now = DateTime.Now;
            DateTime midnight = now.Date.AddDays(1);
            
            var rental = new RentalModel
            {
                TrailerID = trailerId,
                Trailer = trailer,
                StartTime = now,
                EndTime = midnight,
                InsurancePurchased = purchaseInsurance,
                IsLate = false
            };

            trailer.IsAvailable = false;
            _context.Rental.Add(rental);
            _context.SaveChanges();

            return rental;
        }

        public void ReturnTrailer(int rentalId)
        {
            var rental = _context.Rental.Find(rentalId);
            var lateFee = 0m;
            var InsuranceFee = 0m;
        
            if (rental == null)
                throw new InvalidOperationException("Invalid rental.");

            if (rental.EndTime < DateTime.Now)
            {
                rental.IsLate = true;
            }

            if(rental.IsLate == true)
            {
                lateFee = 25m;
            }

            if(rental.InsurancePurchased == true)
            {
                InsuranceFee = 50m;
            }

            var payment = new PaymentModel
            {
                RentalID = rentalId,
                Rental = rental,
                InsuranceFee = InsuranceFee,
                LateFee = lateFee
            };

            _context.Payment.Add(payment);
            _context.SaveChanges();
        }
    }
}
