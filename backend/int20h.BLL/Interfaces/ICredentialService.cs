namespace int20h.BLL.Interfaces
{
    public interface ICredentialService
    {
        Guid UserId { get; }
        Task<bool> SetUser(string email);
    }
}
