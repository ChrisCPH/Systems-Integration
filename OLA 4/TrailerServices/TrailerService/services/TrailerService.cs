using TrailerService.Data;
using TrailerService.Models;

namespace TrailerService.Services
{
    public class TrailerService
    {
        private readonly TrailerContext _context;

        public TrailerService(TrailerContext context)
        {
            _context = context;
        }

        public IEnumerable<TrailerModel> GetAvailableTrailers()
        {
            return _context.Trailers.Where(t => t.IsAvailable).ToList();
        }

        public bool MarkTrailerAsRented(int trailerId)
        {
            var trailer = _context.Trailers.Find(trailerId);

            if (trailer == null || !trailer.IsAvailable)
            {
                return false;
            }

            trailer.IsAvailable = false;
            _context.SaveChanges();

            return true;
        }
    }
}
