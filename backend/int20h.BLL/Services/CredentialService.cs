using Int20h.BLL.Interfaces;
using Int20h.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Int20h.BLL.Services
{
    public class CredentialService(ApplicationDbContext context): ICredentialService
    {
        private readonly ApplicationDbContext _context = context;
        private Guid userId;

        public Guid UserId => userId;

        public async Task<bool> SetUser(string email)
        {
            if (email.IsNullOrEmpty())
            {
                return false;
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return false;                
            }
            userId = user.Id;
            return true;
        }
    }
}
