using RentalService.Data;
using RentalService.Models;

namespace RentalService.Services
{
    public class RentalService
    {
        private readonly RentalContext _context;

        public RentalService(RentalContext context)
        {
            _context = context;
        }

        DateTime now = DateTime.Now;
        DateTime midnight = now.Date.AddDays(1);

        public RentalModel RentTrailer(int trailerId, bool insurance)
        {
            var rental = new RentalModel
            {
                TrailerID = trailerId,
                StartTime = now,
                EndTime = midnight,
                InsurancePurchased = insurance
            };
            
            _context.Rentals.Add(rental);
            _context.SaveChanges();
            return rental;
        }

        public void ReturnTrailer(int rentalId)
        {
            var rental = _context.Rentals.Find(rentalId);
            if (rental == null)
                throw new InvalidOperationException("Rental not found");

            rental.IsLate = DateTime.Now > rental.EndTime;
            _context.SaveChanges();
        }

        private async Task MarkTrailerAsRented(int trailerId)
        {
            var response = await _httpClient.PostAsync($"http://localhost:5010/api/trailer/rent/{trailerId}", null);
            response.EnsureSuccessStatusCode();
        }

        private async Task ProcessPayment(int rentalId, bool isLate, bool insurancePurchased)
        {
            var paymentData = new
            {
                RentalId = rentalId,
                IsLate = isLate,
                InsurancePurchased = insurancePurchased
            };

            var content = new StringContent(JsonSerializer.Serialize(paymentData), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5179/api/payment/process", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
