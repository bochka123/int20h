using Int20h.DAL.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Int20h.DAL.Entities;

public class User : IdentityUser<Guid>, IBaseEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    string AvatarUrl { get; set; }
}
