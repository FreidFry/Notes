namespace Notes.Server.Infrastracture.Persistance.Models
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLogin { get; set; } = DateTime.UtcNow;
        public string AvatarTumbnailPath { get; set; }
        public string AvatarPath { get; set; }
        public string Password { get; set; }

        public List<Note> Notes { get; set; }

        protected Client() { }
        public Client(string Name, string Email, int Age, string AvatarTumbnailPath, string AvatarPath, string Password, List<Note> Notes)
        {
            this.Name = Name;
            this.Email = Email;
            this.Age = Age;
            CreatedAt = DateTime.UtcNow;
            LastLogin = DateTime.UtcNow;
            this.AvatarTumbnailPath = AvatarTumbnailPath;
            this.AvatarPath = AvatarPath;
            this.Password = Password;

            this.Notes = Notes;
        }
    }
}
