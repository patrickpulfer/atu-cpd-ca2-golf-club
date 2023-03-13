using Golf_Club_Management.Models;
using Golf_Club_Management.dbcontext;
using Microsoft.EntityFrameworkCore;

namespace Golf_Club_Management.Services {

    public interface ITeeTimeService {
        Task<IEnumerable<TeeTime>> GetTeeTimesAsync();
        Task<TeeTime> GetTeeTimeAsync(int id);
        Task AddTeeTimeAsync(TeeTime teeTime);
        Task UpdateTeeTimeAsync(TeeTime teeTime);
        Task DeleteTeeTimeAsync(int id);
    }


    public class TeeTimeService : ITeeTimeService {
        private readonly AppDbContext _context;

        public TeeTimeService(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<TeeTime>> GetTeeTimesAsync() {
            return await _context.teeTimes.ToListAsync();
        }

        public async Task AddTeeTimeAsync(TeeTime teeTime) {
            _context.teeTimes.Add(teeTime);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeeTimeAsync(int id) {
            var teeTime = await _context.teeTimes.FindAsync(id);
            _context.teeTimes.Remove(teeTime);
            await _context.SaveChangesAsync();
        }

        public async Task<TeeTime> GetTeeTimeAsync(int id) {
            return await _context.teeTimes.FindAsync(id);
        }

        public async Task UpdateTeeTimeAsync(TeeTime teeTime) {
            _context.Entry(teeTime).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }

    public class TeeTimeBookingService {
        private readonly AppDbContext _context;

        public TeeTimeBookingService(AppDbContext context) {
            _context = context;
        }

        public string[] allTimeSlots = {
            "08:00", "08:15", "08:30", "08:45",
            "09:00", "09:15", "09:30", "09:45",
            "10:00", "10:15", "10:30", "10:45",
            "11:00", "11:15", "11:30", "11:45",
            "12:00", "12:15", "12:30", "12:45",
            "13:00", "13:15", "13:30", "13:45",
            "14:00", "14:15", "14:30", "14:45",
            "15:00", "15:15", "15:30", "15:45",
            "16:00", "16:15", "16:30", "16:45",
            "17:00", "17:15", "17:30", "17:45"};

        public async Task<IEnumerable<TeeTime>> GetBookingsByPlayer(int player) {
            return _context.teeTimes.Where(e => e.PlayerOneId == player
            || e.PlayerTwoId == player
            || e.PlayerThreeId == player
            || e.PlayerFourId == player);
        }


        public async Task<string[]> GetAvailableSlotsbyDate(DateOnly date) {
            var bookings = await Task.FromResult(_context.teeTimes.Where(e => e.Date == date));
            string[] availableTimeSlots = allTimeSlots;
            foreach (var booking in bookings) {
                availableTimeSlots = availableTimeSlots.Where(e => e!=booking.Slot).ToArray();
            }
            return availableTimeSlots;

        }

        public async Task<int> CheckIfPlayersHaveBookingOnDate(DateOnly date, int PlayerOne, int PlayerTwo, int PlayerThree, int PlayerFour) {
            var bookings = await Task.FromResult(_context.teeTimes.Where(e => e.Date == date));
            if (!bookings.Any()) {
                return 0;
            }
            foreach (var booking in bookings) {
                if (booking.PlayerOneId == PlayerOne ||
                    booking.PlayerOneId == PlayerTwo ||
                    booking.PlayerOneId == PlayerThree ||
                    booking.PlayerOneId == PlayerFour) {
                    return booking.PlayerOneId;
                }
                else if (booking.PlayerTwoId == PlayerOne ||
                    booking.PlayerTwoId == PlayerTwo ||
                    booking.PlayerTwoId == PlayerThree ||
                    booking.PlayerTwoId == PlayerFour) {
                    return booking.PlayerTwoId;
                }
                else if (booking.PlayerThreeId == PlayerOne ||
                    booking.PlayerThreeId == PlayerTwo ||
                    booking.PlayerThreeId == PlayerThree ||
                    booking.PlayerThreeId == PlayerFour) {
                    return booking.PlayerThreeId;
                }
                else if (booking.PlayerFourId == PlayerOne ||
                    booking.PlayerFourId == PlayerTwo ||
                    booking.PlayerFourId == PlayerThree ||
                    booking.PlayerFourId == PlayerFour) {
                    return booking.PlayerFourId;
                }
            }
            return 0;
        }
    }
}