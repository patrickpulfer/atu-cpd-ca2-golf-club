using Golf_Club_Management.Models;
using Golf_Club_Management.dbcontext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Golf_Club_Management.Services {
    public class GolferViewService {
        private readonly AppDbContext _context;

        public GolferViewService(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Golfer>> GetAllGolfersAsync() {
            return await _context.golfers.ToListAsync();
        }

        public async Task Bookings() { // todo
        }

        public async Task<IEnumerable<Golfer>> FilterByGenderM() {
            return _context.golfers.Where(e => e.Sex == "m");
        }

        public async Task<IEnumerable<Golfer>> FilterByGenderF() {
            return _context.golfers.Where(e => e.Sex == "f");
        }

        public async Task<IEnumerable<Golfer>> FilterHandicapBelow10() {
            return _context.golfers.Where(e => e.Handicap < 10);

        }

        public async Task<IEnumerable<Golfer>> FilterHandicapBetween11and20() {
            return _context.golfers.Where(e => e.Handicap > 10 & e.Handicap < 21 );
        }

        public async Task<IEnumerable<Golfer>> FilterHandicapAbove20() {
            return _context.golfers.Where(e => e.Handicap > 20);
        }

    }
}

/*
public async Task<IEnumerable<Golfer>> GetGolfersAsync() {
    return await _context.golfers.ToListAsync();
}
*/