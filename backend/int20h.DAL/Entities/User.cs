using int20h.DAL.Entities.Abstract;

namespace int20h.DAL.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PasswordHash { get; set; }
    public bool IsEmailConfirmed { get; set; }
}
