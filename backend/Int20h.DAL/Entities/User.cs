using Int20h.DAL.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Int20h.DAL.Entities;

public class User : IdentityUser<Guid>, IBaseEntity<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string AvatarUrl { get; set; } = string.Empty;
}
