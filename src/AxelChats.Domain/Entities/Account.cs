namespace AxelChats.Domain.Entities
{
    public record Account : Entity
    {
        public string Username { get; init; }
        
        public string Email { get; init; }
    }
}
