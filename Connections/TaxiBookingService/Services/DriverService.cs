using Microsoft.EntityFrameworkCore;
using TaxiBookingService.Data;
using TaxiBookingService.DTOs.Booking;
using TaxiBookingService.DTOs.Driver;
using TaxiBookingService.Interfaces;
using TaxiBookingService.Models;

namespace TaxiBookingService.Services
{
    public class DriverService : IDriverService
    {
        private readonly AppDbContext _context;

        public DriverService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookingResponseDto>> GetPendingRequestsAsync(int driverId)
        {
   
            var driver = await _context.Drivers.FindAsync(driverId)
                ?? throw new Exception("Driver not found.");

            var bookings = await _context.Bookings
                .Include(b => b.Driver)
                .Where(b => b.Status == BookingStatus.Pending
                         && b.CabType.ToLower() == driver.CabType.ToLower())
                .OrderBy(b => b.BookedAt)   // Oldest request first (FIFO)
                .ToListAsync();

            return bookings.Select(b => new BookingResponseDto
            {
                BookingId = b.Id,
                Status = b.Status.ToString(),
                PickupLocation = b.PickupLocation,
                DropLocation = b.DropLocation,
                CabType = b.CabType,
                Fare = b.Fare,
                EstimatedMinutes = b.EstimatedMinutes,
                BookedAt = b.BookedAt,
                DriverName = b.Driver?.Name ?? "-",
                DriverPhone = b.Driver?.Phone ?? "-",
                DriverRating = b.Driver?.Rating ?? 0
            }).ToList();
        }

        public async Task<string> AcceptBookingAsync(int driverId, int bookingId)
        {
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == bookingId
                                       && b.Status == BookingStatus.Pending);

            if (booking == null)
                throw new Exception("Booking not found or already taken.");

            var driver = await _context.Drivers.FindAsync(driverId)
                ?? throw new Exception("Driver not found.");

            booking.DriverId = driverId;
            booking.Status = BookingStatus.Confirmed;

            // Driver is now occupied
            driver.IsAvailable = false;

            await _context.SaveChangesAsync();
            return "Booking accepted successfully.";
        }

        public async Task<string> DeclineBookingAsync(int driverId, int bookingId)
        {
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == bookingId
                                       && b.DriverId == driverId);

            if (booking == null)
                throw new Exception("Booking not found.");

            
            booking.DriverId = null;
            booking.Status = BookingStatus.Pending;

           
            var driver = await _context.Drivers.FindAsync(driverId);
            if (driver != null) driver.IsAvailable = true;

            await _context.SaveChangesAsync();
            return "Booking declined.";
        }

        public async Task<string> UpdateLocationAsync(int driverId, UpdateLocationDto dto)
        {
            var driver = await _context.Drivers.FindAsync(driverId)
                ?? throw new Exception("Driver not found.");

            driver.Latitude = dto.Latitude;
            driver.Longitude = dto.Longitude;

            await _context.SaveChangesAsync();
            return "Location updated successfully.";
        }

        public async Task<string> UpdateAvailabilityAsync(int driverId, UpdateAvailabilityDto dto)
        {
            var driver = await _context.Drivers.FindAsync(driverId)
                ?? throw new Exception("Driver not found.");

            driver.IsAvailable = dto.IsAvailable;

            await _context.SaveChangesAsync();
            return $"Availability set to {dto.IsAvailable}.";
        }

        public async Task<string> CompleteRideAsync(int driverId, int bookingId)
        {
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == bookingId
                                       && b.DriverId == driverId
                                       && b.Status == BookingStatus.Confirmed);

            if (booking == null)
                throw new Exception("Booking not found or not in progress.");

            booking.Status = BookingStatus.Completed;
            booking.CompletedAt = DateTime.UtcNow;

            var driver = await _context.Drivers.FindAsync(driverId);
            if (driver != null) driver.IsAvailable = true;

            await _context.SaveChangesAsync();
            return "Ride marked as completed.";
        }
    }
}