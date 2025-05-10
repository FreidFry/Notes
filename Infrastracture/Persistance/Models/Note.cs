namespace Notes.Server.Infrastracture.Persistance.Models
{
    public class Note
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsPinned { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid ClientOwnerId { get; set; }
        public Client ClientOwner { get; set; }

        protected Note() { }

        public Note(string Title, string Content, bool IsPinned, Client Client, Guid ClientId)
        {
            this.Title = Title;
            this.Content = Content;
            this.IsPinned = IsPinned;
            ClientOwnerId = ClientId;
            ClientOwner = Client;
        }
    }
}