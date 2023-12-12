namespace CrmBrusnika.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;

        public User(string email)
        {
            Email = email;
        }
    }
}
