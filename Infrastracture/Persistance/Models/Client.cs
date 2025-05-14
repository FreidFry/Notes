namespace Notes.Server.Infrastracture.Persistance.Models
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; } = 0;
        public string AvatarTumbnailPath { get; set; } = string.Empty;
        public string AvatarPath { get; set; } = string.Empty;

        public string avatarUrl { get; set; } = string.Empty;
        public string avatarTumbnailUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLogin { get; set; } = DateTime.UtcNow;

        public List<Note> Notes { get; set; } = [];











        protected Client() { }
        public Client(string Name, string Email, string Password)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
        }
    }
}
