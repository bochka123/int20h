namespace Int20h.DAL.Entities.Abstract
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
