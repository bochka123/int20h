using Int20h.DAL.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Int20h.DAL.Entities
{
    public class Role : IdentityRole<Guid>, IBaseEntity<Guid>
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
