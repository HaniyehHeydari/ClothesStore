using Microsoft.EntityFrameworkCore;
using Project2_Api.Data.Domain;
using Project2_Api.Data.Entities;
using Shared.Models.User;

namespace Project2_Api.Services
{
    public class UserService
    {
        private readonly StoreDbContext _context;
        public UserService(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<AppUser?> GetAsync(string UserId)
        {
            AppUser? user = await _context.Users.FindAsync(UserId);
            return user;
        }
        public async Task<List<AppUser?>> GetsAsync()
        {
            List<AppUser> users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task AddAsync(UserAddRequestDto model)
        {
            AppUser user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task EditAsync(AppUser user)
        {
            AppUser? oldUser = await _context.Users.FindAsync(user.Id);
            if (oldUser is null)
            {
                throw new Exception("کاربری با این شناسه پیدا نشد.");
            }
            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;
            _context.Users.Update(oldUser);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string UserId)
        {
            AppUser? user = await _context.Users.FindAsync(UserId);
            if (user is null)
            {
                throw new Exception("کاربری با این شناسه پیدا نشد.");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
