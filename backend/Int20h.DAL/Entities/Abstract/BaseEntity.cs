namespace Int20h.DAL.Entities.Abstract;

public class BaseEntity : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
