namespace FunctionalBank.WebApi.Features.User.Entity;

public class RefreshTokenEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime ExpirationTime { get; set; }
}