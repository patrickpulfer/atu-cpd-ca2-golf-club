using Golf_Club_Management.Models;
using Golf_Club_Management.dbcontext;
using Microsoft.EntityFrameworkCore;

namespace Golf_Club_Management.Services {
    public interface IGolfersService {
        Task<IEnumerable<Golfer>> GetGolfersAsync();
        Task<Golfer> GetGolferAsync(int id);
        Task AddGolferAsync(Golfer golfer);
        Task UpdateGolferAsync(Golfer golfer);
        Task DeleteGolferAsync(int id);
    }

    public class GolfersService : IGolfersService {
        private readonly AppDbContext _context;

        public GolfersService(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Golfer>> GetGolfersAsync() {
            return await _context.golfers.ToListAsync();
        }

        public async Task<Golfer> GetGolferAsync(int id) {
            return await _context.golfers.FindAsync(id);
        }

        public async Task AddGolferAsync(Golfer golfer) {
            _context.golfers.Add(golfer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGolferAsync(Golfer golfer) {
            _context.Entry(golfer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGolferAsync(int id) {
            var golfer = await _context.golfers.FindAsync(id);
            _context.golfers.Remove(golfer);
            await _context.SaveChangesAsync();
        }
    }
}
